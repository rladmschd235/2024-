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
        // ���� ���� ������ �Ѵ�
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isGameStarted = true;

        // �� �ڵ� ���� �Լ� ȣ��
        GameScenes.globalAutoRoad.StartAutoRoad();
        
        // ĳ���� �ִϸ��̼� ����
        GameScenes.globalCharacterController.ChangeState(State.Run);
    }

    public void OverGame()
    {
        isGameStarted = false;

        // �� ���� �Լ� ���
        GameScenes.globalAutoRoad.StopAutoRoad();
    }
}
