using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect Data/Effect Base")]
public class EffectBaseData : ScriptableObject
{
    [Header("Base Info")]
    [SerializeField] protected EffectBase.Type type;
    [SerializeField] protected EffectBase.Behavior behavior;
    [SerializeField] protected float delayPerAffect;
    [SerializeField] protected float duration;

    public EffectBase.Type Type { get => type; }
    public EffectBase.Behavior Behavior { get => behavior; }
    public float DelayPerAffect { get => delayPerAffect; }
    public float Duration { get => duration; }

    public virtual EffectBase CreateEffect()
    {
        return new EffectBase(this);
    }
}
