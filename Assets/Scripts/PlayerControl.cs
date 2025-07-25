using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private SpriteRenderer _mainSprite;
    private AnimationHandler _animationHandler;
    
    private float playerSpeed = 5f;

    private void Start()
    {
        _mainSprite = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        _animationHandler = GetComponent<AnimationHandler>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 좌우로 움직일 때 플레이어 스프라이트를 뒤집음
        if (moveX < 0)
            _mainSprite.flipX = true;
        else
            _mainSprite.flipX = false;
        
        Vector3 move = new Vector3(moveX, moveY, 0).normalized;
        transform.position += (move * Time.deltaTime * playerSpeed);
        
        _animationHandler.Move(move);
    }
}
