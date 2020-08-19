using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotItem : ItemBase
{
    public MultiShotItem(Sprite inIcon) : base(inIcon)
    {
        type = Type.MULTI_SHOT;
    }

    public override void DoAffect()
    {
        playerAttack.numberShots++;
    }

    
}
