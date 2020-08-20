using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item Create Data/Base")]
public class ItemCreateData : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private float number;
    [SerializeField] private ItemBase.Type type;

    public Sprite Icon { get => icon; }
    public float Number { get => number; }
    public ItemBase.Type Type { get => type; }
}


