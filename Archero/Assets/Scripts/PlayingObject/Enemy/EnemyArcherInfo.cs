using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        EnemyArcherData data = database as EnemyArcherData;
        EnemyArcherAttackStyle atk = attackBase.CurAttackStyle as EnemyArcherAttackStyle;
        health.maxHP = data.MaxHP;
        atk.delayNextAttack = data.DelayNextAttack;
        atk.speed = data.SpeedBullet;
        atk.atkPoint = data.AtkPoint;
        atk.effectDatas = data.EffectDatas;
        movement.maxSpeed = data.Speed;
        //
        atk.rangeMoving = data.RangeMove;
        atk.timeMove = data.TimeMove;
        atk.distance = data.BulletMaxDistance;
    }
}
