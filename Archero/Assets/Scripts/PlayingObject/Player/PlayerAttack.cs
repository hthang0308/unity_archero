using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackBase
{
    [SerializeField] protected PlayerState playerState;

    protected Transform lookAtEnemy;

    public override void UpdateNormal()
    {
        if (!playerState.IsMoving)
        {
            List<LivingObjectInfo> enemies = GameManager.instance.enemies;
            if (enemies.Count == 0)
            {
                playerState.HasEnemy = false;
                Attacking = false;
            }
            else
            {
                //SwitchAttack = 0;
                if (lookAtEnemy == null || !lookAtEnemy.gameObject.activeInHierarchy || Attacking == false)
                {
                    Attacking = true;
                    Vector3 curPos = transform.position;
                    lookAtEnemy = enemies[0].transform;
                    float minDistance = (lookAtEnemy.position - curPos).magnitude;

                    for (int i = 1; i < enemies.Count; i++)
                    {
                        float tmpDistance = (enemies[i].transform.position - curPos).magnitude;
                        if (tmpDistance < minDistance)
                        {
                            minDistance = tmpDistance;
                            lookAtEnemy = enemies[i].transform;
                        }
                    }
                    PlayerStyleAttack playerAttack = curAttackStyle as PlayerStyleAttack;
                    playerAttack.enemyLookAt = lookAtEnemy;
                }
                else Attacking = true;
            }
        }
        else Attacking = false;
    }
}
