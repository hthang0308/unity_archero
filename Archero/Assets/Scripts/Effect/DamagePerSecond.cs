using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerSecond : EffectBase
{
    protected float damage;

    public DamagePerSecond(DamagePerSecondData data) : base(data as EffectBaseData)
    {
        damage = data.Damage;
    }

    protected override void DoAffect(LivingObjectInfo target)
    {
        target.health.TakeDmage(damage);
    }
}
