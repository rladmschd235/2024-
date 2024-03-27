using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // �濡 ���� �������� �迭�� ������ ����
    public GameObject[] roads;
    public GameObject blockPrefab;

    private float blockIndex, roadIndex = 1;

    private void Start()
    {
        blockIndex = -10f;

        for(int i = 0; i < 10; i++)
        {
            // ����� ����
            SpawnBlock();
        }

        blockIndex = 0;
    }

    private void SpawnBlock()
    {
        // ���ο� ���� ������ �� ���� ���̰� �ƴ� ���� ���̸� �� ����
        Vector3 newPos = new Vector3(Random.Range(blockIndex * 10 - 20, blockIndex * 10 - 10), 1f, Random.Range(-1f, 1));
        GameObject newBlock = Instantiate(blockPrefab, newPos, Quaternion.identity);

        blockIndex++;
    }

    // �ǽð����� ���� �����ϴ� �Լ�
    public void MakeRoad()
    {
        int idx = Random.Range(0, roads.Length);
        Vector3 newPos = new Vector3(roadIndex * 100 - 100, 0, 0);

        // worldspace�� localspace�� ����(���� ����)
        GameObject newRoad = Instantiate(roads[idx], newPos, roads[idx].transform.rotation);

        for (int i = 0; i < 10; i++)
        {
            // ����� ����
            SpawnBlock();
        }

        roadIndex++;
    }

    // ������ ����
    // �ε� ������Ʈ ������
    //public GameObject roadObjPref;
    //public Vector3 roadPosition = new Vector3(-100f, 0f, 0f);

    // �ε� ������Ʈ ���� ����
    //private float offset = 100f;

    //public void SpawnRoad()
    //{
    //    Instantiate(roadObjPref, roadPosition + new Vector3(offset, 0f, 0f), Quaternion.identity);
    //    roadPosition = roadPosition + new Vector3(offset, 0f, 0f);
    //}
}
