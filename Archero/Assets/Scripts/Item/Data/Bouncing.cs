using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Create Data/Bouncing")]
public class Bouncing : ItemCreateData
{
    public Bouncing()
    {
        type = ItemBase.Type.BOUNCING;
    }

    public override void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;

        for (int i=0; i<Number; i++)
        {
            items.Add(new BouncingItem(icon));
        }
    }
}
