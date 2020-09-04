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
        EquipmentBaseData result = curWeapon.Equipment;
        curWeapon.Equipment = this;
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
        speedAtk += 0.25f;
        atk += 3;
    }

}
