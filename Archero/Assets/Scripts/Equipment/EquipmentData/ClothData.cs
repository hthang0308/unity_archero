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
        if (curWeapon.Equipment != null)
        {
            ClothData curData = curWeapon.Equipment as ClothData;
            curData.UpdateRemoveCurrentEquipmentStatus();
        }
        EquipmentBaseData result = curWeapon.Equipment;
        curWeapon.Equipment = this;
        this.UpdateAddCurrentEquipmentStatus();
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
        if (CoinSaveLoad.instance.coins < cost)
        {
            Debug.Log(true);
            return;
        }
        base.Upgrade();
        this.UpdateRemoveCurrentEquipmentStatus();
        speed += 0.25f;
        hP += 5;
        this.UpdateAddCurrentEquipmentStatus();
    }
    public override void UpdateAddCurrentEquipmentStatus()
    {
        CurrentEquipment.instance.SpeedValue += this.speed;
        CurrentEquipment.instance.HPValue += this.hP;
    }

    public override void UpdateRemoveCurrentEquipmentStatus()
    {
        CurrentEquipment.instance.SpeedValue -= this.speed;
        CurrentEquipment.instance.HPValue -= this.hP;
    }

}
