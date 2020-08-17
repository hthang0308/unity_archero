using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase : BaseMonoBehaviour
{
    [SerializeField] protected PlayerAnimator animator;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected float maxSpeed;
    protected float speed;
    [HideInInspector] private bool isMoving = false;
    protected Vector3 direction = new Vector3();

    public bool IsMoving { get => isMoving;
        set
        {
            if (isMoving == value)
                return;
            animator.IsMoving = value;
            isMoving = value;
        }
    }

    public override void UpdateNormal()
    {
        Move();
    }

    protected void Move()
    {
        //Move the object
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up); 
            rigidbody.velocity = transform.forward * maxSpeed;
            IsMoving = true;
            return;
        }

        IsMoving = false;
    }
}
