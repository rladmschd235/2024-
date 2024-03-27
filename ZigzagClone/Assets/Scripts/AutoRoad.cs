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

        // �ڵ� �� ���� �׽�Ʈ
        // StartAutoRoad();
    }

    private void Update()
    {
        // �� ���� �׽�Ʈ Ű �Է�
        if(Input.GetKeyDown(KeyCode.A))
        {
            CreateRoadPart();
        }
    }

    // ���� ���� �� ���� �Լ� �������.

    private void CreateRoadPart()
    {
        // 50% Ȯ���� ������ �ٲ� ���·� ���� ����
        // 50% Ȯ���� ���� �������� ���� ����
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

        // ����Ƽ���� ���ο� �������� �����ϴ� �ڵ�
        GameObject roadObj = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        roadObj.transform.parent = this.transform;
        lastPos = roadObj.transform.position;

        // ũ����Ż ������ ����

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
