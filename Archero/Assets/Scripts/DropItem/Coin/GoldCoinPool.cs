using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinPool : BaseMonoBehaviour
{
    public static GoldCoinPool instance;
    [SerializeField] protected float upForce = 1f;
    [SerializeField] protected float sideForce = 0.1f;

    public GoldCoinPool()
    {
        //if (instance == null)
            instance = this;
    }

    protected ObjectPooling<GoldCoinBehavior> coinPool;
    [SerializeField] protected GoldCoinBehavior coinPrefab;

    public override void Awake()
    {
        base.Awake();
        if (instance.coinPool == null)
        {
            coinPool = new ObjectPooling<GoldCoinBehavior>();
            coinPool.GrowPool(coinPrefab, 10);
        }
    }

    public override void UpdateFixed()
    {
        coinPool.UpdateFixed();
    }

    public void UseCoin(Vector3 postion, int number)
    {
        for (int i=0; i<number; i++)
        {
            GoldCoinBehavior coin = coinPool.GetFromPool(coinPrefab);
            Vector3 velocity = new Vector3();
            velocity.x = Random.Range(-sideForce, sideForce);
            velocity.z = Random.Range(-sideForce, sideForce);
            velocity.y = Random.Range(upForce/1.5f, upForce);
            coin.rigidbody.velocity = velocity;

            velocity.y = 0;
            coin.transform.SetPositionAndRotation(postion, Quaternion.LookRotation(velocity));
        }
    }

    public void GetExperience()
    {
        List<GoldCoinBehavior> tmp = coinPool.poolActive;
        for (int i = 0; i < tmp.Count; i++)
            tmp[i].canMoving = true;
    }
}
