using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Weapon")]
public class WeaponData : EquipmentBaseData
{
    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.weapon;
        curWeapon.icon.sprite = this.Icon;
        EquipmentBaseData result = curWeapon.equipment;
        curWeapon.equipment = this;
        return result;
    }
}
