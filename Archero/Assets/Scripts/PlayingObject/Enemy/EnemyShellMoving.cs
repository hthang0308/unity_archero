using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyShellMoving : EnemyMovingBase
{
    protected float delayMove = 0.5f;
    protected float durationMove = 0.5f;
    protected float countDelayMove = 0f;
    protected bool inDurationMoving = false;
    public override void UpdateNormal()
    {
        countDelayMove += Time.deltaTime;
        if (countDelayMove>delayMove+durationMove)
        {
            countDelayMove = 0;
            IsMoving = false;
            inDurationMoving = false;
        }
        else if ((countDelayMove>delayMove)&&(!inDurationMoving))
        {
            direction = playerTransform.position - transform.position;
            _navMeshAgent.SetDestination(playerTransform.position);
            IsMoving = true;
            inDurationMoving = true;
        }
    }
}

