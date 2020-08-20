using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Ring")]
public class RingData : EquipmentBaseData
{
    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.ring;
        curWeapon.icon.sprite = this.Icon;
        EquipmentBaseData result = curWeapon.equipment;
        curWeapon.equipment = this;
        return result;
    }
}
