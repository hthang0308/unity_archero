using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Create Data/Diagonal Shot")]
public class DiagonalShot : ItemCreateData
{
    public DiagonalShot()
    {
        type = ItemBase.Type.DIAGONAL_SHOT;
    }

    public override void AddItem()
    {
        List<ItemBase> items = ItemManager.instance.items;

        for (int i = 0; i < Number; i++)
        {
            items.Add(new DiagonalShotItem(icon));
        }
    }
}
