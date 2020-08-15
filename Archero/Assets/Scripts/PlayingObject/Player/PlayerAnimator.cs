using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : BaseMonoBehaviour
{
    [SerializeField] protected Animator animator;

    //Moving
    protected bool isMoving;
    protected int isMovingID;

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool(isMovingID, isMoving);
        }
    }

    public override void Awake()
    {
        base.Awake();
        isMovingID = Animator.StringToHash("isMoving");
    }
}
