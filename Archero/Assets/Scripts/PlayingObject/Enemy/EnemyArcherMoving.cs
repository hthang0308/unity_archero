using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyArcherMoving : EnemyMovingBase
{
    [HideInInspector]
    public bool findAreaToShoot=false;
    float x, z;
    Vector3 destination;
    NavMeshPath path;
    public override void UpdateNormal()
    {
        if (findAreaToShoot==true)
        {
            while (findAreaToShoot == true)
            {
                x = UnityEngine.Random.Range(-5, 5);
                z = Mathf.Sqrt(25 - x * x);
                if (UnityEngine.Random.value >= 0.5)
                    z = -z;
                destination = transform.position + new Vector3(x, 0, z);
                path= new NavMeshPath();
                if ((_navMeshAgent.CalculatePath(destination,path))&&((destination-playerTransform.position).magnitude>5f))
                {
                    _navMeshAgent.SetPath(path);
                    findAreaToShoot = false;
                }
            }
        }
    }
}

