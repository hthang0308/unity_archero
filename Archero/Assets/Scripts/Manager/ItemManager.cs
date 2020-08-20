using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public List<ItemBase> items = new List<ItemBase>();
    [SerializeField] protected List<ItemCreateData> datas;
    [SerializeField] protected GameObject slotMachineCanvas;

    public ItemManager()
    {
        if (instance == null)
        {
            instance = this;
            
        }
    }

    public void Awake()
    {
        for (int i = 0; i < datas.Count; i++)
        {
            ItemBase.Type type = datas[i].Type;
            Sprite icon = datas[i].Icon;
            for (int j = 0; j < datas[i].Number; j++)
            {
                switch (type)
                {
                    case ItemBase.Type.FRONT_SHOT:
                        items.Add(new FrontShotItem(icon));
                        break;
                    case ItemBase.Type.DIAGONAL_SHOT:
                        items.Add(new DiagonalShotItem(icon));
                        break;
                    case ItemBase.Type.MULTI_SHOT:
                        items.Add(new MultiShotItem(icon));
                        break;
                    case ItemBase.Type.PIERCING_SHOT:
                        items.Add(new PiercingShotItem(icon));
                        break;
                    case ItemBase.Type.BOUNCING:
                        items.Add(new BouncingItem(icon));
                        break;
                    case ItemBase.Type.DAMAGE_PER_SECOND:
                        DamagePerSecondItemData damagePerSecondItemData = datas[i] as DamagePerSecondItemData;
                        items.Add(new DamagePerSecondItem(icon, damagePerSecondItemData.DmgPerSecData));
                        break;
                }

            }
        }
        slotMachineCanvas.SetActive(true);
    }


    public ItemBase GetItem()
    {
        return items[Random.Range(0, items.Count)];
    }

    public void Remove(ItemBase item)
    {
        items.Remove(item);
    }
}