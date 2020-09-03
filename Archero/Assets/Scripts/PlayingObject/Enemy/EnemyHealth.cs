using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private ExperiencePoint playerExp;
    public int expOnDeath = 3;
    [SerializeField] protected LivingObjectInfo enemyInfo;

    protected override void OnEnable()
    {
        base.OnEnable();
        playerExp = GameManager.instance.player.experience;
    }
    protected override void OnDeath()
    {
        GoldCoinPool.instance.UseCoin(transform.position, expOnDeath);
        GameManager.instance.RemoveEnemy(enemyInfo);
        base.OnDeath();
    }
}
