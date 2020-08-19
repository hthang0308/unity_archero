using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingItem : ItemBase
{
    public BouncingItem(Sprite inIcon) : base(inIcon)
    {
        type = Type.BOUNCING;
    }

    public override void DoAffect()
    {
        playerAttack.bouncingWall = true;
    }

    
}
