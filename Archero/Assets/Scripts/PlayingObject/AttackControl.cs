using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : BaseMonoBehaviour
{
    [SerializeField] protected List<AttackBase> attacks;
    protected AttackBase curAttack;
    [HideInInspector] public int switchAttack = 0;

    public void Start()
    {
        curAttack = attacks[0];
    }

    public override void UpdateNormal()
    {
    }
}
