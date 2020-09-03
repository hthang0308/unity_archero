using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "LivingData/EnemyData/Basic")]
public class EnemyData : LivingData
{
    [Header("Experience")]
    [SerializeField] private int expOnDeath = 3;
    public int ExpOnDeath { get => expOnDeath; }
}
