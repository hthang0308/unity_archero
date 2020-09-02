using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "LivingData/EnemyData/Cannon")]
public class EnemyCannonData : EnemyData
{
    [Header("Cannon")]
    [Space(20)]
    [SerializeField] float explosionRadius = 5f;
    public float ExplosionRadius { get => explosionRadius; }
}
