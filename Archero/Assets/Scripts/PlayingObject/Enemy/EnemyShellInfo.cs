using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShellInfo : EnemyInfo
{
    public override void SetUp()
    {
        base.SetUp();
        EnemyShellMoving shellMoving = movement as EnemyShellMoving;
        shellMoving.delayMove = database.DelayNextAttack;
    }
}
