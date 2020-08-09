using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSourceBase : BaseMonoBehaviour
{
    public float atkPoint = 10f;
    public List<EffectBase> effects;
    
    protected virtual void DoDamage(LivingObjectInfo targetInfo) //missing PlayingObjectInfo
    {
        targetInfo.health.TakeDmage(atkPoint);
        Status targetStatus = targetInfo.status;
        for (int i = 0; i < effects.Count; i++)
            targetStatus.AddEffect(effects[i]);
    }

    public void AddEffect(EffectBase effect)
    {
        //Add Effect to the dmgSource, not the Object
        effects.Add(effect);
    }
}
