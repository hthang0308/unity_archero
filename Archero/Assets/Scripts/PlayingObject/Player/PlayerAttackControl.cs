using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : AttackControl
{
    [SerializeField] protected PlayerMoving playerMoving;
    [SerializeField] protected PlayerAnimator playerAnimator;

    protected Transform lookAtEnemy;

    public override void UpdateNormal()
    {
        if (!playerMoving.IsMoving)
        {
            List<LivingObjectInfo> enemies = GameManager.instance.enemies;
            if (enemies.Count == 0)
            {
                playerAnimator.HasEnemy = false;
                SwitchAttack = -1;
            }
            else
            {
                SwitchAttack = 0;
                if (lookAtEnemy == null || !lookAtEnemy.gameObject.activeInHierarchy)
                {
                    //if (lookAtEnemy!=null)
                    //    Debug.Log(!lookAtEnemy.gameObject.activeInHierarchy);
                    Vector3 curPos = transform.position;
                    lookAtEnemy = enemies[0].transform;
                    float minDistance = (lookAtEnemy.position - curPos).magnitude;
                    //Debug.Log(enemies[0].id);

                    for (int i=1;i<enemies.Count;i++)
                    {
                        //Debug.Log(enemies[i].id);
                        float tmpDistance = (enemies[i].transform.position - curPos).magnitude;
                        if (tmpDistance < minDistance)
                        {
                            minDistance = tmpDistance;
                            lookAtEnemy = enemies[i].transform;
                        }
                    }
                    PlayerAttack playerAttack = curAttack as PlayerAttack;
                    playerAttack.enemyLookAt = lookAtEnemy;
                }
            }
        }
        else SwitchAttack = -1;
    }
}
