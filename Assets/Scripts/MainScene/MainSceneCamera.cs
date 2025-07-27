using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneCamera : MonoBehaviour
{
    [SerializeField]private PlayerControl _player;
    
    // X 범위: -11 ~ 24, Y 범위: -6 ~ 15
    // 카메라의 X 범위: -0.30 ~ 13.25, Y 범위: 0 ~ 8.9
    private Vector2 minBounds = new Vector2(-0.3f, 0f);
    private Vector2 maxBounds = new Vector2(13.25f, 8.9f);
    private Vector3 offset;
    private float smoothSpeed = 5f;
    
    void Start()
    {
        _player = FindObjectOfType<PlayerControl>();
        if (_player == null)
        {
            Debug.LogError("플레이어를 찾지 못했습니다.");
        }

        offset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = _player.transform.position + offset;
        desiredPos.z = transform.position.z;

        desiredPos.x = Mathf.Clamp(desiredPos.x, minBounds.x, maxBounds.x);
        desiredPos.y = Mathf.Clamp(desiredPos.y, minBounds.y, maxBounds.y);

        this.transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);
    }
}
