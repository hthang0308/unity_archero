using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : AnimatorBase
{
    protected bool isMultiShot;
    public bool IsMultiShot
    {
        set
        {
            isMultiShot = value;
            animator.SetBool(AnimatorParameters.var_multiShootID, isMultiShot);
        }
    }

    protected bool hasEnemy;
    public bool HasEnemy
    {
        set
        {
            hasEnemy = value;
            animator.SetBool(AnimatorParameters.var_hasEnemyID, hasEnemy);
        }
    }


}
