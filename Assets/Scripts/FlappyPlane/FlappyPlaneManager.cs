using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneManager : MonoBehaviour
{
    private static FlappyPlaneManager flappyPlaneManager;
    public static FlappyPlaneManager Instance
    {
        get { return flappyPlaneManager; }
    }

    private int currentScore = 0;

    private FlappyPlaneUIManager uiManager;
    public FlappyPlaneUIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        flappyPlaneManager = this;
        uiManager = FindObjectOfType<FlappyPlaneUIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
