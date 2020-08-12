using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect Data/Damage Per Second")]
public class DamagePerSecondData : EffectBaseData
{
    [Header("Damage Info")]
    [Space(20)]
    [SerializeField] protected float damage;

    public float Damage { get => damage; }
}
