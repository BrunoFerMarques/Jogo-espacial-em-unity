using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class SpaceshipController : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 5f;
    public float deceleration = 3f;
    public float mainDeceleration = 20f;
    public float maxSpeed = 100f;
    public float currentSpeed = 0f;
    public float boost = 20f;
    [Header("Rotation")]
    public float pitchSpeed = 0.5f;
    public float yawSpeed = 0.5f;
    public float rollSpeed = 0.5f;
    public float rotationDamping = 0.5f;

    // Referências às ações que EXISTEM no seu asset
    private InputAction moveAction;
    private InputAction boostAction;
    private InputAction brakeAction;
    private InputAction mainBreakAction;
    private InputAction rollAction;
    private InputAction acelerationAction;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        var playerInput = GetComponent<PlayerInput>();

        // Acessa apenas as ações que você definiu
        moveAction = playerInput.actions["Move"];
        boostAction = playerInput.actions["Boost"];
        brakeAction = playerInput.actions["Break"]; // Note o nome EXATO
        mainBreakAction = playerInput.actions["MainBreak"];
        rollAction = playerInput.actions["Roll"];
        acelerationAction = playerInput.actions["Aceleration"];
    }

    void Update()
    {
        // Controle de velocidade
        if (boostAction.ReadValue<float>() > 0.5f)
            currentSpeed += boost * Time.deltaTime;
        
        if (brakeAction.ReadValue<float>() > 0.5f)
            currentSpeed -= deceleration * Time.deltaTime;
        if (acelerationAction.ReadValue<float>() > 0.5f)
            currentSpeed += acceleration * Time.deltaTime;
        if (mainBreakAction.ReadValue<float>() > 0.5f)
            currentSpeed -= mainDeceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    void FixedUpdate()
    {
        // Movimento
        rb.linearVelocity = transform.forward * currentSpeed;

        // Rotação (usando Move para pitch/yaw e Roll para... roll)
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float rollInput = rollAction.ReadValue<float>();

        rb.AddRelativeTorque(
            -moveInput.y * pitchSpeed,  // W/S controla pitch (subir/descer)
            moveInput.x * yawSpeed,    // A/D controla yaw (esquerda/direita)
            rollInput * rollSpeed,     // Q/E controla roll
            ForceMode.VelocityChange
        );

        // Suavização
        rb.angularVelocity *= rotationDamping;
    }
}