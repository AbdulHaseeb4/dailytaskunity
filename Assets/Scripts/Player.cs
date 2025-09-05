using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController controller;

    private float Gravity = -9.81f;
    public float GroundDistance = 0.3f;
    public Transform Ground;
    public LayerMask layerMask;
    Vector3 velocity;
    public float jumpHeight = 3f;

    public bool isGrounded;
    public bool isPressed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ✅ Ground check
        isGrounded = Physics.CheckSphere(Ground.position, GroundDistance, layerMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // ✅ Joystick input
        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);

        // ✅ Joystick ka push strength (0 = center, 1 = full tilt)
        float strength = Mathf.Clamp01(input.magnitude);

        // ✅ Move direction
        Vector3 Move = transform.right * input.x + transform.forward * input.y;

        // ✅ Apply movement (speed joystick ke hisaab se scale hogi)
        controller.Move(Move * (SpeedMove * strength) * Time.deltaTime);

        // ✅ Jump
        if (isGrounded && isPressed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
            isGrounded = false;
        }

        // ✅ Gravity
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
