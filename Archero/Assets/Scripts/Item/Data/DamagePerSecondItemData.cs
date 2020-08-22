using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item Create Data/Damage Per Second")]
public class DamagePerSecondItemData : ItemCreateData
{
    public DamagePerSecondItemData()
    {
        type = ItemBase.Type.DAMAGE_PER_SECOND;
    }

    [SerializeField] protected DamagePerSecondData dmgPerSecData;

    public DamagePerSecondData DmgPerSecData { get => dmgPerSecData; }

    public override void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;

        items.Add(new DamagePerSecondItem(icon, dmgPerSecData));
    }
}