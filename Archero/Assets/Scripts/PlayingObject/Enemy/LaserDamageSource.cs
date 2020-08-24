using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageSource : DamageSourceBase
{
    protected int playerLayer, wallLayer;

    [SerializeField] protected TrailRenderer trail;

    protected float countDownDistance=30f;
    private float speed = 30f;

    protected bool disable = false;
    protected RaycastHit hit;
    protected Vector3 direction;
    public Vector3 Direction
    {
        set
        {
            direction = value.normalized;
        }
    }
    public override void Awake()
    {
        base.Awake();
        playerLayer = LayerMask.NameToLayer("Player");
        wallLayer = LayerMask.NameToLayer("Wall");
    }



    public void OnEnable()
    {
        disable = false;
        countDownDistance = 20f;
    }


    public override void UpdateNormal()
    {
        if (disable)
        {
            gameObject.SetActive(false);
        }
            

        float deltaMovement = Time.deltaTime * speed;

        if (deltaMovement >= countDownDistance)
        {
            deltaMovement = countDownDistance;
            countDownDistance = 0f;
            disable = true;
        }
        else 
            countDownDistance -= deltaMovement;
        if (Physics.Raycast(transform.position, direction, out hit, deltaMovement, ~layerToIgnore, QueryTriggerInteraction.Ignore))
        {
            //if ((hit.collider.gameObject.layer & playerLayer) != 0)
            if (hit.collider.gameObject.layer==playerLayer)
            {
                Debug.Log(hit.collider.gameObject.name);
                LivingObjectInfo target = hit.collider.GetComponent<LivingObjectInfo>();
                DoDamage(target);
                transform.position = hit.point;
                disable = true;
            }
            else if ((hit.collider.gameObject.layer & wallLayer) != 0)
            {
                float realDeltaMovement = (transform.position - hit.point).magnitude;
                countDownDistance += deltaMovement - realDeltaMovement;
                transform.position = hit.point;
                Direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                transform.position = hit.point;
                disable = true;
                Debug.Log(Time.time + "c");
            }
        }
        else 
            transform.position += deltaMovement * direction;
    }
    public void OnDisable()
    {
        trail.Clear();
    }
}
