using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EffectBase
{
    //proceed the Add & Remove Behavior
    //Compare for Remove (IEquatable)
    public const float FOREVER = 100000; //use for effect last forever

    public enum Type
    {
        DamagePerSecond,
        Heal
    }

    public enum Behavior
    {
        Add,
        Replace
    }

    //delay for next affect
    [SerializeField] protected float delayPerAffect = 1f;
    protected float countDownDelayPerAffect;

    //duration of effect
    [SerializeField] protected float duration = 6f;
    protected float countDownDuration;
    public bool deleted = false;

    protected Type type;
    protected Behavior behavior;

    //Need to call when is added
    public virtual void OnEnable(LivingObjectInfo target)
    {
        //set the countDown
        countDownDelayPerAffect = delayPerAffect;
        countDownDuration = duration;
    }

    //Need to call when is removed
    public virtual void OnDisable(LivingObjectInfo target)
    {
    }

    //Need to call in Update of Object had this effect
    public void OnUpdateNormal(float time, LivingObjectInfo target)
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

    protected void DoAffect(LivingObjectInfo target)
    {

    }

}
