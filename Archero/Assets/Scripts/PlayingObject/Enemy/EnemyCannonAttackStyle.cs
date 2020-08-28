using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonAttackStyle : AttackStyleBase<ExplosionDamageSource>
{
    [SerializeField] float speed = 10f;
    protected Transform player;
    public override void OnEnable()
    {
        base.OnEnable();
        player = GameManager.instance.player.transform;
    }
    protected override void Attacking()
    {
        transform.LookAt(player);
        ExplosionDamageSource bullet = dmgPool.GetFromPool(dmgPrefab) as ExplosionDamageSource;
        bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
        bullet.bulletRig.velocity = speed * bullet.transform.forward;
        isAttack = false;
        //StartCoroutine(AttackAnimation());
    }
    // protected virtual IEnumerator AttackAnimation()
    //{
    //    //neu co animation thi them vao ben trong nay
    //    ExplosionDamageSource bullet = dmgPool.GetFromPool(dmgPrefab) as ExplosionDamageSource;
    //    bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
    //    bullet.bulletRig.velocity = speed * bullet.transform.forward;
    //    isAttack = false;
    //    yield break;
    //}
}
