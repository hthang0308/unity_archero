using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : BaseMonoBehaviour
{
    public Animator animator;

    //Moving
    protected bool isMoving;
    protected bool isMultiShot;

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool(AnimatorParameters.var_isMovingID, isMoving);
        }
    }

    public bool IsMultiShot
    {
        set
        {
            isMultiShot = value;
            animator.SetBool(AnimatorParameters.var_multiShootID, isMultiShot);
        }
    }
}
