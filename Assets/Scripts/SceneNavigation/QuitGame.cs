using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    //Closes the game window

    private InputManager inputManager;
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        if (inputManager.PlayerInteractedThisFrame())
        {
            Application.Quit();
        }
    }
}
