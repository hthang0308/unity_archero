using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinBehavior : BaseMonoBehaviour
{

    protected static PlayerInfo player;
    protected static ExperiencePoint playerExperience;
    protected static Money playerMoney;
    [SerializeField] protected float expPoint = 5;
    [SerializeField] protected int goldDrop = 100;
    [SerializeField] protected float maxSpeed = 20f;
    protected float speed = 0f;
    public Rigidbody rigidbody;
    
    public bool canMoving = false;

    public override void Awake()
    {
        base.Awake();
        if (player == null)
        {
            player = GameManager.instance.player;
            playerExperience = player.experience;
            playerMoney = player.money;
        }
    }

    public override void UpdateFixed()
    {
        if (canMoving)
        {
            Vector3 direction = player.transform.position - transform.position;
            if (direction.magnitude <= 1)
            {
                playerExperience.AddExp(expPoint);
                playerMoney.AddGold(goldDrop);
                gameObject.SetActive(false);
                canMoving = false;
                speed = 0f;
                return;
            }
            if (speed > maxSpeed)
                speed = maxSpeed;
            else speed += Time.fixedDeltaTime * 20;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * speed);
        }
    }


}
