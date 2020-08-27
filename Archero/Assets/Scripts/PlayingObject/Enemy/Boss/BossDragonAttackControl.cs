using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragonAttackControl : AttackControlBase
{
    protected Transform playerTransform;
    [SerializeField] EnemyState state;
    //index=0 => Ban ra 3 qua cau lua
    //index=1 => Lao toi enemy va quay 1 vong (overlap)
    //index=2 => Phun lua hinh non - lam sau
    //bool isLowHP = false;
    //public bool IsLowHP
    //{
    //    get => isLowHP;
    //    set
    //    {
    //        state.IsLowHP = true;
    //        isLowHP = value;
    //    }
    //}
    float delaySwitchAttack = 4f;   //Kiem tra va switch attack moi 4 giay
    float countDelay = 0f;
    protected virtual void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
    }

    public override void UpdateNormal()
    {
        countDelay -= Time.deltaTime;
        if (countDelay < 0)
        {
            countDelay = delaySwitchAttack;
            SwitchAttack();
        }
        //else if (countDelay<1)  //idle 1 luc
        //{
        //    state.IsFlameAttack = false;
        //    state.TailAttack = 0;
        //}
        //switch index
        //attackBase.CurAttack = attacks[index];
    }
    void SwitchAttack()
    {
        int i = index;
        if (Vector3.Distance(transform.position, playerTransform.position)<10f)
        {
            index = 1;
        }
        else
        {
            //if (!isLowHP)
                index = 0;
            //else
            //    index = 2;
        }
        if (index!=i)
        {
            state.Attack1 = false;
            state.Attack2 = 0;
            if (attackBase.CurAttackStyle!=null)
                attackBase.CurAttackStyle.enabled = false;
            attackBase.CurAttackStyle = attackStyles[index];
            switch (index)
            {
                case 0:
                    state.Attack1 = true;
                    break;
                case 1:
                    state.Attack2 = 1;
                    break;
            }
        }
            
    }
}
