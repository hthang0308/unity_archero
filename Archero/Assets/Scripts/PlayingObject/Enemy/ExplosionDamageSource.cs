using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamageSource : DamageSourceBase
{
    public LayerMask playerMask;
    public Rigidbody bulletRig;
    public float radiusExplosion;
    [SerializeField] BulletExplosion explosion;
    protected BulletExplosion currentExplosion;
    public override void Awake()
    {
        base.Awake();
        currentExplosion= Instantiate(explosion);
        currentExplosion.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion, playerMask);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            if (colliders[i].gameObject.layer == 13)
                DoDamage(colliders[i].GetComponent<PlayerInfo>());
        }
        currentExplosion.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        currentExplosion.gameObject.SetActive(true);
        currentExplosion.particle.Play();
        currentExplosion.audioSource.Play();
        gameObject.SetActive(false);
    }
}