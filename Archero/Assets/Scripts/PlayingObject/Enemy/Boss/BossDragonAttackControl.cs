using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossDragonAttackControl : AttackControlBase
{
    protected Transform playerTransform;
    [SerializeField] EnemyState state;
    float delaySwitchAttack = 1f;   //Kiem tra va switch attack moi 1 giay
    float countDelay = 0f;

    int numberAttack = 0;
    protected virtual void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
        numberAttack = attackStyles.Count;
    }

    public override void UpdateNormal()
    {
        countDelay -= Time.deltaTime;
        if (countDelay < 0)
        {
            countDelay = delaySwitchAttack;
            SwitchAttack();
        }
    }
    void SwitchAttack()
    {
        if (attackBase.CurAttackStyle.enabled==false)
        {
            index++;
            if (index >= numberAttack)
                index = 0;
            attackBase.CurAttackStyle = attackStyles[index];
        }
        //int i = index;
        //if (Vector3.Distance(transform.position, playerTransform.position)<10f)
        //{
        //    index = 1;
        //}
        //else
        //{
        //    index = 0;
        //}
        //if (index!=i)
        //{
        //    state.Attack1 = false;
        //    state.Attack2 = 0;
        //    if (attackBase.CurAttackStyle!=null)
        //        attackBase.CurAttackStyle.enabled = false;
        //    attackBase.CurAttackStyle = attackStyles[index];
        //    switch (index)
        //    {
        //        case 0:
        //            state.Attack1 = true;
        //            break;
        //        case 1:
        //            state.Attack2 = 1;
        //            break;
        //    }
        //}

    }
}
