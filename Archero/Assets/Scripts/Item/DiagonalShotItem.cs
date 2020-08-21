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
        PlayerStyleAttack playerAttack = GameManager.instance.player.attackBase.CurAttackStyle as PlayerStyleAttack;
        playerAttack.diagonalShot++;
    }

    
}
