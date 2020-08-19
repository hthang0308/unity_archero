using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : LivingObjectInfo
{
    public ExperiencePoint experience;
    [HideInInspector] public PlayerMoving playerMoving;

    

    public override void Awake()
    {
        base.Awake();
        playerMoving = movement as PlayerMoving;
        id = 0;
    }

    public void GetInput(float inHorizontal, float inVertical)
    {
        playerMoving.GetInput(inHorizontal, inVertical);
    }
}
