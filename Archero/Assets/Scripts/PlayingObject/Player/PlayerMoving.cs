using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MovingBase
{
    public void GetInput(float inHorizontal, float inVertical)
    {
        direction = new Vector3(inHorizontal, 0f, inVertical);
    }
    public override void UpdateNormal()
    {
        Move();
    }

    protected void Move()
    {
        //Move the object
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            rigidbody.velocity = transform.forward * maxSpeed;
            IsMoving = true;
            return;
        }

        IsMoving = false;
    }
}
