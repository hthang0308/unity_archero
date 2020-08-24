using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackStyle : AttackStyleBase<DamageSourceBase>
{
    float speed = 10f;
    protected Transform player;
    protected bool lookAtPlayer = false;
    public override void OnEnable()
    {
        base.OnEnable();
        player = GameManager.instance.player.transform;
        countDownDelayNextAttack = delayNextAttack;
    }
    public override void UpdateNormal()
    {
        base.UpdateNormal();
        if (lookAtPlayer)
            transform.LookAt(player);
    }
    protected override void Attacking()
    {
        StartCoroutine(AttackAnimation());
        lookAtPlayer = true;
        IsAttack = false;
    }
     protected virtual IEnumerator AttackAnimation()
    {
        ExplosionDamageSource bullet = dmgPool.GetFromPool(dmgPrefab) as ExplosionDamageSource;
        bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
        bullet.bulletRig.velocity = speed * bullet.transform.forward;
        yield break;
    }
}
