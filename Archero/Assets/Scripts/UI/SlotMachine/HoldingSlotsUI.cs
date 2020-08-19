using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldingSlotsUI : BaseMonoBehaviour
{
    [SerializeField] protected List<ItemSlotUI> itemSlots;
    [SerializeField] protected List<Button> buttons;
    [SerializeField] protected GameObject joystickCanvas;
    

    public void OnEnable()
    {
        Time.timeScale = 0f;
        joystickCanvas.SetActive(false);
        ItemBase tmpItem = ItemManager.instance.GetItem();
        itemSlots[0].GetItem(tmpItem);
        itemSlots[itemSlots.Count-1].GetItem(tmpItem);


        for (int i = 1; i < itemSlots.Count - 1; i++)
        {
            itemSlots[i].GetItem(ItemManager.instance.GetItem());
            
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }

    }

    public void TurnOnButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
