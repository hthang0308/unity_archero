using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBase : BaseMonoBehaviour
{
    public Animator animator;

    //Moving
    protected bool isMoving;

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool(AnimatorParameters.var_isMovingID, isMoving);
        }
    }
}
