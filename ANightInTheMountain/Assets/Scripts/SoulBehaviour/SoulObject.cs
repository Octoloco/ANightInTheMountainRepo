using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulObject : MonoBehaviour

{
    [SerializeField] SoulsController soulsController;
    [SerializeField] SoundEvent soundEvent;
    private void OnTriggerEnter(Collider other)
    {
        soulsController.AddSouls();
        Destroy(gameObject.transform.parent.gameObject, 0.25f);
        soundEvent.PlayClipByIndex(3);
    }
}
