using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI textBox;
    public Button buttonUpgrade;
    [SerializeField] protected EquipmentBaseData equipment;

    public EquipmentBaseData Equipment { get => equipment;
        set
        {
            equipment = value;
            if (equipment != null)
            {
                icon.sprite = equipment.Icon;
                textBox.text = "Lvl " + equipment.level;
                buttonUpgrade.gameObject.SetActive(true);
            }
            else
            {
                textBox.text = "";
                buttonUpgrade.gameObject.SetActive(false);
            }
        }
    }

    public void Awake()
    {
        if (Equipment != null)
            icon.sprite = Equipment.Icon;
        else
        {
            buttonUpgrade.gameObject.SetActive(false);
            textBox.text = "";
        }
    }

    public void OnClickToAddButton()
    {
        Equipment = Equipment.Equip();
        if (Equipment == null)
            Destroy(gameObject);
        else icon.sprite = Equipment.Icon;
    }

    public void OnClickToRemoveButton()
    {
        if (Equipment == null)
            return;
        equipment.UpdateRemoveCurrentEquipmentStatus();
        EquipmentSlot tmpSlot = Instantiate(CurrentEquipment.instance.buttonPrefab);
        tmpSlot.Equipment = Equipment;
        tmpSlot.icon.sprite = Equipment.Icon;
        tmpSlot.transform.SetParent(CurrentEquipment.instance.inventory.transform, false);
        icon.sprite = null;
        Equipment = null;

    }

    public void Upgrade()
    {
        equipment.Upgrade();
        textBox.text = "Lvl " + equipment.level;
    }
}
