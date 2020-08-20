using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSourceBase : BaseMonoBehaviour
{
    protected int layerToIgnore = 0;
    public float atkPoint = 10f;
    [HideInInspector] public List<EffectBaseData> effectDatas = new List<EffectBaseData>();


    public override void Awake()
    {
        base.Awake();
        int curLayer = gameObject.layer;
        for (int i = 0; i < 32; i++)
            if (Physics.GetIgnoreLayerCollision(curLayer, i))
                layerToIgnore |= (1 << i);
    }

    protected virtual void DoDamage(LivingObjectInfo targetInfo)
    {
        targetInfo.health.TakeDmage(atkPoint);
        Status targetStatus = targetInfo.status;
        for (int i = 0; i < effectDatas.Count; i++)
            targetStatus.AddEffect(effectDatas[i].CreateEffect());
    }

    //public void AddEffect(EffectBaseData effect)
    //{
    //    //Add Effect to the dmgSource, not the Object
    //    effectDatas.Add(effect);
    //}
}
