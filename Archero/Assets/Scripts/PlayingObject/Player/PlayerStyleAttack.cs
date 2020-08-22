﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStyleAttack : AttackStyleBase<ArrowDamageSource>
{
    [HideInInspector] public Transform enemyLookAt;
    [SerializeField] protected PlayerState playerAnimator;
    protected int hashState;

    [SerializeField] protected float startingDelay = 0.1f;
    protected float countDownStartingDelay;

    [SerializeField] protected float delayNextShot = 0.8f;
    protected float countDownDelayNextShot;

    [SerializeField] public int numberShots = 1; 
    protected int countDownNumberShots;

    //Front
    [SerializeField] public int frontShot = 1;
    [SerializeField] protected float frontShotDeltaPos = 5f;

    //Diagonal
    [SerializeField] public int diagonalShot = 0;
    [SerializeField] protected float diagonalShotAngle = 10f;

    //Arrow Set Up
    [Header("Arrow Set Up")]
    [Space(20)]
    [SerializeField] public float atkPoint = 10f;
    [SerializeField] public float distance = 20f;
    [SerializeField] public float speed = 0.8f;
    [SerializeField] public bool penetrate = false;
    [SerializeField] public bool bouncingWall = true;
    [HideInInspector] public List<EffectBaseData> effectDatas = new List<EffectBaseData>();


    public override void OnEnable()
    {
        base.OnEnable();
        countDownStartingDelay = startingDelay;
        countDownDelayNextShot = 0f;
        countDownNumberShots = numberShots;
        if (numberShots == 1)
        {
            hashState = AnimatorParameters.state_singleShotID;
            playerAnimator.IsMultiShot = false;
        }

        else
        {
            hashState = AnimatorParameters.state_multiShotID;
            playerAnimator.IsMultiShot = true;
        }
    }

    public override void UpdateNormal()
    {
        //Look at rotation
        Vector3 rotationLookAt = enemyLookAt.position - transform.position;
        rotationLookAt.y = 0;
        transform.rotation = Quaternion.LookRotation(rotationLookAt, Vector3.up);


        //Attacking
        if (isAttack)
            Attacking();
        else
        {
            countDownDelayNextAttack -= Time.deltaTime;
            if (countDownDelayNextAttack <= 0f)
            {
                isAttack = true;
                countDownDelayNextAttack = delayNextAttack;
                playerAnimator.animator.CrossFadeInFixedTime(hashState, 0);
            }
        }
    }

    protected override void Attacking()
    {
        if (countDownStartingDelay - Time.deltaTime > 0f)
        {
            countDownStartingDelay -= Time.deltaTime;
            return;
        }
        if (countDownDelayNextShot - Time.deltaTime > 0f)
        {
            countDownDelayNextShot -= Time.deltaTime;
            return;
        }

        FrontShoot();
        DiagonalShoot();


        countDownNumberShots--;
        if (countDownNumberShots == 0)
        {
            isAttack = false;
            countDownDelayNextShot = 0;
            countDownNumberShots = numberShots;
            countDownStartingDelay = startingDelay;
        }
        else
        {
            countDownDelayNextShot = delayNextShot;
            

        }
    }

    protected void DiagonalShoot()
    {
        if (diagonalShot == 0)
            return;
        Vector3 rotation = fireTransform.forward;
        for (int i = 1; i<=diagonalShot; i++)
        {
            ArrowDamageSource arrow = dmgPool.GetFromPool(dmgPrefab);
            arrow.transform.SetPositionAndRotation(fireTransform.position, 
                fireTransform.rotation);
            arrow.SetUpArrow(Quaternion.AngleAxis(diagonalShotAngle * i, Vector3.up) * rotation,
                distance, speed, penetrate, bouncingWall, effectDatas, atkPoint);

            arrow = dmgPool.GetFromPool(dmgPrefab);
            arrow.transform.SetPositionAndRotation(fireTransform.position, 
                fireTransform.rotation);
            arrow.SetUpArrow(Quaternion.AngleAxis(-diagonalShotAngle * i, Vector3.up) * rotation,
                distance, speed, penetrate, bouncingWall, effectDatas, atkPoint);
        }
    }

    protected void FrontShoot()
    {
        Vector3 tmpPos = fireTransform.position;
        Vector3 xDirection = fireTransform.right;

        tmpPos -= (xDirection * frontShotDeltaPos * (frontShot - 1)) / 2f;
        for (int i=0; i<frontShot; i++)
        {
            ArrowDamageSource arrow = dmgPool.GetFromPool(dmgPrefab);
            arrow.transform.SetPositionAndRotation(tmpPos, fireTransform.rotation);
            arrow.SetUpArrow(fireTransform.forward, distance, speed, penetrate, bouncingWall, effectDatas, atkPoint);
            tmpPos += xDirection * frontShotDeltaPos;
        }
    }
}