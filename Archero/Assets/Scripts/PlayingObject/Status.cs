using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : BaseMonoBehaviour
{
    [HideInInspector] public List<EffectBase> effects = new List<EffectBase>();
    [SerializeField] protected LivingObjectInfo objectInfo;

    public override void UpdateNormal()
    {
        int i = 0;
        while (i<effects.Count)
        {
            effects[i].OnUpdateNormal(Time.deltaTime, objectInfo);
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
        if (effect.OnEnable(objectInfo))
            effects.Add(effect);
    }

    public void RemoveEffect(EffectBase effect)
    {
        effect.OnDisable(objectInfo);
        effects.Remove(effect);
    }

}
