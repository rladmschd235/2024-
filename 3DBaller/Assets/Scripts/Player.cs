using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // �߷�, ���� ���ǵ�(����), �̵� ���ǵ�(�¿�)
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

    // �÷��� �ÿ� ���� �� ���� ȣ��
    private void Awake()
    {
        rgd = GetComponent<Rigidbody>(); // ������ ĳ���Ѵ�(�ӽ� ����)
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

        // Ű �Է�
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
        // ������ ���������� ������ �������� ������Ʈ�� �����ϴ�
        // �ַ� ���� ��ü�� �̰����� �ٷ��
        rgd.velocity = new Vector3(forwardSpeed, 0f, moveZ);
        rgd.AddForce(new Vector3(0f, -gravity, 0f) * rgd.mass);
    }

    public void DeadRoutine()
    {
        // �״� �ִϸ��̼� ����
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
            // ��� ���� �ֱ�ȭ �ȴ�!
            // ����� ����
            // ���� ���� �ε��Ѵ�.
            // �״� �ִϸ��̼� ����
            DeadRoutine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �ε彺������ Ʈ���� �浹 üũ
        if (other.CompareTag("Create"))
        {
            roadSpawner.MakeRoad();
        }
    }
}

// ���� ó���� ���� ����
// 1. �� ��Ͽ� ������ �״´�

// 1-1. ���� �� ������ �߰� �ȴ�.(������ ���� ���� ���� ��ġ�� �ʱ�ȭ �ȴ�)
// ��ٿ��ְ� ����� ���ִ� ������ ���� ���߿����� ������ �ܰ��� �Ѵ�.

// 2. �״� �Ͱ� ���ÿ� �÷��̾��� ��ġ�� �ʱ�ȭ �ȴ�.
