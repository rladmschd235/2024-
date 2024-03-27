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

    // 게임 시작 처리(게임매니져)
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

        // 키 입력
        // 방향 전환 (스페이스 키)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switchDir();
        }

        // 레이캐스트를 통해 길인지 체크
        RaycastHit hit;

        if (!Physics.Raycast(fallingTrm.position, -transform.up, out hit, 100))
        {
            ChangeState(State.Falling);
        }

        // 게임 종료 체크
        CheckDeath();
    }

    private void switchDir()
    {
        bRunRigth = !bRunRigth;

        if(bRunRigth) // 오른쪽
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else // 왼쪽
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    public void ChangeState(State state)
    {
        // 강제로 리셋시킨다.
        //anim.ResetTrigger(State.Falling.ToString());
        //anim.ResetTrigger(State.Idle.ToString());
        //anim.ResetTrigger(State.Run.ToString());
        if (state.Equals(State.Idle))
        {
            anim.ResetTrigger("Falling");
        }

        // 주어진 상태로 변경
        anim.SetTrigger(state.ToString());
    }

    private void CheckDeath()
    {
        if (transform.position.y <= -2f)
        {
            // 처음 시작했던 그대로 값을 초기화

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

        // 전진
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
