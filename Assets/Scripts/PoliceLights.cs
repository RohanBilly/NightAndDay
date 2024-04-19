using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    public Light lightA;
    public Light lightB;

    public float switch_speed = 5f; //Changes the speed of the changing lights

    private float light_intensity;
    private bool light_switch;

    private void Start()
    {
        light_switch = true;
        light_intensity = 0.0f;
    }
    void Update()
    {
        if (light_switch)
        {
            light_intensity += Time.deltaTime * switch_speed;
            if (light_intensity > 10f)
            {
                light_switch = false;
            }
        }
        else
        {
            light_intensity -= Time.deltaTime * switch_speed;
            if (light_intensity < -10f)
            {
                light_switch = true;
            }
        }
        if (light_intensity < 0)
        {
            lightA.intensity = light_intensity * -1f;
            lightB.intensity = 1f;
        }
        else
        {
            lightB.intensity = light_intensity;
            lightA.intensity = 1f;
        }
    }
}
