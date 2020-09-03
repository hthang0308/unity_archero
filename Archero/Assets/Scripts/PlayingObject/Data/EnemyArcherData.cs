using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(menuName = "LivingData/EnemyData/Archer")]
public class EnemyArcherData : EnemyData
{
    [Header("Attack Style")]
    [Space(20)]
    [SerializeField] float rangeMove = 6f;
    [SerializeField] float timeMove = 3f;
    [SerializeField] float bulletMaxDistance = 10f;
    [SerializeField] float speedBullet = 10f;
    public float SpeedBullet { get => speedBullet; }
    public float TimeMove { get => timeMove; }
    public float RangeMove { get => rangeMove; }
    public float BulletMaxDistance { get => bulletMaxDistance; }
}
