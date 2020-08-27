using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamageSource : DamageSourceBase
{
    protected int wallLayer;
    protected int collisionLayer;
    protected int enemyLayer;
    protected int bossLayer;
    [SerializeField] protected TrailRenderer trail;

    [HideInInspector] public float distance = 20f;
    protected float countDownDistance;
    //bool dealDamage = false;
    [HideInInspector] public float speed = 0.8f;

    protected Vector3 direction;
    public Vector3 Direction
    {
        set
        {
            direction = value.normalized;
        }
    }

    [HideInInspector] public bool penetrate = false;
    [HideInInspector] public bool bouncingWall = false;

    protected bool disable = false;
    protected RaycastHit hit;

    public override void Awake()
    {
        base.Awake();
        wallLayer = LayerMask.NameToLayer("Wall");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        bossLayer = LayerMask.NameToLayer("Boss");
        collisionLayer = LayerMask.NameToLayer("Collision");
    }

    

    public void OnEnable()
    {
        disable = false;
        Debug.Log(collisionLayer);
        //dealDamage = false;
    }


    public override void UpdateFixed()
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



        if (Physics.Raycast(transform.position, direction, out hit, deltaMovement, ~layerToIgnore, QueryTriggerInteraction.Ignore))
        {
            if ((hit.collider.gameObject.layer & (enemyLayer|bossLayer)) != 0)
            {
                LivingObjectInfo target = hit.collider.GetComponent<LivingObjectInfo>();
                //if (!dealDamage)
                //{
                if (target!=null)
                    DoDamage(target);
                //    dealDamage = true;
                //}
                //else
                //    gameObject.SetActive(false);
                    
                if (penetrate)
                    transform.position += deltaMovement * direction;
                else
                {
                    transform.position = hit.point;
                    disable = true;
                }
            }
            else if (((hit.collider.gameObject.layer & wallLayer) != 0 && bouncingWall))
            {
                Debug.Log("hit " + hit.collider.gameObject.layer);
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

    public virtual void SetUpArrow(Vector3 inDirection, float inDistance, float inSpeed, bool inPenetrate, bool inBouncing, 
        List<EffectBaseData> inEffectBaseDatas, float inAtkPoint)
    {
        distance = inDistance;
        speed = inSpeed;
        penetrate = inPenetrate;
        Direction = inDirection;
        countDownDistance = distance;
        bouncingWall = inBouncing;
        effectDatas = inEffectBaseDatas;
        atkPoint = inAtkPoint;
    }

    public void OnDisable()
    {
        trail.Clear();
    }
}
