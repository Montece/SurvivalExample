using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //https://youtu.be/_QajrabyTJc

    public float MoveSpeed = 8f;
    public float RunSpeed = 14f;
    public float Gravity = -9.81f;
    public float JumpHeight = 3f;

    public float StaminaPerRun = 10f;
    public float StaminaPerJump = 30f;
    public float RegenStaminaPerSecond = 10f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public Vector3 Velocity;
    public bool IsGrounded;

    private CharacterController controller;
    private PlayerStats stats;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (IsGrounded && Velocity.y < 0) Velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        bool isRun = Input.GetKey(KeyCode.LeftShift) && move != Vector3.zero;

        if (isRun && stats.GetCurStamina() >= StaminaPerRun * Time.deltaTime)
        {
            controller.Move(RunSpeed * Time.deltaTime * move);
            stats.RemoveCurStamina(StaminaPerRun * Time.deltaTime);
        }
        else
        {
            controller.Move(MoveSpeed * Time.deltaTime * move);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && stats.GetCurStamina() >= StaminaPerJump)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            stats.RemoveCurStamina(StaminaPerJump);
        }

        Velocity.y += Gravity * Time.deltaTime;

        controller.Move(Velocity * Time.deltaTime);

        if (!isRun && IsGrounded) stats.AddCurStamina(RegenStaminaPerSecond * Time.deltaTime);
    }
}