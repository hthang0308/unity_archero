using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBaseData : ScriptableObject
{
    [SerializeField] private Sprite icon;

    public Sprite Icon { get => icon; }

    public virtual EquipmentBaseData Equip()
    {
        return null;
    }

    public virtual void Affect(PlayerInfo player)
    {

    }
}
