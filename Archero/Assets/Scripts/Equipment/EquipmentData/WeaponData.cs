using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Weapon")]
public class WeaponData : EquipmentBaseData
{
    [SerializeField] protected float atk = 10;
    [SerializeField] protected float speedAtk = 1f;

    public WeaponData()
    {
        type = Type.WEAPON;
    }

    public float Atk { get => atk; }
    public float SpeedAtk { get => speedAtk; }

    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.weapon;
        if (curWeapon.Equipment != null)
        {
            WeaponData curData = curWeapon.Equipment as WeaponData;
            curData.UpdateRemoveCurrentEquipmentStatus();
        }
        EquipmentBaseData result = curWeapon.Equipment;
        
        curWeapon.Equipment = this;
        this.UpdateAddCurrentEquipmentStatus();

        return result;
    }
    public override void Affect(PlayerInfo player)
    {
        PlayerStyleAttack playerAttack = player.attackBase.CurAttackStyle as PlayerStyleAttack;
        playerAttack.atkPoint += atk;
        playerAttack.speed += speedAtk;
        
    }

    public override void Upgrade()
    {
        if (CoinSaveLoad.instance.coins < cost)
            return;
        base.Upgrade();
        this.UpdateRemoveCurrentEquipmentStatus();
        speedAtk += 0.25f;
        atk += 3;
        this.UpdateAddCurrentEquipmentStatus();
    }

    public override void UpdateAddCurrentEquipmentStatus()
    {
        CurrentEquipment.instance.AtkValue += this.atk;
        CurrentEquipment.instance.SpeedAtkValue += this.speedAtk;
    }

    public override void UpdateRemoveCurrentEquipmentStatus()
    {
        CurrentEquipment.instance.AtkValue -= this.atk;
        CurrentEquipment.instance.SpeedAtkValue -= this.speedAtk;
    }

}
