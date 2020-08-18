using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamageSource : DamageSourceBase
{
    protected int wallLayer;
    protected int enemyLayer;
    [SerializeField] protected TrailRenderer trail;

    protected float distance = 20f;
    protected float countDownDistance;

    protected float speed = 0.8f;
    protected Vector3 direction = new Vector3(1, 0, 1);

    protected bool penetrate = false;
    protected bool bouncingWall = false;
    protected bool disable = false;
    protected RaycastHit hit;

    public override void Awake()
    {
        base.Awake();
        wallLayer = LayerMask.NameToLayer("Wall");
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    public Vector3 Direction
    {
        set
        {
            direction = value.normalized;
        }
    }

    public void OnEnable()
    {
        disable = false;
    }


    public override void UpdateNormal()
    {
        if (disable)
            gameObject.SetActive(false);

        float deltaMovement = Time.deltaTime * speed;

        if (deltaMovement >= countDownDistance)
        {
            deltaMovement = countDownDistance;
            countDownDistance = 0f;
            disable = true;
        }
        else countDownDistance -= deltaMovement;



        if (Physics.Raycast(transform.position, direction, out hit, deltaMovement, ~layerToIgnore))
        {
            //Fix Do Damage to enemy later
            LivingObjectInfo target = hit.collider.GetComponent<LivingObjectInfo>();
            //if (target != null)
            //    DoDamage(target);
            if ((target != null) && (target.gameObject.layer == 16))
                DoDamage(target);

            if ((hit.collider.gameObject.layer | enemyLayer) != 0 && penetrate)
            {
                transform.position += deltaMovement * direction;
            }
            else if ((hit.collider.gameObject.layer | wallLayer) != 0 && bouncingWall)
            {
                //recalculate the real distance and add back to countDown
                float realDeltaMovement = (transform.position - hit.point).magnitude;
                countDownDistance += deltaMovement - realDeltaMovement;

                transform.position = hit.point;
                Direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                transform.position = hit.point;
                disable = true;
            }
        }
        else transform.position += deltaMovement * direction;

    }

    public virtual void SetUpArrow(Vector3 inDirection, float inDistance, float inSpeed, bool inPenetrate, bool inBouncing)
    {
        distance = inDistance;
        speed = inSpeed;
        penetrate = inPenetrate;
        Direction = inDirection;
        countDownDistance = distance;
        bouncingWall = inBouncing;

    }

    public void OnDisable()
    {
        trail.Clear();
    }
}
