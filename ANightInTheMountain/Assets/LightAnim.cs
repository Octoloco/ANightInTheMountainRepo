using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnim : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Light light;
    private bool up;

    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.intensity > 1.69)
        {
            up = false;
        }
        else if (light.intensity < 1.01)
        {
            up = true;
        }

        if (up) 
        {
            light.intensity += speed * Time.deltaTime;
        }
        else
        {
            light.intensity -= speed * Time.deltaTime;
        }
    }
}
