using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControlBase : BaseMonoBehaviour
{
    [SerializeField] protected AttackBase attackBase;
    [SerializeField] public List<AttackStyleBase> attackStyles;
    protected int index = -1;

    public override void UpdateNormal()
    {
        //switch index
        //attackBase.CurAttack = attacks[index];
    }
}
