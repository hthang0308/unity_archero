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
    float attackRange = 2f;
    private void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
    }
    public override void UpdateNormal()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude > attackRange)
        {
            _navMeshAgent.SetDestination(playerTransform.position);
        }
    }
}

