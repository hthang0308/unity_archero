using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEquipment : MonoBehaviour
{
    public static CurrentEquipment instance;
    public GameObject inventory;
    public EquipmentSlot buttonPrefab;
    public GameObject parentGameObject;

    public CurrentEquipment()
    {
        if (instance == null)
            instance = this;
    }

    public EquipmentSlot weapon;
    public EquipmentSlot cloth;
    public EquipmentSlot ring;
    public EquipmentSlot spirit;

    void Update()
    {
        
    }

    public void WrapEquipment(EquipmentDataWrapper data)
    {
        if (weapon.Equipment == null)
        {
            AddNullEquipment(data);
        }
        else weapon.Equipment.WrapData(data);

        if (cloth.Equipment == null)
        {
            AddNullEquipment(data);
        }
        else cloth.Equipment.WrapData(data);

        if (ring.Equipment == null)
        {
            AddNullEquipment(data);
        }
        else ring.Equipment.WrapData(data);

        if (spirit.Equipment == null)
        {
            AddNullEquipment(data);
        }
        else spirit.Equipment.WrapData(data);
    }

    private static void AddNullEquipment(EquipmentDataWrapper data)
    {
        EquipmentBaseData tmp = ScriptableObject.CreateInstance<EquipmentBaseData>();
        tmp.WrapData(data);
    }

    public void UnWrapEquipment(EquipmentDataWrapper data)
    {
        if (data.equipments[0] != null)
            weapon.Equipment = data.equipments[0];
        else weapon.Equipment = null;

        if (data.equipments[1] != null)
            cloth.Equipment = data.equipments[1];
        else cloth.Equipment = null;

        if (data.equipments[2] != null)
            ring.Equipment = data.equipments[2];
        else ring.Equipment = null;

        if (data.equipments[3] != null)
            spirit.Equipment = data.equipments[3];
        else spirit.Equipment = null;
    }

    

}
