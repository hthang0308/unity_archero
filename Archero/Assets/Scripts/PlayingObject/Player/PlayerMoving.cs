using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MovingBase
{
    public void GetInput(float inHorizontal, float inVertical)
    {
        direction = new Vector3(inHorizontal, 0f, inVertical);
    }
}
