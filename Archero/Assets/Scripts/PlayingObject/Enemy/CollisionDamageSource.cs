using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageSource : DamageSourceBase
{
    private float delayHit = 0.5f;
    private float countDelayHit = 0f;
    private bool isHit = false;
    protected int layerPlayer;
    LivingObjectInfo target;
    public override void Awake()
    {
        base.Awake();
        layerPlayer = LayerMask.NameToLayer("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==layerPlayer)
        {
            target = other.GetComponent<LivingObjectInfo>();
            DoDamage(target);
            isHit = true;
            countDelayHit = delayHit;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer==layerPlayer)
            isHit = false;
    }
    public override void UpdateNormal()
    {
        if (isHit)
        {
            countDelayHit -= Time.deltaTime;
            if (countDelayHit < 0)
            {
                DoDamage(target);
                countDelayHit = delayHit;
            }
        }
    }
}
