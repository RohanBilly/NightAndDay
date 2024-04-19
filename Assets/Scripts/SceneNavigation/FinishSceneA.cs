using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishSceneA : MonoBehaviour
{
    //Loads the MiddleText1 scene which
    //asks player to answer questions

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            SceneManager.LoadScene(2);
        }
    }
}
