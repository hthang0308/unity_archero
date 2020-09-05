using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragonInfo : EnemyInfo
{
    public AttackControlBase atkControl;
    public DamageSourceBase dmgSource2;
    public override void SetUp()
    {
        base.SetUp();
        EnemyBossDragonData data = database as EnemyBossDragonData;
        BossDragonAttackStyle_Fireball atk1 = atkControl.attackStyles[0] as BossDragonAttackStyle_Fireball;
        BossDragonAttackStyle_TailAttack atk2 = atkControl.attackStyles[1] as BossDragonAttackStyle_TailAttack;
        FireballDamageSource dmg1 = dmgSource as FireballDamageSource;
        ExplosionDamageSource dmg2 = dmgSource2 as ExplosionDamageSource;
        atk1.attackPerTime = data.AttackPerTime1;
        dmg1.atkPoint = data.AtkPoint1;
        atk1.angle = data.Angle;
        dmg1.maxDistance = data.Distance;
        dmg1.speed = data.SpeedBullet;
        atk2.attackPerTime = data.AttackPerTime2;
        dmg2.atkPoint = data.AtkPoint2;
        dmg2.radiusExplosion = data.RadiusExplosion;
        atk2.durationRunning = data.DurationRunning;
        atk2.durationTailAttack = data.DurationTailAttack;
        atk1.delayNextAttack = data.DelayNextAttack1;
        atk2.delayNextAttack = data.DelayNextAttack2;
    }
}
