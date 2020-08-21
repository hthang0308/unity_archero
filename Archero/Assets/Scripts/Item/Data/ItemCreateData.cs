using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreateData : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private float number;
    protected ItemBase.Type type;

    public Sprite Icon { get => icon; }
    public float Number { get => number; }
    public ItemBase.Type Type { get => type; }

    public void AddItem()
    {

    }
}


