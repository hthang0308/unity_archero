using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Ring")]
public class RingData : EquipmentBaseData
{
    [SerializeField] protected int hP = 10;
    [SerializeField] protected float atk = 10;

    public RingData()
    {
        type = Type.RING;
    }

    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.ring;
        if (curWeapon.Equipment != null)
        {
            RingData curData = curWeapon.Equipment as RingData;
            curData.UpdateRemoveCurrentEquipmentStatus();
        }
        EquipmentBaseData result = curWeapon.Equipment;
        curWeapon.Equipment = this;
        this.UpdateAddCurrentEquipmentStatus();
        return result;
    }

    public override void Affect(PlayerInfo player)
    {
        base.Affect(player);
        PlayerStyleAttack playerAttack = player.attackBase.CurAttackStyle as PlayerStyleAttack;
        playerAttack.atkPoint += atk;
        player.health.hP += hP;
        player.health.maxHP += hP;
    }

    public override void Upgrade()
    {
        if (CoinSaveLoad.instance.coins < cost)
        {
            Debug.Log(true);
            return;
        }
        base.Upgrade();
        this.UpdateRemoveCurrentEquipmentStatus();
        hP += 3;
        atk += 3;
        this.UpdateAddCurrentEquipmentStatus();
    }
    public override void UpdateAddCurrentEquipmentStatus()
    {
        CurrentEquipment.instance.AtkValue += this.atk;
        CurrentEquipment.instance.HPValue += this.hP;
    }

    public override void UpdateRemoveCurrentEquipmentStatus()
    {
        CurrentEquipment.instance.AtkValue -= this.atk;
        CurrentEquipment.instance.HPValue -= this.hP;
    }
}
