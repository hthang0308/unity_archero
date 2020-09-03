using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingData : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private float maxHP = 100f;
    //enemy - exp on death
    [Header("Attack")]
    [Space(20)]
    [SerializeField] private float delayNextAttack = 3;
    [SerializeField] private float atkPoint = 5f;
    [SerializeField] List<EffectBaseData> effectDatas = new List<EffectBaseData>();
    //TankMovement
    [Header("Movement")]
    [Space(20)]
    [SerializeField] private float speed = 5f;


    public float MaxHP { get => maxHP; }
    public float DelayNextAttack { get => delayNextAttack; }
    public float Speed { get => speed; }
    public float AtkPoint { get => atkPoint; }
    public List<EffectBaseData> EffectDatas { get => effectDatas; }
}
