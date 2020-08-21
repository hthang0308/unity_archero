using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : BaseMonoBehaviour
{
    public Animator animator;

    //Moving
    protected bool isMoving = false;

    public bool IsMoving
    {
        get => isMoving;
        set
        {
            isMoving = value;
            animator.SetBool(AnimatorParameters.var_isMovingID, isMoving);
        }
    }




}
