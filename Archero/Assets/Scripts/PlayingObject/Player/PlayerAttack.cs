using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackBase<ArrowDamageSource>
{
    [SerializeField] protected PlayerAnimator playerAnimator;
    protected int hashState;

    [SerializeField] protected float startingDelay = 0.1f;
    protected float countDownStartingDelay;

    [SerializeField] protected float delayNextShot = 0.8f;
    protected float countDownDelayNextShot;

    [SerializeField] protected int numberShots = 1; //remove serialize field after debug
    protected int countDownNumberShots;

    //Front
    [SerializeField] protected int frontShot = 1;
    [SerializeField] protected float frontShotDeltaPos = 5f;

    //Diagonal
    [SerializeField] protected int diagonalShot = 0;
    [SerializeField] protected float diagonalShotAngle = 10f;

    //Arrow Set Up
    [Header("Arrow Set Up")] [Space(20)]
    [SerializeField] protected float distance = 20f;
    [SerializeField] protected float speed = 0.8f;
    [SerializeField] protected bool penetrate = false;
    [SerializeField] protected bool bouncingWall = true;

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
        DiagonalShot();


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

    protected void DiagonalShot()
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
                distance, speed, penetrate, bouncingWall);

            arrow = dmgPool.GetFromPool(dmgPrefab);
            arrow.transform.SetPositionAndRotation(fireTransform.position, 
                fireTransform.rotation);
            arrow.SetUpArrow(Quaternion.AngleAxis(-diagonalShotAngle * i, Vector3.up) * rotation,
                distance, speed, penetrate, bouncingWall);
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
            arrow.SetUpArrow(fireTransform.forward, distance, speed, penetrate, bouncingWall);
            tmpPos += xDirection * frontShotDeltaPos;
        }
    }
}
