﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : LivingObjectInfo
{
    public ExperiencePoint experience;
    public Money money;

    public override void Awake()
    {
        base.Awake();
        id = 0;
    }

}
