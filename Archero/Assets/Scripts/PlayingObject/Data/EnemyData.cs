using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyData : LivingData
{
    [Header("Experience")]
    [SerializeField] private float expOnDeath = 3f;
    public float ExpOnDeath { get => expOnDeath; }
}
