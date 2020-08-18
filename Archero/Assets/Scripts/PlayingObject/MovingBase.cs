using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase : BaseMonoBehaviour
{
    [SerializeField] protected AnimatorBase animator;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected float maxSpeed;
    protected float speed;
    [HideInInspector] protected bool isMoving = false;
    protected Vector3 direction = new Vector3();
    public bool IsMoving { get => isMoving;
        set
        {
            if (isMoving == value)
                return;
            isMoving = value;
            animator.IsMoving = value;
        }
    }
}
