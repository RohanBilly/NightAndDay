using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour
{
    public GameObject lightningOne;   //Uses three directional lights that point in 
    public GameObject lightningTwo;   //different directions to make a blinding bright
    public GameObject lightningThree; //light.

    private void Start()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

    }

    public void CallLightning()
    {
        FindObjectOfType<AudioManager>().Play("Thunder");
        StartCoroutine(LightningD());
    }

    IEnumerator LightningD() //Plays out a pre set pattern of flashing
                             //on and off to simulate lightening.
    {
        lightningOne.SetActive(true);
        lightningTwo.SetActive(true);
        lightningThree.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        lightningOne.SetActive(true);
        lightningTwo.SetActive(true);
        lightningThree.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);
        yield return new WaitForSeconds(0.4f);

        lightningOne.SetActive(true);
        lightningTwo.SetActive(true);
        lightningThree.SetActive(true);

        yield return new WaitForSeconds(0.15f);

        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

    }
}
