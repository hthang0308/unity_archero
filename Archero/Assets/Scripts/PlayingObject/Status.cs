using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : BaseMonoBehaviour
{
    [HideInInspector] public List<EffectBase> effects = new List<EffectBase>();
    protected LivingObjectInfo objectInfo;

    public override void UpdateNormal()
    {
        int i = 0;
        while (i<effects.Count)
        {
            effects[i].UpdateNormal(Time.deltaTime, objectInfo);
            if (effects[i].deleted)
            {
                effects[i].OnDisable(objectInfo);
                effects.RemoveAt(i);
            }
            else i++;
        }
    }

    public void AddEffect(EffectBase effect)
    {
        effect.OnEnable(objectInfo);
        effects.Add(effect);
    }

    public void RemoveEffect(EffectBase effect)
    {
        effect.OnDisable(objectInfo);
        effects.Remove(effect);
    }

}
