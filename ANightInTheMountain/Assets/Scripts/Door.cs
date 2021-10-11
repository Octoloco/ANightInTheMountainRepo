using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Door : MonoBehaviour
{
   
    [SerializeField] SoulsController souls;
    [SerializeField] int minimunSouls;
    [SerializeField] SoundEvent soundEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (souls.CurrentSouls >= minimunSouls)
        {
            // onSuccess.Invoke();
            soundEvent.PlayClipByIndex(4);
            LevelLoader.instance.LoadNextLevel();
        }
        else
        {
            LevelLoader.instance.ReloadCurrentScene();
        }
    }
}
