using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShellInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        EnemyShellMoving mov = movement as EnemyShellMoving;
        //diem chung
        health.maxHP = database.MaxHP;
        mov.delayMove = database.DelayNextAttack;
        CollisionDamageSource collisionDmgSource = dmgSource as CollisionDamageSource;
        collisionDmgSource.atkPoint = database.AtkPoint;
        collisionDmgSource.effectDatas = database.EffectDatas;
    }
}
