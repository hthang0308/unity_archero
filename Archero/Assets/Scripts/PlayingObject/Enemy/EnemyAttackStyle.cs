using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackStyle : AttackStyleBase<ExplosionDamageSource>
{
    float speed = 10f;
    Transform player;
    public override void OnEnable()
    {
        base.OnEnable();
        player = GameManager.instance.player.transform;
        countDownDelayNextAttack = delayNextAttack;
    }
    public override void UpdateNormal()
    {
        base.UpdateNormal();
        transform.LookAt(player);
    }
    protected override void Attacking()
    {
        ExplosionDamageSource bullet = dmgPool.GetFromPool(dmgPrefab);
        bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
        bullet.bulletRig.velocity = speed * bullet.transform.forward;
        isAttack = false;
    }
}
