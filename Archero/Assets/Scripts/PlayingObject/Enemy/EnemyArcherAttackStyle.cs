using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherAttackStyle : AttackStyleBase<LaserDamageSource>
{
    protected Transform player;
    bool lookAtPlayer = false;
    int countAttack = 0;
    [SerializeField] float timeMove = 3.5f;
    [SerializeField] EnemyArcherMoving moving;
    [SerializeField] EnemyState state;
    int attackPerTime = 3;
    [Header("Enemy Arrow Set Up")]
    [SerializeField] float distance = 10f;
    [SerializeField] float speed = 10f;
    [SerializeField] float atkPoint = 10f;
    [SerializeField] public List<EffectBaseData> effectDatas = new List<EffectBaseData>();
    protected int hashState;
    public override void Awake()
    {
        dmgPrefab.SetUp(distance, speed, atkPoint, effectDatas);
        base.Awake();
    }
    public override void OnEnable()
    {
        base.OnEnable();
        hashState = AnimatorParameters.state_attackType1_ID;
        player = GameManager.instance.player.transform;
    }
    public override void UpdateNormal()
    {
        base.UpdateNormal();
        if (lookAtPlayer)
            transform.LookAt(player);
    }
    protected override void Attacking()
    {
        if (countAttack==0)
            moving.IsMoving = false;
        countAttack++;
        StartCoroutine(AttackAnimation());
        isAttack = false;
    }
    protected IEnumerator AttackAnimation()
    {
        lookAtPlayer = true;
        state.Attack1 = true;
        state.animator.CrossFadeInFixedTime(hashState, 0);
        yield return new WaitForSeconds(0.5f);
        LaserDamageSource bullet = dmgPool.GetFromPool(dmgPrefab);
        bullet.transform.SetPositionAndRotation(fireTransform.position, fireTransform.rotation);
        bullet.Direction = bullet.transform.forward;
        yield return new WaitForSeconds(0.5f);
        lookAtPlayer = false;
        state.Attack1 = false;
        if (countAttack == attackPerTime)
        {
            countAttack = 0;
            countDownDelayNextAttack = timeMove;
            moving.IsMoving = true;
            moving.FindAreaToShoot();
        }
    }
}