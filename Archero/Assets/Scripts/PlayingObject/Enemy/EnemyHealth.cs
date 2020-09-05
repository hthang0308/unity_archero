using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private ExperiencePoint playerExp;
    public int expOnDeath = 3;
    public int goldEachExp = 100;
    [SerializeField] protected LivingObjectInfo enemyInfo;

    protected override void OnEnable()
    {
        base.OnEnable();
        playerExp = GameManager.instance.player.experience;
    }
    protected override void OnDeath()
    {
        GoldCoinPool.instance.UseCoin(transform.position, expOnDeath, goldEachExp);
        GameManager.instance.RemoveEnemy(enemyInfo);
        base.OnDeath();
    }
}
