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

    ColorAdjustments colorAdjustments;
    Vignette vignette;



    void Update()
    {
        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
            colorAdjustments.saturation.value = souls.CurrentSouls - 100;
        if (volume.profile.TryGet<Vignette>(out vignette))
            vignette.intensity.value = (float)(Mathf.Abs(souls.CurrentSouls-100) )/ 100;


    }
}
