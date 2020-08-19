﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontShotItem : ItemBase
{
    public FrontShotItem(Sprite inIcon) : base(inIcon)
    {
        type = Type.FRONT_SHOT;
    }

    public override void DoAffect()
    {
        playerAttack.frontShot++;
    }
}