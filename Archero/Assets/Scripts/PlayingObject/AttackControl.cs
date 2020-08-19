using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : BaseMonoBehaviour
{
    [SerializeField] protected List<AttackBase> attacks;
    protected AttackBase curAttack;
    [HideInInspector] private int switchAttack = -1;

    public int SwitchAttack { get => switchAttack;
        set
        {
            if (switchAttack == value)
                return;
            if (switchAttack != -1)
                curAttack.enabled = false;
            if (value != -1)
            {
                curAttack = attacks[value];
                curAttack.enabled = true;
            }
            switchAttack = value;
        }
    }

    public List<AttackBase> Attacks { get => attacks;}

    public override void UpdateNormal()
    {
        //Switch

        //curAtk.attack
    }
}
