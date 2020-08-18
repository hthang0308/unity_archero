using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : BaseMonoBehaviour
{
    [SerializeField] protected HealthBarUI healthBarUI;

    protected float hP;
    [SerializeField] protected float maxHP = 100f;

    protected float shield;
    [HideInInspector] public bool isDead = false;
    protected virtual void OnEnable()
    {
        hP = maxHP;
        healthBarUI.SetHealthUI(hP / maxHP);
    }
    //protected void Awake()
    //{
    //    hP = maxHP;
    //    healthBarUI.SetHealthUI(hP/maxHP);
    //}

    public void TakeDmage(float dmg)
    {
        //there is a shield
        if (shield > 0f)
        {
            if (shield >= dmg)
                shield -= dmg;
            else
            { 
                //shield is broken
                dmg -= shield;
                shield = 0;
                hP -= dmg;
            }
        }
        else hP -= dmg;
        healthBarUI.SetHealthUI(hP / maxHP);
        if ((hP <= 0)&&(!isDead))
            OnDeath();
        Debug.Log(hP);
    }

    protected virtual void OnDeath()
    {
        isDead = true;
        gameObject.SetActive(false);
    }

    

}
