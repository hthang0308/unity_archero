using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private ExperiencePoint playerExp = GameManager.instance.player.experience;
    private float expOnDeath=0f;
    //private void OnEnable()
    //{
    //    hP = 200f;
    //    expOnDeath = 15f;
    //}
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
