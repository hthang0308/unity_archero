using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        EnemyCannonData data = database as EnemyCannonData;
        EnemyCannonAttackStyle atk = attackBase.CurAttackStyle as EnemyCannonAttackStyle;
        //diem chung
        health.maxHP = data.MaxHP;
        atk.delayNextAttack = data.DelayNextAttack;
        atk.speed = data.SpeedBullet;
        atk.atkPoint = data.AtkPoint;
        atk.effectDatas = data.EffectDatas;
        movement.maxSpeed = data.Speed;
        //diem rieng
        atk.explosionRadius = data.ExplosionRadius;
    }
}
