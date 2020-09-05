using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherInfo : EnemyInfo
{
    public override void SetUp()
    {
        base.SetUp();
        EnemyArcherData data = database as EnemyArcherData;
        EnemyArcherAttackStyle atk = attackBase.CurAttackStyle as EnemyArcherAttackStyle;
        LaserDamageSource laserDmgSource = dmgSource as LaserDamageSource;
        atk.rangeMoving = data.RangeMove;
        atk.timeMove = data.TimeMove;
        laserDmgSource.maxDistance = data.BulletMaxDistance;
        laserDmgSource.speed = data.SpeedBullet;
    }
}
