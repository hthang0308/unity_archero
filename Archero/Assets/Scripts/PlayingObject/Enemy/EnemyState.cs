using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    protected bool attack1;
    public bool Attack1
    {
        set
        {
            attack1 = value;
            animator.SetBool(AnimatorParameters.var_isAttack1_ID, value);
        }
    }
    protected int attack2;
    public int Attack2
    {
        set
        {
            attack2 = value;
            animator.SetInteger(AnimatorParameters.var_isAttack2_ID, value);
        }
    }
    protected bool isGetHit;
    public bool IsGetHit
    {
        set
        {
            isGetHit = value;
            animator.SetBool(AnimatorParameters.var_isGetHitID, value);
        }
    }
    //protected bool isLowHp;
    //public bool IsLowHP
    //{
    //    set
    //    {
    //        isLowHp = value;
    //        animator.SetBool(AnimatorParameters.var_isLowHpID, value);
    //    }
    //}
}
