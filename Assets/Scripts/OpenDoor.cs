using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private InputManager inputManager;
    private string sceneName;
    public GameObject hingeA;
    public GameObject hingeB;
    private float openAngleA;
    private float openAngleB;
    public float doorSpeedA = 2f;
    public float doorSpeedB = 2f;
    bool playerInRange;
    bool opened;
    public Canvas interactionMessage;
    
    void Start()
    {
        openAngleA = 0.0f;
        openAngleB = 0.0f;
        opened = false;
        playerInRange = false;
        inputManager = InputManager.Instance;
    }
   
    void Update()
    {
        //Waits for the player to open the door
        if (playerInRange && inputManager.PlayerInteractedThisFrame() && opened == false)
        {
            interactionMessage.gameObject.SetActive(false);
            opened = true;
            FindObjectOfType<AudioManager>().Play("OpenDoor");
        }

        //opens doorA at the speed set in the inspector
        if (opened && openAngleA < 95) 
        {
            hingeA.transform.Rotate(0, -Time.deltaTime * doorSpeedA * 10, 0);
            openAngleA += Time.deltaTime * doorSpeedA * 10;
        }

        //opens doorB at the speed set in the inspector
        if (opened && openAngleB < 95)
        {
            hingeB.transform.Rotate(0, Time.deltaTime * doorSpeedB * 10, 0);
            openAngleB += Time.deltaTime * doorSpeedB * 10;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")      
        {
            if (opened == false)
            {
                interactionMessage.gameObject.SetActive(true);
            }
            
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactionMessage.gameObject.SetActive(false);
            playerInRange = false;
        }
    }
}
