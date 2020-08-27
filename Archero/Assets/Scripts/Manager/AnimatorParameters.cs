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



    //BossDragonAnimationParameters
    public static int var_isLowHpID;
    private static string var_isLowHp = "isLowHp";
    public static int var_isAttack1_ID;
    private static string var_isFlameAttack = "attack1";
    public static int var_isGetHitID;
    private static string var_isGetHit = "isGetHit";
    public static int var_isAttack2_ID;
    private static string var_tailAttack = "attack2";
    //su dung isDead o tren


    //state
    public static int state_attackType1_ID;
    private static string state_attackType1 = "Attack1";
    public static int state_attackType2_ID;
    private static string state_attackType2 = "Attack2";
    public static int state_attackType3_ID;
    private static string state_attackType3 = "Attack3";




    public static void Init()
    {
        var_isMovingID = Animator.StringToHash(var_isMoving);
        var_isDeadID = Animator.StringToHash(var_isDead);
        var_multiShootID = Animator.StringToHash(var_multiShoot);
        var_hasEnemyID = Animator.StringToHash(var_hasEnemy);

        state_multiShotID = Animator.StringToHash(state_multiShot);
        state_singleShotID = Animator.StringToHash(state_singleShot);


        //Enemy
        var_isLowHpID = Animator.StringToHash(var_isLowHp);
        var_isAttack1_ID = Animator.StringToHash(var_isFlameAttack);
        var_isGetHitID = Animator.StringToHash(var_isGetHit);
        var_isAttack2_ID = Animator.StringToHash(var_tailAttack);
        state_attackType2_ID = Animator.StringToHash(state_attackType2);
        state_attackType1_ID = Animator.StringToHash(state_attackType1);
        state_attackType3_ID = Animator.StringToHash(state_attackType3);

    }
}
