using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyArcherMoving : EnemyMovingBase
{
    float x, z;
    Vector3 destination;
    NavMeshPath path;
    public void FindAreaToShoot(float rangeMoving)
    {
        while (true)
        {
            x = UnityEngine.Random.Range(-rangeMoving, rangeMoving);
            z = Mathf.Sqrt(rangeMoving* rangeMoving - x * x);
            if (UnityEngine.Random.value >= 0.5)
                z = -z;
            destination = transform.position + new Vector3(x, 0, z);
            path = new NavMeshPath();
            if ((_navMeshAgent.CalculatePath(destination, path)) && ((destination - playerTransform.position).magnitude > rangeMoving/2))
            {
                _navMeshAgent.SetPath(path);
                break;
            }
        }
    }
}

