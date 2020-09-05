using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private void OnEnable()
    {
        if (weapon.Equipment != null)
            weapon.Equipment.UpdateAddCurrentEquipmentStatus();
        if (cloth.Equipment != null)
            cloth.Equipment.UpdateAddCurrentEquipmentStatus();
        if (ring.Equipment != null)
            ring.Equipment.UpdateAddCurrentEquipmentStatus();
        if (spirit.Equipment != null)
            spirit.Equipment.UpdateAddCurrentEquipmentStatus();
    }

    public EquipmentSlot weapon;
    public EquipmentSlot cloth;
    public EquipmentSlot ring;
    public EquipmentSlot spirit;

    public TextMeshProUGUI atkText;
    public TextMeshProUGUI speedAtkText;
    public TextMeshProUGUI hPText;
    public TextMeshProUGUI speedText;

    [HideInInspector] public float atkValue;
    [HideInInspector] public float speedAtkValue;
    [HideInInspector] public float hPValue;
    [HideInInspector] public float speedValue;

    public float AtkValue
    {
        get => atkValue;
        set
        {
            atkValue = value;
            atkText.text = "Atk: <color=green>+" + atkValue.ToString() + "</color> ";
        }
    }
    public float SpeedAtkValue
    {
        get => speedAtkValue; 
        set
        {
            speedAtkValue = value;
            speedAtkText.text = "SpeedAtk: <color=green>+" + speedAtkValue.ToString() + "</color> ";
        }
    }
    public float HPValue
    {
        get => hPValue; 
        set
        {
            hPValue = value;
            hPText.text = "HP: <color=green>+" + hPValue.ToString() + "</color> ";
        }
    }
    public float SpeedValue
    {
        get => speedValue; set
        {
            speedValue = value;
            speedText.text = "Speed: <color=green>+" + speedValue.ToString() + "</color> ";
        }
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
