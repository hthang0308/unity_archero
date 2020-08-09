using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase : BaseMonoBehaviour
{
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected float maxSpeed;
    protected float speed;
    [HideInInspector] public bool isMoving = false;
    protected Vector3 direction = new Vector3();

    public override void UpdateNormal()
    {
        base.UpdateNormal();
    }

    protected void Move()
    {
        //Move the object
        if (direction != Vector3.zero)
            rigidbody.velocity = direction * speed;
    }
}
