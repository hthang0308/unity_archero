using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : BaseMonoBehaviour
{
    [SerializeField] LivingObjectInfo target;
    [SerializeField] EffectBaseData effectData;
    
    public void AddEffect()
    {
        DamagePerSecond tmp = new DamagePerSecond(effectData as DamagePerSecondData);
        target.status.AddEffect(tmp);
    }

}
