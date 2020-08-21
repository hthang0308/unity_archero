using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MovingBase
{
    public override void UpdateNormal()
    {
        //Move the object
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            rigidbody.velocity = transform.forward * maxSpeed;
            //IsMoving = true;
            state.IsMoving = true;
            return;
        }

        //IsMoving = false;
        state.IsMoving = false;
    }

}
