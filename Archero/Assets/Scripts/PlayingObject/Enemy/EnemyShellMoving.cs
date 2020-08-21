using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyShellMoving : MovingBase
{
    [SerializeField]
    NavMeshAgent _navMeshAgent;
    Transform playerTransform;
    private float delayMove = 0.5f;
    private float durationMove = 0.5f;
    private float countDelayMove = 0f;
    bool inDurationMoving = false;
    private void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
        _navMeshAgent.speed = maxSpeed;
    }
    public override void UpdateNormal()
    {
        countDelayMove += Time.deltaTime;
        if (countDelayMove>delayMove+durationMove)
        {
            countDelayMove = 0;
            _navMeshAgent.speed = 0;
            //IsMoving = false;
            state.IsMoving = false;
            inDurationMoving = false;
        }
        else if ((countDelayMove>delayMove)&&(!inDurationMoving))
        {
            direction = playerTransform.position - transform.position;
            _navMeshAgent.SetDestination(playerTransform.position);
            _navMeshAgent.speed = maxSpeed;
            //IsMoving = true;
            state.IsMoving = true;
            inDurationMoving = true;
        }
    }
}

