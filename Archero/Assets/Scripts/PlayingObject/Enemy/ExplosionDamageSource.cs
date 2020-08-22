using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamageSource : DamageSourceBase
{
    public Rigidbody bulletRig;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            DoDamage(other.GetComponent<LivingObjectInfo>());
        }
        gameObject.SetActive(false);
    }
}
