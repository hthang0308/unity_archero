using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingObjectInfo : BaseMonoBehaviour
{
    public int id;
    public HealthBase health;
    public AttackControl attackControl;
    public MovingBase movement;
    public DamageSourceBase dmgSource;
    public Status status;


}
