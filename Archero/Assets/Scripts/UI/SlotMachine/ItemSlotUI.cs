using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : BaseMonoBehaviour
{
    protected ItemBase item;
    [SerializeField] protected Image icon;
    [SerializeField] protected GameObject slotingCanvas;
    [SerializeField] protected GameObject joystickCanvas;

    public void GetItem(ItemBase inItem)
    {
        item = inItem;
        icon.sprite = item.icon;
    }

    public void OnClick()
    {
        item.DoAffect();
        ItemManager.instance.Remove(item);
        slotingCanvas.SetActive(false);
        joystickCanvas.SetActive(true);
        Time.timeScale = 1f;
    }
}
