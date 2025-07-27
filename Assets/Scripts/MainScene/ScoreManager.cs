using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager scoreManager;

    public static ScoreManager Instance
    {
        get { return scoreManager; }
    }

    private void Awake()
    {
        scoreManager = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // 점수 확인용 디버그
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteKey("FlappyPlaneBestScore");
        }
    }

    public void SaveFlappyPlaneScore(int bestScore)
    {
        if (!PlayerPrefs.HasKey("FlappyPlaneBestScore"))
        {
            PlayerPrefs.SetInt("FlappyPlaneBestScore", bestScore);
        }
        else
        {
            if (PlayerPrefs.GetInt("FlappyPlaneBestScore") <= bestScore)
            {
                PlayerPrefs.SetInt("FlappyPlaneBestScore", bestScore);
            }
        }
        
        PlayerPrefs.Save();
    }
}
