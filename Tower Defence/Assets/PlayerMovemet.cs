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
    private Vector3 velocity;

    public LayerMask groundMask; 
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public bool isGrounded;

    void Start()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}