using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject playerObj;

    public float offset = 3f;

    private void Awake()
    {
        // find�� �ݺ������� ȣ��Ǵ� �������� ���� ���� �ʴ�
        playerObj = GameObject.FindWithTag("Player");   
    }

    private void FixedUpdate()
    {
        Vector3 temp = this.transform.position;
        temp.x = playerObj.transform.position.x - offset;
        this.transform.position = temp;
    }

    private void LateUpdate()
    {
        
    }
}
