using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStyleBase : BaseMonoBehaviour
{
    protected bool isAttack = false;
    [SerializeField] protected float delayNextAttack = 3.0f;
    [SerializeField] protected Transform fireTransform;
    protected float countDownDelayNextAttack;

    public virtual void OnEnable()
    {
        //set countDown
        countDownDelayNextAttack = delayNextAttack;
        isAttack = true;

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
            }
        }

    }

    protected virtual void Attacking()
    {
        //when isAttack turn on --> attacking --> finished??? --> turn off
    }

}

public class AttackStyleBase<T> : AttackStyleBase where T:DamageSourceBase
{
    protected ObjectPooling<T> dmgPool = new ObjectPooling<T>();
    [SerializeField] protected T dmgPrefab;

    public override void Awake()
    {
        base.Awake();
        dmgPool.GrowPool(dmgPrefab, 5);
    }

    public override void UpdateFixed()
    {
        dmgPool.UpdateFixed();
    }

}
