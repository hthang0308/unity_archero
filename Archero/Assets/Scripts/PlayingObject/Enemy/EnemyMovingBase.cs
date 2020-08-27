
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovingBase : MovingBase
{
    [SerializeField]
    protected NavMeshAgent _navMeshAgent;
    protected Transform playerTransform;
    protected virtual void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
        _navMeshAgent.speed = maxSpeed;
    }
    protected bool isMoving = false;

    public virtual bool IsMoving
    {
        get => isMoving;
        set
        {
            if (isMoving == value)
                return;
            isMoving = value;
            if (isMoving == false)
            {
                state.IsMoving = false;
                _navMeshAgent.isStopped = true;
            }
            else
            {
                state.IsMoving = true;
                _navMeshAgent.isStopped = false;
            }
        }
    }
}


