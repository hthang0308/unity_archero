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

    public void OnClickButton()
    {
        equipment = equipment.Equip();
        if (equipment == null)
            Destroy(gameObject);
        else icon.sprite = equipment.Icon;
    }
}
