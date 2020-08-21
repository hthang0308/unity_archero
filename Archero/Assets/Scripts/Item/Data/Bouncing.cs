using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Create Data/Bouncing")]
public class Bouncing : ItemCreateData
{


    public Bouncing()
    {
        type = ItemBase.Type.DAMAGE_PER_SECOND;
    }
}
