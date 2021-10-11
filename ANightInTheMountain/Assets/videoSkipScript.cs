using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoSkipScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PlayGame());
    }

    private void Update()
    {
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds((float)GetComponent<VideoPlayer>().clip.length);
        LevelLoader.instance.LoadNextLevel();
    }
}
