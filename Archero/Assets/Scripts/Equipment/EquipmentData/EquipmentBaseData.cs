using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBaseData : ScriptableObject
{
    public int level = 1;
    public int cost = 2000;
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
        CoinSaveLoad.instance.coins -= cost;
        level++;
        cost += 500;
        CoinSaveLoad.instance.SaveCoinsData();
    }

    public virtual void UpdateAddCurrentEquipmentStatus()
    {

    }

    public virtual void UpdateRemoveCurrentEquipmentStatus()
    {

    }
}
