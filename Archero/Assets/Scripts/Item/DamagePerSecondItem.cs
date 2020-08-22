﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerSecondItem : ItemBase
{
    [SerializeField] protected DamagePerSecondData damagePerSecondData; 
    public DamagePerSecondItem(Sprite inIcon, DamagePerSecondData inData) : base(inIcon)
    {
        type = Type.DAMAGE_PER_SECOND;
        damagePerSecondData = inData;
    }

    public override void DoAffect()
    {
        PlayerStyleAttack playerAttack = GameManager.instance.player.attackBase.CurAttackStyle as PlayerStyleAttack;
        playerAttack.effectDatas.Add(damagePerSecondData);
    }

    
}