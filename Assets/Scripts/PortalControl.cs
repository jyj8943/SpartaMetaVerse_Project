using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    [SerializeField] private GameObject interactionText;

    private PlayerControl _player;

    public void InteractionWithPortal()
    {
        Debug.Log("포탈과 상호작용에 성공했습니다.");
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

            if (_player != null)
            {
                _player.InteractivePortal = null;
                _player = null;
            }
        }
    }
}
