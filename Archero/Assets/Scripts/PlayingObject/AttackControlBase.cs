using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControlBase : BaseMonoBehaviour
{
    [SerializeField] protected AttackBase attackBase;
    [SerializeField] protected List<AttackStyleBase> attackStyles;
    protected int index = 0;

    public override void UpdateNormal()
    {
        //switch index
        //attackBase.CurAttack = attacks[index];
    }
}
