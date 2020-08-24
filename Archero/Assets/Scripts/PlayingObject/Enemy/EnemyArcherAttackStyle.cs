using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherAttackStyle : EnemyAttackStyle
{
    [SerializeField]
    EnemyArcherMoving moving;
    protected override bool IsAttack
    {
        get => base.IsAttack;
        set
        {
            if (value==false)
            {
                base.IsAttack = false;
            }
            else
            {
                base.IsAttack = true;
                moving.IsMoving = false;
            }

        }
    }
    protected override IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.6f);
        LaserDamageSource bullet = dmgPool.GetFromPool(dmgPrefab) as LaserDamageSource;
        bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
        bullet.Direction = fireTransform.forward;
        yield return new WaitForSeconds(0.6f);
        lookAtPlayer = false;
        moving.IsMoving = true;
        moving.findAreaToShoot = true;
    }
}