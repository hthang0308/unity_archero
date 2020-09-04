using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Spirit")]
public class SpiritData : EquipmentBaseData
{
    public SpiritData()
    {
        type = Type.SPIRIT;
    }

    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.spirit;
        EquipmentBaseData result = curWeapon.Equipment;
        curWeapon.Equipment = this;
        return result;
    }


}
