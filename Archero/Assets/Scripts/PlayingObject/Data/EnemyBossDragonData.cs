using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(menuName = "LivingData/EnemyData/Boss Dragon")]
public class EnemyBossDragonData : EnemyData
{
    [Header("Fireball Attack")]
    [Space(20)]
    [SerializeField] float delayNextAttack1 = 3f;
    [SerializeField] int attackPerTime1 = 3;
    [SerializeField] float atkPoint1 = 10f;
    [SerializeField] protected float[] angle;
    [SerializeField] float distance = 10f;
    [SerializeField] float speedBullet = 10f;
    public float SpeedBullet { get => speedBullet; }

    [Header("Tail Attack")]
    [Space(20)]
    [SerializeField] float delayNextAttack2 = 3f;
    [SerializeField] int attackPerTime2 = 3;
    [SerializeField] float atkPoint2 = 10f;
    [SerializeField] float radiusExplosion = 2f;
    [SerializeField] float durationRunning = 0.5f;
    [SerializeField] float durationTailAttack = 0.5f;



    public int AttackPerTime1 { get => attackPerTime1; }
    public float AtkPoint1 { get => atkPoint1; }
    public float [] Angle { get => angle; }
    public float Distance { get => distance; }
    public float DelayNextAttack1 { get => delayNextAttack1; }


    public int AttackPerTime2 { get => attackPerTime2; }
    public float AtkPoint2 { get => atkPoint2; }
    public float RadiusExplosion { get => radiusExplosion; }
    public float DurationRunning { get => durationRunning; }
    public float DurationTailAttack { get => durationTailAttack; }
    public float DelayNextAttack2 { get => delayNextAttack2; }
}
