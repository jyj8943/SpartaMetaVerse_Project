using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalControl : MonoBehaviour
{
    [SerializeField] private GameObject interactionText;
    [SerializeField] private GameObject bestScoreText;

    private PlayerControl _player;

    public void InteractionWithPortal()
    {
        Debug.Log("포탈과 상호작용에 성공했습니다.");
        SceneManager.LoadScene("FlappyPlane");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("포탈과 상호작용 가능한 영역에 집입했습니다!");

            if (!interactionText.activeSelf)
            {
                interactionText.SetActive(true);
            }

            if (!bestScoreText.activeSelf && PlayerPrefs.GetInt("FlappyPlaneBestScore") != 0)
            {
                // FlappyPlane의 최고 점수를 텍스트에 반영하는 함수
                ChangeBestScoreText();
                
                bestScoreText.SetActive(true);
            }

            _player = other.gameObject.GetComponent<PlayerControl>();
            if (_player != null)
            {
                _player.InteractivePortal = this;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("포탈과 상호작용 가능한 영역에서 벗어났습니다!");
            
            if (interactionText.activeSelf)
            {
                interactionText.SetActive(false);
            }
            
            if (bestScoreText.activeSelf)
            {
                bestScoreText.SetActive(false);
            }

            if (_player != null)
            {
                _player.InteractivePortal = null;
                _player = null;
            }
        }
    }

    private void ChangeBestScoreText()
    {
        bestScoreText.GetComponent<TextMeshPro>().text =
            "BestScore: " + PlayerPrefs.GetInt("FlappyPlaneBestScore").ToString();
    }
}
