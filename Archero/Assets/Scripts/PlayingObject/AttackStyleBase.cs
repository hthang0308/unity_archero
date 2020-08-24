using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStyleBase : BaseMonoBehaviour
{
    private bool isAttack=false;
    protected virtual bool IsAttack
    {
        get => isAttack;
        set => isAttack = value;
    }
    [SerializeField] protected float delayNextAttack = 3.0f;
    [SerializeField] protected Transform fireTransform;
    protected float countDownDelayNextAttack;

    public virtual void OnEnable()
    {
        //set countDown
        countDownDelayNextAttack = delayNextAttack;
        IsAttack = true;
    }

    public override void UpdateNormal()
    {
        //Attacking
        if (IsAttack)
            Attacking();
        else
        {
            countDownDelayNextAttack -= Time.deltaTime;
            if (countDownDelayNextAttack <= 0f)
            {
                IsAttack = true;
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
