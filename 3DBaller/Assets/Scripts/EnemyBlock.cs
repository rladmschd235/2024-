using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    // 현재 내 위치가 -5포인트 하락하면 스스로 제거된다
    private float deadPoint = -5f;

    private void Update()
    {
        if(transform.position.y < deadPoint)
        {
            gameObject.SetActive(false);
        }
    }
}
