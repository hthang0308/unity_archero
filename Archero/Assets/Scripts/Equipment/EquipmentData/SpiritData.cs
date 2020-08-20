using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Spirit")]
public class SpiritData : EquipmentBaseData
{
    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.spirit;
        curWeapon.icon.sprite = this.Icon;
        EquipmentBaseData result = curWeapon.equipment;
        curWeapon.equipment = this;
        return result;
    }
}
