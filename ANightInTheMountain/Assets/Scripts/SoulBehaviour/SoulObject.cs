using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulObject : MonoBehaviour
    
{
    [SerializeField] SoulsController soulsController;
    private void OnTriggerEnter(Collider other)
    {
        soulsController.AddSouls();
    }
}
