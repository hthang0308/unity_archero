using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : BaseMonoBehaviour
{
    [SerializeField] Transform player;

    public override void Awake()
    {
        base.Awake();
        Vector3 tmpPos = transform.position;
        tmpPos.z = player.position.z;
        transform.position = tmpPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpPos = transform.position;
        tmpPos.z = player.position.z;
        transform.position = tmpPos;
    }
}
