using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : BaseMonoBehaviour
{
    [SerializeField] protected Animator animator;

    //Moving
    protected bool isMoving;

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool(AnimatorParameters.isMovingID, isMoving);
        }
    }

}
