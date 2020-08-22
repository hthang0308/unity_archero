using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Create Data/Front Shot")]
public class FrontShot : ItemCreateData
{
    public FrontShot()
    {
        type = ItemBase.Type.FRONT_SHOT;
    }

    public override void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;

        for (int i = 0; i < Number; i++)
        {
            items.Add(new FrontShotItem(icon));
        }
    }
}
