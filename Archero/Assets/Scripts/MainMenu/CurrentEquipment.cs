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
        //if (instance == null)
            instance = this;
    }

    public EquipmentSlot weapon;
    public EquipmentSlot cloth;
    public EquipmentSlot ring;
    public EquipmentSlot spirit;

    void Update()
    {
        
    }

}
