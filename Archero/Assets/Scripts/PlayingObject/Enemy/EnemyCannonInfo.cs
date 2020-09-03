using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        EnemyCannonData data = database as EnemyCannonData;
        EnemyCannonAttackStyle atk = attackBase.CurAttackStyle as EnemyCannonAttackStyle;
        ExplosionDamageSource explosion = dmgSource as ExplosionDamageSource;
        atk.speed = data.SpeedBullet;
        //diem rieng
        explosion.radiusExplosion = data.RadiusExplosion;

        EnemyHealth healthEnemy = health as EnemyHealth;
        healthEnemy.expOnDeath = data.ExpOnDeath;
        base.SetUp();
    }
}
