using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class EquipmentSaveLoadData : MonoBehaviour
{
    public GameObject inventorySlots;
    public EquipmentSlot equipmentButtonPrefab;
    string path;

    public List<EquipmentBaseData> defaultEquipments;

    private void Awake()
    {
        path = Application.persistentDataPath + "/SaveData";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        path += "/EquipmentData";
         
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //Load data
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(path + "/EquipmentSlot.dat"))
        {

            EquipmentDataWrapper data = new EquipmentDataWrapper();
            FileStream file = File.Open(path + "/EquipmentSlot.dat", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), data);
            file.Close();
            for (int i = 0; i < data.equipments.Count; i++)
            {
                EquipmentSlot slot = GameObject.Instantiate(equipmentButtonPrefab, inventorySlots.transform);
                slot.Equipment = data.equipments[i];
            }
        }
        else
        {
            for (int i = 0; i < defaultEquipments.Count; i++)
            {
                EquipmentSlot slot = GameObject.Instantiate(equipmentButtonPrefab, inventorySlots.transform);
                slot.Equipment = defaultEquipments[i];
            }
        }

        if (File.Exists(path + "/CurrentEquipment.dat"))
        {
            EquipmentDataWrapper data = new EquipmentDataWrapper();
            FileStream file = File.Open(path + "/CurrentEquipment.dat", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), data);
            file.Close();
            CurrentEquipment.instance.UnWrapEquipment(data);
        }
    }

    private void OnDisable()
    {
        EquipmentSlot [] slots = inventorySlots.GetComponentsInChildren<EquipmentSlot>();
        EquipmentDataWrapper equipmentData = new EquipmentDataWrapper();
        for (int i = 0; i<slots.Length; i++)
        {
            slots[i].Equipment.WrapData(equipmentData);
        }

        BinaryFormatter bf = new BinaryFormatter();
        string data;

        //equipments
        FileStream file = File.Create(path + "/EquipmentSlot.dat");
        data = JsonUtility.ToJson(equipmentData, true);
        bf.Serialize(file, data);
        file.Close();


        //currentEquipment
        equipmentData.equipments.Clear();
        CurrentEquipment.instance.WrapEquipment(equipmentData);

        file = File.Create(path + "/CurrentEquipment.dat");
        data = JsonUtility.ToJson(equipmentData, true);
        bf.Serialize(file, data);
        file.Close();


    }
}