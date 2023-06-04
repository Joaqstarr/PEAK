using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    float _attackTime = 0;
    WalkingEnemyData _data;
    
    public override void EnterState(AIStateManager enemy)
    {
        _data = enemy._data;
        _attackTime = _data.attackSpeed;
 
        enemy.GetComponentInChildren<Animator>().SetTrigger("Attack");

    }

    public override void UpdateState(AIStateManager enemy)
    {
        _attackTime -= Time.deltaTime;
        if (_attackTime <= 0) enemy.SwitchState(enemy.AggroState);

    }


    public override void ExitState(AIStateManager enemy)
    { 
    }
}
