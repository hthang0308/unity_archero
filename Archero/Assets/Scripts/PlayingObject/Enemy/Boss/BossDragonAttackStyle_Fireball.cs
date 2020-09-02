using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragonAttackStyle_Fireball : AttackStyleBase<FireballDamageSource>
{
    protected Transform player;
    [SerializeField] EnemyState state;
    [Header("Fireball Set Up")]
    [SerializeField] protected float[] angle;
    [SerializeField] float distance = 10f;
    [SerializeField] float speed = 10f;
    protected int hashState;


    int countAttack=0;
    public int attackPerTime = 3;
    public override void Awake()
    {
        dmgPrefab.SetUp(distance, speed, atkPoint, effectDatas);
        base.Awake();
    }
    public override void OnEnable()
    {
        base.OnEnable();
        player = GameManager.instance.player.transform;
        hashState = AnimatorParameters.state_attackType1_ID;
    }
    public override void UpdateNormal()
    {
        base.UpdateNormal();
        transform.LookAt(player);
    }
    protected override void Attacking()
    {
        StartCoroutine(AttackAnimation());
        countAttack++;
        isAttack = false;
    }
    protected IEnumerator AttackAnimation()
    {
        state.Attack1 = true;
        state.animator.CrossFadeInFixedTime(hashState, 0);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < angle.Length; i++)
        {
            FireballDamageSource bullet = dmgPool.GetFromPool(dmgPrefab);
            bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation * Quaternion.Euler(new Vector3(0, angle[i], 0)));
            bullet.Direction = bullet.transform.forward;
        }
        yield return new WaitForSeconds(0.5f);
        state.Attack1 = false;
        if (countAttack == attackPerTime)
        {
            countAttack = 0;
            this.enabled = false;
        }
    }
}