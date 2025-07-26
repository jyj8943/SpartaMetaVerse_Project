using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyPlaneUIManager : MonoBehaviour
{
    private FlappyPlaneManager flappyPlaneManager = null;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI readyText;
    public Button quitButton;
    public Button restartButton;
    
    void Start()
    {
        flappyPlaneManager = FlappyPlaneManager.Instance;
        
        if (readyText == null)
            Debug.LogError("restart text is null");
        
        if (scoreText == null)
            Debug.LogError("score text is null");

        if (quitButton == null)
            Debug.LogError("QuitButton is null");
        
        if (restartButton == null)
            Debug.LogError("RestartButton is null");

        if (flappyPlaneManager.IsPaused)
        {
            readyText.gameObject.SetActive(true);
        }
    }

    public void SetRestart()
    {
        // restartText.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickRestartButton()
    {
        flappyPlaneManager.RestartGame();
    }

    public void TurnOffReadyText()
    {
        readyText.gameObject.SetActive(false);
    }
}
