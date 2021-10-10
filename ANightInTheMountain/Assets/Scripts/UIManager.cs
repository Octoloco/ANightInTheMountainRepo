using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool gamePaused = true;

    [SerializeField]
    private PausePanel pausePanel;

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

    void Start()
    {
        gamePaused = false;
    }

    void Update()
    {
    }
    public void ShowPausePanel()
    {
        pausePanel.enabled = true;
    }

    public void ShowGameOverPanel()
    {
        //gameOverPanel.finished = false;
        //gameOverPanel.Show();
    }

    public void HideGameOverPanel()
    {
        //gameOverPanel.Hide();
    }

    public void SetFinalScore(int finalScore)
    {
        //gameOverPanel.SetScoreGoal(finalScore);
    }

    public void UpdateGameScore(int newScore)
    {
        //gamePanel.UpdateScore(newScore);
    }

    public void DrawLevel(int level)
    {
        //gamePanel.DrawLevel(level);
    }
}
