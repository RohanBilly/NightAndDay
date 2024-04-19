using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isMoving;
    private bool footstepsPlaying = false;
    private InputManager inputManager;
    private Transform cameraTransform;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float sprintSpeed = 4.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        if (movement.x == 0 && movement.y == 0)
        {
            isMoving = false;
            if (footstepsPlaying)
            {
                FindObjectOfType<AudioManager>().StopPlaying("Footsteps");
                footstepsPlaying = false;
            }
        }
        else
        {
            isMoving = true;
            if (!footstepsPlaying)
            {
                footstepsPlaying = true;
                FindObjectOfType<AudioManager>().Play("Footsteps");
            }

        }
        
        
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        
        if (inputManager.GetSprintStatus() == 1f)
        {
            controller.Move(move * Time.deltaTime * sprintSpeed);
        }
        else { controller.Move(move * Time.deltaTime * playerSpeed); }
       
       
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}