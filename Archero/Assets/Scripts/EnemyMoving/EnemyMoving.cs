using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMoving : MovingBase
{
    [SerializeField]
    NavMeshAgent _navMeshAgent;
    Transform playerTransform;
    private void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
        _navMeshAgent.speed = maxSpeed;
    }
    public override void UpdateNormal()
    {
        direction = playerTransform.position - transform.position;
        _navMeshAgent.SetDestination(playerTransform.position);
    }
}

