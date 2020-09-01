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
        EquipmentBaseData result = curWeapon.Equipment;
        curWeapon.Equipment = this;
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

}
