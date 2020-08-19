using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : BaseMonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector2 clampOffset = new Vector2(-2,2);
    Vector2 clamp;

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
        tmpPos.z = Mathf.Clamp(tmpPos.z, clamp.x, clamp.y);
        transform.position = tmpPos;
    }

    public void SetClamp(float startingPoint, float endingPoint)
    {
        clamp.x = startingPoint + clampOffset.x;
        clamp.y = endingPoint + clampOffset.y;
        
    }
}
