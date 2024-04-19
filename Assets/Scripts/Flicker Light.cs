using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour
{
    //Flickering light parameters
    public float minMainOnDuration = 5f;
    public float maxMainOnDuration = 15f;
    public int burstCount = 5;
    public float maxBurstInterval = 30f;
    public int minFlickerCount = 2;
    public int maxFlickerCount = 5;
    public float minFlickerDuration = 0.01f;
    public float maxFlickerDuration = 0.1f;
    public float maxOffDuration = 1f;
    public Material bulbMaterial;

    private Light pointLight;
    private float lastOffTime;

    void Start()
    {
        pointLight = GetComponent<Light>();
        bulbMaterial.DisableKeyword("_EMISSION");

        StartCoroutine(FlickeringPattern());
    }

    IEnumerator FlickeringPattern()
    {
        while (true)
        {
            
            pointLight.enabled = true;
            bulbMaterial.EnableKeyword("_EMISSION");
            float mainOnDuration = Random.Range(minMainOnDuration, maxMainOnDuration);
            yield return new WaitForSeconds(mainOnDuration);

            // Flickering bursts
            for (int i = 0; i < burstCount; i++)
            {
                //keeps the flicker random like a real dying bulb
                int flickerCount = Random.Range(minFlickerCount, maxFlickerCount + 1);
                float burstDuration = Mathf.Min(maxBurstInterval, Random.Range(1f, 2f));

                for (int j = 0; j < flickerCount; j++)
                {
                    pointLight.enabled = !pointLight.enabled;
                    if (pointLight.enabled)
                    {
                        //Stops the bulb material from emmitting light when the point light is off
                        bulbMaterial.EnableKeyword("_EMISSION");
                    }
                    else
                    {
                        bulbMaterial.DisableKeyword("_EMISSION");
                    }
                    float flickerDuration = Random.Range(minFlickerDuration, maxFlickerDuration);
                    yield return new WaitForSeconds(flickerDuration);
                }

                yield return new WaitForSeconds(burstDuration);

                pointLight.enabled = true;
                bulbMaterial.EnableKeyword("_EMISSION");
            }

            //Keep track of the time the light was turned off
            lastOffTime = Time.time;

            
            pointLight.enabled = true;
            bulbMaterial.EnableKeyword("_EMISSION");
        }
    }
}
