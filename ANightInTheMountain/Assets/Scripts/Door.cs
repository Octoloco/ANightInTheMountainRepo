using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] UnityEvent onSuccess;
    [SerializeField] UnityEvent onFail;
    [SerializeField] SoulsController souls;
    [SerializeField] int minimunSouls;

    private void OnCollisionEnter(Collision collision)
    {
        if (souls.CurrentSouls >= minimunSouls)
            onSuccess?.Invoke();
        else
            onFail.Invoke();
    }
}
