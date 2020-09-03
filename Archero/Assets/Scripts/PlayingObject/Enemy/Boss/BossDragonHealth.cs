using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragonHealth : EnemyHealth
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] AttackControlBase atkControl;
    public EnemyState state;
    public float minGetHit = 20f;
    public override void TakeDmage(float dmg)
    {
        base.TakeDmage(dmg);
        if (dmg > minGetHit)
        {
            state.IsGetHit = true;
            StartCoroutine(WaitForHitAnimation());
        }
            
    }
    protected override void OnDeath()
    {
        state.IsDead = true;
        StartCoroutine(WaitForDeathAnimation());
    }
    IEnumerator WaitForDeathAnimation()
    {
        boxCollider.enabled = false;
        atkControl.enabled = false;
        yield return new WaitForSeconds(0.5f);
        base.OnDeath();
    }
    IEnumerator WaitForHitAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        state.IsGetHit = false;
    }

}
