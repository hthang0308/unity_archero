using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters
{
    //variable
    public static int var_isMovingID;
    private static string var_isMoving = "isMoving";
    public static int var_isDeadID;
    private static string var_isDead = "isDead";
    public static int var_multiShootID;
    private static string var_multiShoot = "multiShoot";
    public static int var_hasEnemyID;
    private static string var_hasEnemy = "hasEnemy";

    //state
    public static int state_multiShotID;
    private static string state_multiShot = "MultiShot";
    public static int state_singleShotID;
    private static string state_singleShot = "SingleShot";

    public static void Init()
    {
        var_isMovingID = Animator.StringToHash(var_isMoving);
        var_isDeadID = Animator.StringToHash(var_isDead);
        var_multiShootID = Animator.StringToHash(var_multiShoot);
        var_hasEnemyID = Animator.StringToHash(var_hasEnemy);

        state_multiShotID = Animator.StringToHash(state_multiShot);
        state_singleShotID = Animator.StringToHash(state_singleShot);
    }
}
