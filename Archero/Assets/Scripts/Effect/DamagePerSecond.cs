using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerSecond : EffectBase
{
    protected float damage;
    //bool first;
    public DamagePerSecond(DamagePerSecondData data) : base(data as EffectBaseData)
    {
        damage = data.Damage;
        //particle = GameObject.Instantiate(data.Particle);
        //first = true;
    }
    public override void FirstAffect(LivingObjectInfo target)
    {
        particle = EffectParticleManager.instance.GetParticle(Type.DamagePerSecond);
        if (particle!=null)
        {
            particle.transform.position = target.transform.position + new Vector3(0, 0.5f, 0);
            particle.transform.parent = target.transform;
            particle.Play();
        }
    }

    protected override void DoAffect(LivingObjectInfo target)
    {
        target.health.TakeDmage(damage);
    }
    public override void OnDisable(LivingObjectInfo target)
    {
        if (particle!=null)
            particle.Stop();
    }
}
