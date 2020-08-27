using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamageSource : DamageSourceBase
{
    public LayerMask playerMask;
    public Rigidbody bulletRig;
    private float radiusExplosion = 1.5f;
    [SerializeField] BulletExplosion explosion;
    protected BulletExplosion currentExplosion;
    public override void Awake()
    {
        base.Awake();
        currentExplosion = Instantiate(explosion);
        currentExplosion.gameObject.SetActive(false);
    }
    private void OnTriggerEnter()
    {
        CreateExplosion();
    }
    public void CreateExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion, playerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            DoDamage(colliders[i].GetComponent<PlayerInfo>());
        }
        currentExplosion.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        currentExplosion.gameObject.SetActive(true);
        currentExplosion.particle.Play();
        currentExplosion.audioSource.Play();
        gameObject.SetActive(false);
    }
    public void SetUp(float inAtkPoint, float inRadiusExplosion)
    {
        atkPoint = inAtkPoint;
        radiusExplosion = inRadiusExplosion;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radiusExplosion);
    }
}