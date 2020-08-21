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
        BOUNCING,
        DAMAGE_PER_SECOND
    }

    protected Type type;
    public Sprite icon;
    //khong tuong minh

    public ItemBase(Sprite inIcon)
    {
        icon = inIcon;
    }

    public abstract void DoAffect();

    public bool Equals(ItemBase other)
    {
        if (type == other.type && icon == other.icon)
            return true;
        return false;
    }
}
