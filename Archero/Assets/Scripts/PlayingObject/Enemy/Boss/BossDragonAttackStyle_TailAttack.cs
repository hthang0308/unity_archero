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
    int countAttack = 0;
    int attackPerTime = 3;
    public override void OnEnable()
    {
        base.OnEnable();
        hashState = AnimatorParameters.state_attackType2_ID;
        explosion = Instantiate(explosionPrefab);
        explosion.SetUp(atkPoint, radiusExplosion);
        state.Attack2 = 1;
    }
    protected override void Attacking()
    {
        StartCoroutine(AttackAnimation());
        countAttack++;
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
        if (countAttack == attackPerTime)
        {
            countAttack = 0;
            state.Attack1 = false;
            this.enabled = false;
        }
    }

    //IEnumerator RunningAnimation()
    //{
    //    yield return new WaitUntil(() =>  isMoving == false);
    //}
}