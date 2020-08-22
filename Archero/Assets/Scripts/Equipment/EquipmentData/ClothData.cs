using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Equipment Data/Cloth")]
public class ClothData : EquipmentBaseData
{
    [SerializeField] protected int hP = 10;
    [SerializeField] protected float speed = 1f;

    public int HP { get => hP; }
    public float Speed { get => speed; }

    public override EquipmentBaseData Equip()
    {
        EquipmentSlot curWeapon = CurrentEquipment.instance.cloth;
        curWeapon.icon.sprite = this.Icon;
        EquipmentBaseData result = curWeapon.equipment;
        curWeapon.equipment = this;
        return result;
    }

    public override void Affect(PlayerInfo player)
    {
        player.health.hP += hP;
        player.health.maxHP += hP;
        player.movement.maxSpeed += speed;
    }
}
