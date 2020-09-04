using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Cloth")]
public class ClothData : EquipmentBaseData
{
    [SerializeField] protected int hP = 10;
    [SerializeField] protected float speed = 1f;

    public int HP { get => hP; }
    public float Speed { get => speed; }

    public ClothData()
    {
        type = Type.CLOTH;
    }

    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.cloth;
        EquipmentBaseData result = curWeapon.Equipment;
        curWeapon.Equipment = this;
        return result;
    }

    public override void Affect(PlayerInfo player)
    {
        player.health.hP += hP;
        player.health.maxHP += hP;
        player.movement.maxSpeed += speed;
    }

    public override void Upgrade()
    {
        base.Upgrade();
        speed += 0.25f;
        hP += 5;
    }

}
