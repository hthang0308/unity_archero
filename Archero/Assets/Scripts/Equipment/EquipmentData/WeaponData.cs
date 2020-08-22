using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Weapon")]
public class WeaponData : EquipmentBaseData
{
    [SerializeField] protected float atk = 10;
    [SerializeField] protected float speedAtk = 1f;

    public float Atk { get => atk; }
    public float SpeedAtk { get => speedAtk; }

    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.weapon;
        curWeapon.icon.sprite = this.Icon;
        EquipmentBaseData result = curWeapon.equipment;
        curWeapon.equipment = this;
        return result;
    }
    public override void Affect(PlayerInfo player)
    {
        PlayerStyleAttack playerAttack = player.attackBase.CurAttackStyle as PlayerStyleAttack;
        playerAttack.atkPoint += atk;
        playerAttack.speed += speedAtk;
        
    }
}
