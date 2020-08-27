using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamageSource : LaserDamageSource
{
    [SerializeField] ParticleSystem projectile;
    [SerializeField] AudioSource onShoot;
    [SerializeField] BulletExplosion explosion;
    protected BulletExplosion currentExplosion;
    public override void Awake()
    {
        base.Awake();
        //currentExplosion = Instantiate(explosion);
        //currentExplosion.gameObject.SetActive(false);
    }
    public override void OnEnable()
    {
        base.OnEnable();
        if (onShoot!=null)
            onShoot.Play();
        projectile.Play();
    }
    //public void DoOnDisable()
    //{
    //    //Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion, playerMask);
    //    //for (int i = 0; i < colliders.Length; i++)
    //    //{
    //    //    DoDamage(colliders[i].GetComponent<PlayerInfo>());
    //    //    targetInfo.rigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
    //    //}
    //    currentExplosion.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
    //    currentExplosion.gameObject.SetActive(true);
    //    currentExplosion.particle.Play();
    //    currentExplosion.audioSource.Play();
    //    gameObject.SetActive(false);
    //}
}
