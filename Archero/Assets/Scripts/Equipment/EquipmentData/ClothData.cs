using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Cloth")]
public class ClothData : EquipmentBaseData
{
    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.cloth;
        curWeapon.icon.sprite = this.Icon;
        EquipmentBaseData result = curWeapon.equipment;
        curWeapon.equipment = this;
        return result;
    }
}
