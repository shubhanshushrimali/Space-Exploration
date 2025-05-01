using UnityEngine;
using UnityEngine.InputSystem;

public class XRSpaceFlyer : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty moveAction;     // Vector2: left stick for movement
    public InputActionProperty verticalAction; // Float: triggers or buttons for up/down
    public InputActionProperty rotateAction;   // Vector2: right stick for pitch/yaw
    public InputActionProperty rollLeftAction; // Button for roll left
    public InputActionProperty rollRightAction;// Button for roll right

    [Header("Movement Settings")]
    public float thrustForce = 10f;
    public float verticalThrust = 8f;
    public float rotationSpeed = 2f;
    public float rollSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = 0f;
        rb.angularDamping = 0.5f;
    }

    void FixedUpdate()
    {
        // Movement
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        float verticalInput = verticalAction.action.ReadValue<float>();
        Vector3 thrustDirection = transform.forward * moveInput.y + transform.right * moveInput.x + transform.up * verticalInput;
        rb.AddForce(thrustDirection * thrustForce, ForceMode.Acceleration);

        // Rotation (Yaw and Pitch)
        Vector2 rotateInput = rotateAction.action.ReadValue<Vector2>();
        Vector3 rotationVector = new Vector3(-rotateInput.y, rotateInput.x, 0);
        rb.AddTorque(transform.TransformDirection(rotationVector) * rotationSpeed, ForceMode.Force);

        // Roll
        bool rollLeft = rollLeftAction.action.IsPressed();
        bool rollRight = rollRightAction.action.IsPressed();
        float rollInput = (rollRight ? 1f : 0f) - (rollLeft ? 1f : 0f);
        rb.AddTorque(transform.forward * rollInput * rollSpeed, ForceMode.Force);
    }
}