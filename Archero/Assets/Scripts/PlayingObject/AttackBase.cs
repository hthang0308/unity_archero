using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : BaseMonoBehaviour
{
    [SerializeField] protected AttackStyleBase curAttackStyle;
    private bool attacking = false;

    public bool Attacking
    {
        get => attacking;
        set
        {
            if (attacking == value)
                return;
            curAttackStyle.enabled = value;
            attacking = value;
        }
    }

    public AttackStyleBase CurAttackStyle
    {
        get => curAttackStyle;
        set
        {
            Attacking = false;
            curAttackStyle = value;
        }
    }

    public override void UpdateNormal()
    {
        //Switch

        //curAtk.attack
    }
}
