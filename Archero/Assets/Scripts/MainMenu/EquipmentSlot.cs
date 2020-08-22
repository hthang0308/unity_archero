using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    public EquipmentBaseData equipment;

    public void Awake()
    {
        if (equipment != null)
            icon.sprite = equipment.Icon;
    }

    public void OnClickToAddButton()
    {
        equipment = equipment.Equip();
        if (equipment == null)
            Destroy(gameObject);
        else icon.sprite = equipment.Icon;
    }

    public void OnClickToRemoveButton()
    {
        if (equipment == null)
            return;
        EquipmentSlot tmpSlot = Instantiate(CurrentEquipment.instance.buttonPrefab);
        tmpSlot.equipment = equipment;
        tmpSlot.icon.sprite = equipment.Icon;
        tmpSlot.transform.SetParent(CurrentEquipment.instance.inventory.transform, false);
        icon.sprite = null;
        equipment = null;

    }
}
