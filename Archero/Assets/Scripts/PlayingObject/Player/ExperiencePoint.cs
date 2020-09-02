using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperiencePoint : BaseMonoBehaviour
{
    [HideInInspector] public float exp = 0f;
    [SerializeField] public float levelExp = 40f;
    [SerializeField] protected GameObject slotMachine;
    [SerializeField] protected Slider expBar;

    [SerializeField] TextMeshProUGUI textUI;
    int level;
    protected float barVelocity;

    public override void Awake()
    {
        base.Awake();
        expBar.maxValue = levelExp;
        level = 1;
    }

    public void AddExp(float expPoint)
    {
        exp += expPoint;
    }

    public override void UpdateFixed()
    {
        expBar.value = Mathf.SmoothDamp(expBar.value, exp, ref barVelocity, 0.01f);
        if (levelExp <= exp)
        {
            //level up
            exp -= levelExp;
            slotMachine.SetActive(true);
            expBar.value = exp;
            levelExp *= 1.1f;

            level++;
            textUI.text = "Lv." + level;
        }
    }
}
