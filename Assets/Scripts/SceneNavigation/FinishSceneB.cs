using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSceneB : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {

            SceneManager.LoadScene(4);
            //Application.Quit();
        }
    }
}
