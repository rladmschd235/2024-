using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTrm;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - targetTrm.position;
    }

    private void LateUpdate()
    {
        transform.position = targetTrm.position + offset;
    }
}
