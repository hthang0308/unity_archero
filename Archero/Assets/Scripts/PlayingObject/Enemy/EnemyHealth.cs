using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private ExperiencePoint playerExp;
    [SerializeField] protected int expOnDeath = 3;
    [SerializeField] protected LivingObjectInfo enemyInfo;

    protected override void OnEnable()
    {
        base.OnEnable();
        playerExp = GameManager.instance.player.experience;
    }
    //private void Update()
    //{
    //    TakeDmage(1f);
    //    Debug.Log("Current HP: " + hP);
    //}
    protected override void OnDeath()
    {
        GoldCoinPool.instance.UseCoin(transform.position, expOnDeath);
        GameManager.instance.RemoveEnemy(enemyInfo);
        base.OnDeath();
    }
}
