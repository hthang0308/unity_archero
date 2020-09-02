using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectParticleManager : MonoBehaviour
{
    public static EffectParticleManager instance;
    public EffectParticleManager()
    { 
        instance = this;
    }
    [SerializeField]
    List<EffectBase.Type> effectType;
    [SerializeField]
    List<ParticleSystem> particle;
    protected ObjectPooling<ParticleSystem>[] effPool;
    int count;
    private void Awake()
    {
        count = effectType.Count;
        effPool = new ObjectPooling<ParticleSystem>[count];
        for (int i = 0; i < count; i++)
        {
            effPool[i] = new ObjectPooling<ParticleSystem>();
            effPool[i].GrowPool(particle[i], 5);
        }
    }
    public ParticleSystem GetParticle(EffectBase.Type type)
    {
        int i = effectType.IndexOf(type);
        ParticleSystem par= effPool[i].GetFromPool(particle[i]);
        return par;
    }
}
