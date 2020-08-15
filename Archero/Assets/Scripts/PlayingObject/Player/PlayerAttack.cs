using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackBase<ArrowDamageSource>
{
    [SerializeField] protected float delayNextShot = 0.8f;
    protected float countDowndelayNextShot;

    [SerializeField] protected int numberShots = 1; //remove serialize field after debug
    protected int countDownNumberShots;

    //Arrow Set Up
    [Header("Arrow Set Up")] [Space(20)]
    [SerializeField] protected float distance = 20f;
    [SerializeField] protected float speed = 0.8f;
    [SerializeField] protected bool penetrate = false;
    [SerializeField] protected bool bouncingWall = true;

    public override void OnEnable()
    {
        base.OnEnable();
        countDowndelayNextShot = 0;
        countDownNumberShots = numberShots;
    }

    protected override void Attacking()
    {
        countDowndelayNextShot -= Time.deltaTime;
        if (countDowndelayNextShot <= 0f)
        {
            ArrowDamageSource arrow = dmgPool.GetFromPool(dmgPrefab);
            arrow.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
            arrow.SetUpArrow(fireTransform.forward, distance, speed, penetrate, bouncingWall);

            countDownNumberShots--;
            if (countDownNumberShots == 0)
            {
                isAttack = false;
                countDowndelayNextShot = 0;
                countDownNumberShots = numberShots;
            }
            else
            {
                countDowndelayNextShot = delayNextShot;

            }
        }
    }

}
