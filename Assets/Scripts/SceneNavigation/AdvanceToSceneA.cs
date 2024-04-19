using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceToSceneA : MonoBehaviour
{

    //Loads scene A from the TitleText screen

    private InputManager inputManager;
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        if (inputManager.PlayerInteractedThisFrame() )
        {
            SceneManager.LoadScene(1);
        }
    }
}
