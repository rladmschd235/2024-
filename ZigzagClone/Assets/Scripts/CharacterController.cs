using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
    Run,
    Falling
}

public class CharacterController : MonoBehaviour
{
    public Transform fallingTrm;

    // ���� ���� ó��(���ӸŴ���)
    private Vector3 startPos;

    private Rigidbody rigd;
    private Animator anim;

    private bool bRunRigth;
    public float speed = 2f;

    public int getCrystalCount = 0;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        GameScenes.globalCharacterController = this;

        startPos = transform.position;
    }

    private void Update()
    {
        if(!GameScenes.globalGameManager.isGameStarted)
        {
            return;
        }

        // Ű �Է�
        // ���� ��ȯ (�����̽� Ű)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switchDir();
        }

        // ����ĳ��Ʈ�� ���� ������ üũ
        RaycastHit hit;

        if (!Physics.Raycast(fallingTrm.position, -transform.up, out hit, 100))
        {
            ChangeState(State.Falling);
        }

        // ���� ���� üũ
        CheckDeath();
    }

    private void switchDir()
    {
        bRunRigth = !bRunRigth;

        if(bRunRigth) // ������
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else // ����
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    public void ChangeState(State state)
    {
        // ������ ���½�Ų��.
        //anim.ResetTrigger(State.Falling.ToString());
        //anim.ResetTrigger(State.Idle.ToString());
        //anim.ResetTrigger(State.Run.ToString());
        if (state.Equals(State.Idle))
        {
            anim.ResetTrigger("Falling");
        }

        // �־��� ���·� ����
        anim.SetTrigger(state.ToString());
    }

    private void CheckDeath()
    {
        if (transform.position.y <= -2f)
        {
            // ó�� �����ߴ� �״�� ���� �ʱ�ȭ

            transform.rotation = Quaternion.Euler(0, 45, 0);
            ChangeState(State.Idle);
            transform.position = startPos;

            GameScenes.globalGameManager.OverGame();
        }
    }

    private void FixedUpdate()
    {
        if(!GameScenes.globalGameManager.isGameStarted)
        {
            return;
        }

        // ����
        rigd.transform.position = transform.position + (transform.forward * 2 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Crystal"))
        {
            Destroy(other.gameObject);
            getCrystalCount++;
        }
    }
}
