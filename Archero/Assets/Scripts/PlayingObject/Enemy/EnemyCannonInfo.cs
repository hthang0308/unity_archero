using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonInfo : LivingObjectInfo
{
    public override void SetUp()
    {
        base.SetUp();
        EnemyCannonData data = database as EnemyCannonData;
        EnemyCannonAttackStyle atk = attackBase.CurAttackStyle as EnemyCannonAttackStyle;
        ExplosionDamageSource explosion = dmgSource as ExplosionDamageSource;
        atk.speed = data.SpeedBullet;
        explosion.radiusExplosion = data.RadiusExplosion;
    }
}
