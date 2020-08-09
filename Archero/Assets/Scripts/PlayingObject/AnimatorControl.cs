using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : BaseMonoBehaviour
{
    [SerializeField] protected Animator animator;
    protected bool isMoving;
    [SerializeField] protected MovingBase movingBase;

    public override void UpdateNormal()
    {
        //if the state change
        bool tmp = movingBase.isMoving;
        if (isMoving != tmp)
        {
            isMoving = tmp;
            //change the name of the condition
            animator.SetBool("isMoving", isMoving);
        }
    }

}
