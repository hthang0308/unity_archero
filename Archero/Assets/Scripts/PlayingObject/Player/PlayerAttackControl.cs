using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : AttackControl
{
    [SerializeField] protected PlayerMoving playerMoving;

    public override void UpdateNormal()
    {
        if (!playerMoving.IsMoving)
            SwitchAttack = 0;
        else SwitchAttack = -1;
    }
}
