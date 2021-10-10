using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance = null;
    [SerializeField]
    private float transitionTime;

    [SerializeField]
    private Animator[] animatorsList;
    const int maxScenes = 9;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void ReloadCurrentScene()
    {

    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextScene());
    }
    public void LoadSceneByIndex(int index)
    {

        StartCoroutine(LoadLevelByIndex(index));
    }
    private IEnumerator LoadLevelByIndex(int index)
    {
        foreach (Animator a in animatorsList)
        {
            a.SetTrigger("start");
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
    IEnumerator LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1 >= maxScenes ? 0 : currentScene + 1;


        foreach (Animator a in animatorsList)
        {
            a.SetTrigger("start");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextScene);
    }
    IEnumerator LoadCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;



        foreach (Animator a in animatorsList)
        {
            a.SetTrigger("start");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(currentScene);
    }

}
