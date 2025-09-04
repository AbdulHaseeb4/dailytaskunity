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
        isGrounded = Physics.CheckSphere(Ground.position, GroundDistance, layerMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * SpeedMove * Time.deltaTime);

        if(isGrounded && isPressed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
            isGrounded = false;
        }

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
