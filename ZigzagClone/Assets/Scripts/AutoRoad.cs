using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRoad : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = 0.707f;

    private int crystalSpawnCount = 0;

    private void Awake()
    {
        GameScenes.globalAutoRoad = this;

        // 자동 길 생성 테스트
        // StartAutoRoad();
    }

    private void Update()
    {
        // 길 생성 테스트 키 입력
        if(Input.GetKeyDown(KeyCode.A))
        {
            CreateRoadPart();
        }
    }

    // 내가 봤을 땐 랜덤 함수 못만든다.

    private void CreateRoadPart()
    {
        // 50% 확률로 방향이 바뀐 상태로 길이 생성
        // 50% 확률로 전방 방향으로 길이 생성
        Vector3 spawnPos = Vector3.zero;

        float chance = Random.Range(0, 100);
        
        if (chance > 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
            crystalSpawnCount++;
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
            crystalSpawnCount++;
        }

        // 유니티에서 새로운 프리팹을 생성하는 코드
        GameObject roadObj = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        roadObj.transform.parent = this.transform;
        lastPos = roadObj.transform.position;

        // 크리스탈 아이템 생성

        if(crystalSpawnCount % 5 == 0)
        {
            // roadObj.gameObject.transform.Find("Crystal").gameObject.SetActive(true);
            roadObj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void StartAutoRoad()
    {
        InvokeRepeating("CreateRoadPart", 1, 0.5f);
    }

    public void StopAutoRoad()
    {
        CancelInvoke("CreateRoadPart");
    }
}
