using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalShotItem : ItemBase
{
    public DiagonalShotItem(Sprite inIcon) : base(inIcon)
    {
        type = Type.DIAGONAL_SHOT;
    }

    public override void DoAffect()
    {
        playerAttack.diagonalShot++;
    }

    
}
