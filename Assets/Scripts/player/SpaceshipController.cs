using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class SpaceshipController : MonoBehaviour
{
    [Header("Movement")]
    public float thrustForce = 100f;
    public float strafeForce = 50f;
    public float boostMultiplier = 2f;
    public float maxSpeed = 200f;

    [Header("Rotation")]
    public float pitchTorque = 50f;
    public float yawTorque = 50f;
    public float rollTorque = 30f;
    public float rotationDamping = 0.8f;

    // Input System
    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction rollAction;
    private InputAction boostAction;

    private Rigidbody rb;
    private PlayerInput playerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
        SetupRigidbody();
    }

    void SetupInputActions()
    {
        // Acessa as a��es diretamente
        moveAction = playerInput.actions["Move"];
        rotateAction = playerInput.actions["Rotate"];
        rollAction = playerInput.actions["Roll"];
        boostAction = playerInput.actions["Boost"];
    }

    void SetupRigidbody()
    {
        rb.useGravity = false;
        rb.linearDamping = 0;
        rb.angularDamping = 0.5f;
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        LimitVelocity();
    }

    void HandleMovement()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        bool boost = boostAction.ReadValue<float>() > 0.5f;

        float thrust = thrustForce * (boost ? boostMultiplier : 1f);

        // Forward/backward
        rb.AddForce(transform.forward * moveInput.y * thrust);

        // Left/right strafe
        rb.AddForce(transform.right * moveInput.x * strafeForce);
    }

    void HandleRotation()
    {
        Vector2 rotateInput = rotateAction.ReadValue<Vector2>();
        float rollInput = rollAction.ReadValue<float>();

        // Pitch (up/down)
        rb.AddTorque(transform.right * rotateInput.y * pitchTorque);

        // Yaw (left/right)
        rb.AddTorque(transform.up * rotateInput.x * yawTorque);

        // Roll (Q/E)
        rb.AddTorque(transform.forward * rollInput * rollTorque);

        // Damping
        rb.angularVelocity *= rotationDamping;
    }

    void LimitVelocity()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}