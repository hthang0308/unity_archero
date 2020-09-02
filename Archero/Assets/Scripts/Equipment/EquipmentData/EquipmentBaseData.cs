using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBaseData : ScriptableObject
{
    [Serializable]
    public enum Type
    {
        NONE, CLOTH, RING, SPIRIT, WEAPON
    }

    public EquipmentBaseData()
    {
        type = Type.NONE;
    }

    public Type type;
    [SerializeField] private Sprite icon;

    public Sprite Icon { get => icon; }

    public virtual EquipmentBaseData Equip()
    {
        return null;
    }

    public virtual void Affect(PlayerInfo player)
    {

    }

    public virtual void WrapData(EquipmentDataWrapper wrapper)
    {
        wrapper.equipments.Add(this);
    }

}
