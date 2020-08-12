using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EffectBase : IEquatable<EffectBase>
{
    public const float FOREVER = 100000; //use for effect last forever

    public enum Type
    {
        DamagePerSecond,
        Heal
    }

    public enum Behavior
    {
        Normal, //add normally
        Replace, //replace the exist one with the new one
        Ignore //don't add the effect
    }

    //delay for next affect
    protected float delayPerAffect = 1f;
    protected float countDownDelayPerAffect;

    //duration of effect
    protected float duration = 6f;
    protected float countDownDuration;
    public bool deleted = false;

    protected Type type;
    protected Behavior behavior;

    #region constructor
    public EffectBase()
    {

    }

    public EffectBase(EffectBaseData data)
    {
        type = data.Type;
        behavior = data.Behavior;
        delayPerAffect = data.DelayPerAffect;
        duration = data.Duration;
    }
    #endregion

    //Need to call when is added
    public virtual bool OnEnable(LivingObjectInfo target)   //if can add this effect to the status list, return true
    {
        //set the countDown
        countDownDelayPerAffect = delayPerAffect;
        countDownDuration = duration;

        List<EffectBase> targetEffects = target.status.effects;

        switch (behavior)
        {
            case Behavior.Ignore:
                if (targetEffects.IndexOf(this) != -1)
                    break;
                return false;
            case Behavior.Normal:
                break;
            case Behavior.Replace:
                int tmp = targetEffects.IndexOf(this);
                if (tmp != -1)
                {
                    targetEffects[tmp] = this;
                    return false;
                }
                break;
            default:
                break;
        }

        return true;
    }

    //Need to call when is removed
    public virtual void OnDisable(LivingObjectInfo target)
    {
    }

    //Need to call in Update of Object had this effect
    public virtual void OnUpdateNormal(float time, LivingObjectInfo target)
    {
        //countDown the time and do Affect
        countDownDelayPerAffect -= time;
        countDownDuration -= time;
        if (countDownDelayPerAffect <= 0f)
        {
            countDownDelayPerAffect = delayPerAffect;
            DoAffect(target);
        }
        if (countDownDuration <= 0f)
            deleted = true;
    }

    protected virtual void DoAffect(LivingObjectInfo target)
    {

    }

    public bool Equals(EffectBase other)
    {
        if (type == other.type && behavior == other.behavior)
            return true;
        return false;
    }
}
