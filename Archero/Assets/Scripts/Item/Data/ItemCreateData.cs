using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreateData : ScriptableObject
{
    [SerializeField] protected Sprite icon;
    [SerializeField] protected float number;
    protected ItemBase.Type type;

    public Sprite Icon { get => icon; }
    public float Number { get => number; }
    public ItemBase.Type Type { get => type; }

    public virtual void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;
    }
}


