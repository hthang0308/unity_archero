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

    [SerializeField] private DamagePerSecondData dmgPerSecData;

    public DamagePerSecondData DmgPerSecData { get => dmgPerSecData; }
}