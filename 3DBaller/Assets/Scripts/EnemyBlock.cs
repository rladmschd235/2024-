using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    // ���� �� ��ġ�� -5����Ʈ �϶��ϸ� ������ ���ŵȴ�
    private float deadPoint = -5f;

    private void Update()
    {
        if(transform.position.y < deadPoint)
        {
            gameObject.SetActive(false);
        }
    }
}
