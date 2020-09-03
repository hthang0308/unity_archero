using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    protected override void OnDeath()
    {
        base.OnDeath();
        MapManager.instance.LosePanel();
    }
    public override void TakeDmage(float dmg)
    {
        base.TakeDmage(dmg);
        Debug.Log(hP + "   " + maxHP);
    }
}
