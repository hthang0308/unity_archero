using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private ExperiencePoint playerExp;
    private float expOnDeath=0f;
    protected override void OnEnable()
    {
        base.OnEnable();
        playerExp = GameManager.instance.player.experience;
        expOnDeath = 15f;
    }
    //private void Update()
    //{
    //    TakeDmage(1f);
    //    Debug.Log("Current HP: " + hP);
    //}
    protected override void OnDeath()
    {
        playerExp.exp += expOnDeath;
        //Debug.Log("Exp Giving: " + expOnDeath);
        //Debug.Log("Player Exp: " + playerExp.exp);
        base.OnDeath();
    }
}
