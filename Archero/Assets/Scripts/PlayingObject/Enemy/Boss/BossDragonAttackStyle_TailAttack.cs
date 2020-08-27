using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragonAttackStyle_TailAttack : AttackStyleBase
{
    [SerializeField] EnemyState state;
    [SerializeField] BossMoving moving;
    public LayerMask playerMask;

    [SerializeField] ExplosionDamageSource explosionPrefab;

    [Header("Tail Attack Set Up")]
    [SerializeField] protected float[] angle;
    [SerializeField] float durationRunning = 0.5f;
    [SerializeField] float durationTailAttack = 0.5f;
    [SerializeField] float atkPoint = 10f;
    [SerializeField] float radiusExplosion = 2f;

    ExplosionDamageSource explosion;
    protected int hashState;
    public override void OnEnable()
    {
        base.OnEnable();
        hashState = AnimatorParameters.state_attackType2_ID;
        explosion = Instantiate(explosionPrefab);
        explosion.SetUp(atkPoint, radiusExplosion);
    }
    protected override void Attacking()
    {
        StartCoroutine(AttackAnimation());
        isAttack = false;
    }
    protected IEnumerator AttackAnimation()
    {
        state.animator.CrossFadeInFixedTime(hashState, 0);
        state.Attack2 = 1;
        yield return StartCoroutine(moving.SetDestination(durationRunning));
        state.Attack2 = 2;
        yield return new WaitForSeconds(durationTailAttack);
        explosion.transform.SetPositionAndRotation(transform.position, transform.rotation);
        explosion.gameObject.SetActive(true);
        explosion.CreateExplosion();
        //finish attack
        state.Attack2 = 0;
    }

    //IEnumerator RunningAnimation()
    //{
    //    yield return new WaitUntil(() =>  isMoving == false);
    //}
}