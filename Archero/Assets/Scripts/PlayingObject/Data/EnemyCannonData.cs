using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "LivingData/EnemyData/Cannon")]
public class EnemyCannonData : EnemyData
{
    [Header("Cannon")]
    [Space(20)]
    [SerializeField] float radiusExplosion = 5f;
    public float RadiusExplosion { get => radiusExplosion; }
    [SerializeField] float speedBullet = 10f;
    public float SpeedBullet { get => speedBullet; }
}
