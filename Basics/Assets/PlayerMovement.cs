﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float Speed = 10f;
    private CharacterController CharacterController;

    // Camera
    public Camera Camera;
    private float mouseSensitivity = 100f;
    private float xRotation = 0f;

    // Gravity
    public Transform GroundCheck;
    public LayerMask Ground;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;
    private float jumpHeight = 2f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement
        var move = transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        CharacterController.Move(move * Speed * Time.deltaTime);

        // Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // Gravity
        isGrounded = Physics.CheckSphere(GroundCheck.position, 0.4f, Ground);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);

        velocity.y += gravity * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime);
    }
}
