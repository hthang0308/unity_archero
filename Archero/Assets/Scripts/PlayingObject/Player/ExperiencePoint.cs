using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperiencePoint : BaseMonoBehaviour
{
    [HideInInspector] public float exp = 0f;
    [SerializeField] public float levelExp = 30f;
    [SerializeField] protected GameObject slotMachine;
    [SerializeField] protected Slider expBar;
    protected float barVelocity;

    public override void Awake()
    {
        base.Awake();
        expBar.maxValue = levelExp;
    }

    public void AddExp(float expPoint)
    {
        exp += expPoint;
        
    }

    public override void UpdateFixed()
    {
        expBar.value = Mathf.SmoothDamp(expBar.value, exp, ref barVelocity, 0.01f);
        while (levelExp <= exp)
        {
            //level up
            exp -= levelExp;
            slotMachine.SetActive(true);
            expBar.value = exp;
        }
    }
}
