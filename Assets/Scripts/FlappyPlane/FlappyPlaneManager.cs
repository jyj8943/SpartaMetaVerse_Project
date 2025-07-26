using System;
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

    private bool isPaused = true;
    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    private void Awake()
    {
        flappyPlaneManager = this;
        uiManager = FindObjectOfType<FlappyPlaneUIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);

        if (isPaused)
            Time.timeScale = 0f;
    }

    private void Update()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isPaused = false;
                Time.timeScale = 1f;
                uiManager.TurnOffReadyText();
            }
        }
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
