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
        Move();
    }

    protected void Move()
    {
        isMoving = false; 
        //Move the object
        if (direction != Vector3.zero)
        {
            isMoving = true;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up); 
            rigidbody.velocity = transform.forward * maxSpeed;
        }
    }
}
