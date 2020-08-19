using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingShotItem : ItemBase
{
    public PiercingShotItem(Sprite inIcon) : base(inIcon)
    {
        type = Type.PIERCING_SHOT;
    }

    public override void DoAffect()
    {
        playerAttack.penetrate = true;
    }

    
}
