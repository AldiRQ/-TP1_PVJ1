using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class playerController : MonoBehaviour
{
    public float Speed = 5f;
    public float Gravity = -20f;
    public float JumpHeight = 2f;
    public float rotationSpeed = 10f;
    public Transform spawnPoint;

    private CharacterController controller;
    private Vector2 moveInput;
    private float verticalVelocity;
    private bool jumPressed;

    public Vector3 externalMoveSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        if (jumPressed && isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            jumPressed = false;
        }

        verticalVelocity += Gravity * Time.deltaTime;

        // Direccion del movimiento
        // Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // Invertimos moveInput (-moveInput.x y -moveInput.y) para corregir el modelo volteado
        Vector3 moveDirection = new Vector3(-moveInput.x, 0f, -moveInput.y);


        // Rotacion del personaje
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Movimiento original
        //Vector3 move = moveDirection.normalized;
        Vector3 move = -moveDirection.normalized;
        move.y = verticalVelocity / Speed;

        controller.Move(move * Speed * Time.deltaTime + externalMoveSpeed * Time.deltaTime);
    }



    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumPressed = true;
        }
    }

    public void Die()
    {
        controller.enabled = false;
        transform.position = spawnPoint.position;
        verticalVelocity = 0f;
        controller.enabled = true;
    }

}
