using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTrigger : MonoBehaviour
{
    private bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && triggered == false) 
        {

            //Plays thunder effect and sound when the player crosses the attatched collider

            triggered = true; //Can only play once
            FindObjectOfType<Lightning>().CallLightning();
            FindObjectOfType<AudioManager>().Play("Thunder");
        }
    }
    
}
