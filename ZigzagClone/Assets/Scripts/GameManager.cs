using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;

    private void Awake()
    {
        GameScenes.globalGameManager = this;
    }

    private void Update()
    {
        // 게임 시작 관리를 한다
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isGameStarted = true;

        // 길 자동 생성 함수 호출
        GameScenes.globalAutoRoad.StartAutoRoad();
        
        // 캐릭터 애니메이션 변경
        GameScenes.globalCharacterController.ChangeState(State.Run);
    }

    public void OverGame()
    {
        isGameStarted = false;

        // 길 생성 함수 취소
        GameScenes.globalAutoRoad.StopAutoRoad();
    }
}
