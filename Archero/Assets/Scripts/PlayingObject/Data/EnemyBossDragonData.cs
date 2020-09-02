using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(menuName = "LivingData/BossData/Dragon")]
public class EnemyBossDragonData : EnemyData
{
    [Header("Fireball Attack")]
    [Space(20)]
    [SerializeField] int attackPerTime1 = 3;
    [SerializeField] float atkPoint1 = 10f;
    [SerializeField] protected float[] angle;
    [SerializeField] float distance = 10f;


    [Header("Tail Attack")]
    [Space(20)]
    [SerializeField] int attackPerTime2 = 3;
    [SerializeField] float atkPoint2 = 10f;
    [SerializeField] float radiusExplosion = 2f;
    [SerializeField] ExplosionDamageSource explosion;
    [SerializeField] float durationRunning = 0.5f;
    [SerializeField] float durationTailAttack = 0.5f;



    public int AttackPerTime1 { get => attackPerTime1; }
    public float AtkPoint1 { get => atkPoint1; }
    public float [] Angle { get => angle; }
    public float Distance { get => distance; }



    public int AttackPerTime2 { get => attackPerTime2; }
    public float AtkPoint2 { get => atkPoint2; }
    public float RadiusExplosion { get => radiusExplosion; }
    public ExplosionDamageSource Explosion { get => explosion; }
    public float DurationRunning { get => durationRunning; }
    public float DurationTailAttack { get => durationTailAttack; }
}
