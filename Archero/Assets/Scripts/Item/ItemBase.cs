using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public abstract class ItemBase : IEquatable<ItemBase>
{
    public enum Type
    {
        FRONT_SHOT,
        DIAGONAL_SHOT,
        MULTI_SHOT,
        PIERCING_SHOT,
        BOUNCING
    }

    protected Type type;
    public Sprite icon;
    protected static PlayerAttack playerAttack;

    public ItemBase(Sprite inIcon)
    {
        if (playerAttack == null)
            playerAttack = GameManager.instance.player.attackControl.Attacks[0] as PlayerAttack;
        icon = inIcon;
    }

    public abstract void DoAffect();

    public bool Equals(ItemBase other)
    {
        if (type == other.type)
            return true;
        return false;
    }
}
