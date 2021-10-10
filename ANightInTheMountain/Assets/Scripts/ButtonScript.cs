using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {

    }

    public void PlayGame()
    {
        LevelLoader.instance.LoadNextLevel();
    }
}
