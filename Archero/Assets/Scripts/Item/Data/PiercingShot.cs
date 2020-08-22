using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Create Data/Piercing Shot")]
public class PiercingShot : ItemCreateData
{
    public PiercingShot()
    {
        type = ItemBase.Type.PIERCING_SHOT;
    }

    public override void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;

        for (int i = 0; i < Number; i++)
        {
            items.Add(new PiercingShotItem(icon));
        }
    }
}
