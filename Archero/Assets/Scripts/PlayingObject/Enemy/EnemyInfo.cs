using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        base.SetUp();
        EnemyData data = database as EnemyData;
        EnemyHealth healthEnemy = health as EnemyHealth;
        healthEnemy.expOnDeath = data.ExpOnDeath;
        healthEnemy.goldEachExp = data.GoldEachExp;
    }
}
