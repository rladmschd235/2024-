using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // 길에 대한 프리팹을 배열로 가지고 있자
    public GameObject[] roads;
    public GameObject blockPrefab;

    private float blockIndex, roadIndex = 1;

    private void Start()
    {
        blockIndex = -10f;

        for(int i = 0; i < 10; i++)
        {
            // 블록을 생성
            SpawnBlock();
        }

        blockIndex = 0;
    }

    private void SpawnBlock()
    {
        // 새로운 길을 생성할 때 고정 길이가 아닌 랜덤 길이를 줘 보자
        Vector3 newPos = new Vector3(Random.Range(blockIndex * 10 - 20, blockIndex * 10 - 10), 1f, Random.Range(-1f, 1));
        GameObject newBlock = Instantiate(blockPrefab, newPos, Quaternion.identity);

        blockIndex++;
    }

    // 실시간으로 길을 생성하는 함수
    public void MakeRoad()
    {
        int idx = Random.Range(0, roads.Length);
        Vector3 newPos = new Vector3(roadIndex * 100 - 100, 0, 0);

        // worldspace와 localspace의 차이(시험 출제)
        GameObject newRoad = Instantiate(roads[idx], newPos, roads[idx].transform.rotation);

        for (int i = 0; i < 10; i++)
        {
            // 블록을 생성
            SpawnBlock();
        }

        roadIndex++;
    }

    // 과거의 무언가
    // 로드 오브젝트 프리팹
    //public GameObject roadObjPref;
    //public Vector3 roadPosition = new Vector3(-100f, 0f, 0f);

    // 로드 오브젝트 생성 간격
    //private float offset = 100f;

    //public void SpawnRoad()
    //{
    //    Instantiate(roadObjPref, roadPosition + new Vector3(offset, 0f, 0f), Quaternion.identity);
    //    roadPosition = roadPosition + new Vector3(offset, 0f, 0f);
    //}
}
