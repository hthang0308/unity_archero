using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShellInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        base.SetUp();
        EnemyData data = database as EnemyData;
        EnemyShellMoving shellMoving = movement as EnemyShellMoving;
        shellMoving.delayMove = database.DelayNextAttack;
        EnemyHealth healthEnemy = health as EnemyHealth;
        healthEnemy.expOnDeath = data.ExpOnDeath;
    }
}
