using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlanePlayer : MonoBehaviour
{
    private FlappyPlaneManager flappyPlaneManager = null;
    
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    private float deathCooldown = 0f;
    
    private bool isFlap = false;
    public bool godMode = false;
    
    private void Start()
    {
        flappyPlaneManager = FlappyPlaneManager.Instance;
        
		// 애니메이터와 리지드바디를 컴포넌트에서 찾기
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

		// 애니메이터와 리지드바디가 없으면 에러 출력
        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    private void Update()
    {
        if (isDead)
        {
            // 죽었을 때 대기 시간(`deathCooldown`)이 끝나면 재시작을 위한 입력 받기
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작
                    flappyPlaneManager.RestartGame();
                }
            }
            else
            {
                // 대기 시간 감소
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            // 점프 (플랩) 입력 처리
            if (Input.GetKeyDown(KeyCode.Space) ||Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    // 물리 업데이트 (고정된 시간 간격으로 호출됨)
    public void FixedUpdate()
    {
        if (isDead)
            return;
        
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        
        // 리지드바디 속도 업데이트
        _rigidbody.velocity = velocity;
        
        // 점프 시 각도 조정 (위아래로 기울기)
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        //float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    // 충돌 처리
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;
            
        if (isDead)
            return;

        // 죽음 애니메이션 실행
        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        flappyPlaneManager.GameOver();
    }
}
