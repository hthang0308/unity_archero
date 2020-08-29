using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : BaseMonoBehaviour
{
    [HideInInspector] public int moneyValue = 0;
    [SerializeField] protected TextMeshProUGUI moneyBar;
    //protected float barVelocity;

    public override void Awake()
    {
        base.Awake();
        moneyBar.text = "0";
    }
    public void AddGold(int moneyAdd)
    {
        moneyValue += moneyAdd;
        moneyBar.text = moneyValue.ToString();
    }

    //public override void UpdateFixed()
    //{
    //    expBar.value = Mathf.SmoothDamp(expBar.value, moneyStart, ref barVelocity, 0.01f);
    //    if (levelExp <= moneyStart)
    //    {
    //        //level up
    //        moneyStart -= levelExp;
    //        slotMachine.SetActive(true);
    //        expBar.value = moneyStart;
    //        levelExp *= 1.1f;
    //    }
    //}
    //public override void UpdateNormal()
    //{
    //    if (moneyDisplay<money)
    //    {
    //        moneyDisplay++;
    //        moneyBar.text = moneyDisplay.ToString();
    //    }
    //}
}
