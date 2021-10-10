using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering;

public class EnviromentSoul : MonoBehaviour
{
    [SerializeField] SoulsController souls;
    [SerializeField] Volume volume;

    [SerializeField] ColorAdjustments colorAdjustments;
    
    Bloom testBloom;

    // Start is called before the first frame update
    void Awake()
    {
      
        //if(volume.profile.TryGet<Bloom>(out testBloom))
        //    testBloom.intensity=
    }

    // Update is called once per frame
    void Update()
    {
        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            colorAdjustments.saturation.value = souls.CurrentSouls-100;

        }
           
    }
}
