using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Create Data/Multi Shot")]
public class MultiShot : ItemCreateData
{
    public MultiShot()
    {
        type = ItemBase.Type.MULTI_SHOT;
    }

    public override void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;

        for (int i = 0; i < Number; i++)
        {
            items.Add(new MultiShotItem(icon));
        }
    }
}
