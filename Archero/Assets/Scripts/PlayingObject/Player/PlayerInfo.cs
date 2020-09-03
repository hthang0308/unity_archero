using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : LivingObjectInfo
{
    public ExperiencePoint experience;
    public Money money;

    public override void Awake()
    {
        //base.Awake();
        UpdateManager.AddBehaviour(this);
        id = 0;
        SetUp();
    }
    public override void SetUp()
    {
        PlayerData data = database as PlayerData;
        PlayerStyleAttack atk = attackBase.CurAttackStyle as PlayerStyleAttack;
        experience.levelExp = data.ExpLvUp;
        atk.startingDelay = data.StartingDelay;
        atk.numberShots = data.NumberShots;
        atk.frontShot = data.FrontShot;
        atk.frontShotDeltaPos = data.FrontShotDeltaPos;
        atk.diagonalShot = data.DiagonalShot;
        atk.diagonalShotAngle = data.DiagonalShotAngle;
        atk.distance = data.Distance;
        //
        health.maxHP = data.MaxHP;
        health.hP = health.maxHP;
        atk.delayNextAttack = data.DelayNextAttack;
        atk.speed = data.SpeedBullet;
        atk.atkPoint = data.AtkPoint;
        movement.maxSpeed = data.Speed;
    }

}
