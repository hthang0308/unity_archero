using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingObjectInfo : BaseMonoBehaviour, IEquatable<LivingObjectInfo>
{
    protected static int idInit = 1;
    public int id;

    //id = 0 --> player
    const int maxID = 60000;

    public override void Awake()
    {
        base.Awake();
        id = idInit;
        idInit = (idInit % (maxID - 1)) + 1;
    }

    public HealthBase health;
    public AttackControl attackControl;
    public MovingBase movement;
    public DamageSourceBase dmgSource;
    public Status status;

    public bool Equals(LivingObjectInfo other)
    {
        if (id == other.id)
            return true;
        return false;
    }
}
