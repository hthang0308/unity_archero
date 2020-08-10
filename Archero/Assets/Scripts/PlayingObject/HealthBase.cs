using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : BaseMonoBehaviour
{
    [SerializeField] protected float hP;
    protected float shield;

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
    }

}
