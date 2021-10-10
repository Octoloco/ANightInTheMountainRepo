using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        yield return new WaitForSeconds(2);
        GetComponent<SoundEvent>().PlayClip();
    }
}
