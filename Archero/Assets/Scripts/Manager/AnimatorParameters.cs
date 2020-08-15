using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters
{
    public static int isMovingID;
    private static string isMoving = "isMoving";
    public static void Init()
    {
        isMovingID = Animator.StringToHash(isMoving);
    }
}
