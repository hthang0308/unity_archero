using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBaseData : ScriptableObject
{
    [HideInInspector] public int level = 1;
    [HideInInspector] public float cost = 2000;
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

    public virtual void Upgrade()
    {
        level++;
        cost += 1000;
    }

}
