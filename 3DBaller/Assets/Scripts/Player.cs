using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // 중력, 전진 스피드(전방), 이동 스피드(좌우)
    private RoadSpawner roadSpawner;
    private ScoreManager scoreManager;

    private Animator anim;
    private Rigidbody rgd;

    public float gravity = 100f;
    public float forwardSpeed = 10f;

    public float moveZ;
    public float moveSpeed = 10f;

    private float deadPoint = -5f;
    public bool isDead = false;

    // 플레이 시에 최초 한 번만 호출
    private void Awake()
    {
        rgd = GetComponent<Rigidbody>(); // 변수에 캐싱한다(임시 저장)
        anim = GetComponent<Animator>();
        roadSpawner = GameObject.Find("RoadSpawner").GetComponent<RoadSpawner>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if(transform.position.y < deadPoint)
        {
            gameObject.SetActive(false);
            Dead();
        }

        // 키 입력
        if(Input.GetMouseButton(0) && !isDead)
        {
            moveZ -= moveSpeed * Time.deltaTime;
        }
        else if(Input.GetMouseButton(1) && !isDead)
        {
            moveZ += moveSpeed * Time.deltaTime;
        }
        else
        {
            moveZ = 0;
        }
    }

    private void FixedUpdate()
    {
        // 고정된 프레임으로 일정한 간격으로 업데이트가 가능하다
        // 주로 물리 객체를 이곳에서 다룬다
        rgd.velocity = new Vector3(forwardSpeed, 0f, moveZ);
        rgd.AddForce(new Vector3(0f, -gravity, 0f) * rgd.mass);
    }

    public void DeadRoutine()
    {
        // 죽는 애니메이션 실행
        isDead = true;
        anim.Play("10_Sleep03_Cat_Copy");
    }

    private void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // 모든 것이 최기화 된다!
            // 방법이 많다
            // 씬을 새로 로드한다.
            // 죽는 애니메이션 실행
            DeadRoutine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 로드스포너의 트리거 충돌 체크
        if (other.CompareTag("Create"))
        {
            roadSpawner.MakeRoad();
        }
    }
}

// 죽음 처리에 대한 조건
// 1. 적 블록에 닿으면 죽는다

// 1-1. 죽을 때 연출이 추가 된다.(연출이 끝난 다음 시작 위치로 초기화 된다)
// 살붙여주고 양념을 쳐주는 과정을 게임 개발에서는 폴리싱 단계라고 한다.

// 2. 죽는 것과 동시에 플레이어의 위치는 초기화 된다.
