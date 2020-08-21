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
        PlayerStyleAttack playerAttack = GameManager.instance.player.attackBase.CurAttackStyle as PlayerStyleAttack;
        playerAttack.penetrate = true;
    }

    
}
