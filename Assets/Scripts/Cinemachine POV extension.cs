using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

public class CinemachinePOVextension : CinemachineExtension
{
    //Taken from tutorial: https://www.youtube.com/watch?v=5n_hmqHdijM&ab_channel=samyam

    [SerializeField]
    private float clampAngle = 80f;
    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;

    private float inputSpeedChange = 0.5f;
    

    private InputManager inputManager;
    private Vector3 startingRotation;

    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }


    void Update()
    {
        // Sets the sensitivity for mouse or controller
        
        if (Gamepad.current != null)
        {
            inputSpeedChange = 7f;
            Debug.Log("Controller connected");
        }
        else
        {
            inputSpeedChange = 0.5f;
            Debug.Log("Controller not connected");
        }

    }

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam, 
        CinemachineCore.Stage stage, 
        ref CameraState state, 
        float deltatime){

        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                
                Vector2 deltaInput = inputManager.GetMouseDelta() * inputSpeedChange;
                startingRotation.x += deltaInput.x * Time.deltaTime * verticalSpeed;
                startingRotation.y += deltaInput.y * Time.deltaTime * horizontalSpeed;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x,0f);
            }
        }

    }
}
