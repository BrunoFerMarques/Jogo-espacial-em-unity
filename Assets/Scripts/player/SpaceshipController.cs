using UnityEngine;
using UnityEngine.InputSystem; // Adicione esta linha

public class SpaceshipWASDController : MonoBehaviour
{
    [Header("Movimento")]
    public float thrustSpeed = 50f;
    public float strafeSpeed = 30f;
    public float rollSpeed = 80f;
    public float boostMultiplier = 2f;

    [Header("Rotação")]
    public float pitchSpeed = 40f;
    public float yawSpeed = 40f;

    private Rigidbody rb;
    private PlayerInput playerInput; // Referência ao Input System

    private Vector2 moveInput;
    private Vector2 rotateInput;
    private float rollInput;
    private bool boostInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0f;
        rb.angularDamping = 0.2f;
        playerInput = GetComponent<PlayerInput>(); // Inicializa o Input System
    }

    void OnMove(InputValue value) // Captura movimento (W/A/S/D)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnRotate(InputValue value) // Captura rotação (Setas)
    {
        rotateInput = value.Get<Vector2>();
    }

    void OnRoll(InputValue value) // Captura rolagem (Q/E)
    {
        rollInput = value.Get<float>();
    }

    void OnBoost(InputValue value) // Captura turbo (Shift)
    {
        boostInput = value.isPressed;
    }

    void FixedUpdate()
    {
        // Movimento
        float forwardThrust = moveInput.y * thrustSpeed;
        float strafeThrust = moveInput.x * strafeSpeed;
        float rollThrust = rollInput * rollSpeed;

        if (boostInput)
        {
            forwardThrust *= boostMultiplier;
            strafeThrust *= boostMultiplier;
        }

        rb.AddForce(transform.forward * forwardThrust);
        rb.AddForce(transform.right * strafeThrust);
        rb.AddTorque(transform.forward * -rollThrust);

        // Rotação
        float pitch = rotateInput.y * pitchSpeed;
        float yaw = rotateInput.x * yawSpeed;
        rb.AddRelativeTorque(pitch, yaw, 0f);
    }
}