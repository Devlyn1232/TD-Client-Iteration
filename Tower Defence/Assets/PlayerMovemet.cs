using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float WalkSpeed;
    public float CrouchSpeed;
    public float Speed;
    public float gravity = -30f;
    public float jumpHeight;
    private Vector3 velocity;

    public LayerMask groundMask; 
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public bool isGrounded;

    public float dashDistance = 30f;
    private const float dashDuration = 0.1f;
    private const float dashCooldown = 1f;
    public bool isDashing;
    public float dashTimer;
    public float dashCooldownTimer;
    private Vector3 dashDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if ((isGrounded))
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }



        if (Input.GetKeyDown(KeyCode.Q) && dashCooldownTimer <= 0)
            {
                // Start the dash
                isDashing = true;
                // Get the input direction
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;
                dashDirection = transform.TransformDirection(inputDirection);
                dashTimer = 0f;
                dashCooldownTimer = dashCooldown;
                velocity = dashDirection * dashDistance / dashDuration;
            }
        if (isDashing) {
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashDuration) 
            {
                // Stop the dash
                isDashing = false;
                velocity = Vector3.zero;
            }
        } 
        else 
        {
            // Apply gravity when not dashing
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        if (dashCooldownTimer > 0) {
        dashCooldownTimer -= Time.deltaTime;
        }



        if (Input.GetButton("Fire3"))
        {
            Speed += 0.01f;
        }
        else 
        {
            Speed = WalkSpeed;
        }
    }
}