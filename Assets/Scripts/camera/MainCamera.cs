using UnityEngine;

public class AircraftCamera : MonoBehaviour
{
    public Transform aircraft;
    public Vector3 baseOffset = new Vector3(0f, 2f, -6f);

    [Header("Suavização")]
    public float positionSmoothTime = 0.3f;
    public float rotationSmoothSpeed = 5f;

    [Header("Limite de Distância")]
    public float maxDistance = 6f; // Máximo que a câmera pode se afastar da nave

    private Vector3 positionVelocity;

    void LateUpdate()
    {
        if (aircraft == null)
        {
            Debug.LogWarning("Nenhuma aeronave atribuída à câmera!");
            return;
        }

        // Calcula posição alvo baseada na orientação da aeronave
        Vector3 targetPosition = aircraft.position
                               + aircraft.right * baseOffset.x
                               + aircraft.up * baseOffset.y
                               + aircraft.forward * baseOffset.z;

        // Limita a distância máxima
        Vector3 offsetFromAircraft = targetPosition - aircraft.position;
        if (offsetFromAircraft.magnitude > maxDistance)
        {
            offsetFromAircraft = offsetFromAircraft.normalized * maxDistance;
            targetPosition = aircraft.position + offsetFromAircraft;
        }

        // Move a câmera suavemente
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref positionVelocity, positionSmoothTime);

        // Olha para a aeronave com rotação suave
        Vector3 lookDirection = aircraft.position - transform.position;
        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, aircraft.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothSpeed);
        }
    }
}
