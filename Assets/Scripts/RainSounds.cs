using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RainSounds : MonoBehaviour
{
    private string sceneName;

    private void Awake()
    {
        //Checks the scene to play different sounds in different scenes
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        FindObjectOfType<AudioManager>().Play("Rain"); 
        if(sceneName == "SceneB")
        {
            //Plays the wind sound effect in the unsettling scene
            FindObjectOfType<AudioManager>().Play("Wind"); 
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Used to change the sound when the player is inside or outside
        if (other.tag == "Player") 
        {
            if (sceneName == "SceneB")
            {
                FindObjectOfType<AudioManager>().StopPlaying("Wind");
            }
            FindObjectOfType<AudioManager>().StopPlaying("Rain");
            FindObjectOfType<AudioManager>().Play("InsideRain");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
            FindObjectOfType<AudioManager>().StopPlaying("InsideRain");
            FindObjectOfType<AudioManager>().Play("Rain");
            if (sceneName == "SceneB")
            {
                FindObjectOfType<AudioManager>().Play("Wind");
            }
        
    }
}
