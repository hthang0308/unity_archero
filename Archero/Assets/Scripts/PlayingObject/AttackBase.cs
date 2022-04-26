using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : BaseMonoBehaviour
{
    protected bool canAttack = true;
    protected bool isAttack = false;
    [SerializeField] protected float delayNextAttack;
    protected float countDownDelayNextAttack;

    protected DamageSourceBase dmgSource;

    public void OnEnable()
    {
        //set countDown
        countDownDelayNextAttack = delayNextAttack;

    }

    public override void UpdateNormal()
    {
        //Attacking
        if (isAttack)
            Attacking();
        else if (!canAttack)
        {
            countDownDelayNextAttack -= Time.deltaTime;
            if (countDownDelayNextAttack <= 0f)
            {
                canAttack = true;
                countDownDelayNextAttack = delayNextAttack;
            }
        }
        
    }

    public virtual void Attack()
    {
        //Do Attack when called
        isAttack = true;
        canAttack = false;
    }

    protected virtual void Attacking()
    {
    }



}
