using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;public class EnemyAggoState : EnemyBaseState
{
    Transform _target;
    NavMeshAgent _agent;
    WalkingEnemyData _data;
  //  float _attackTime = 0;
    public override void EnterState(AIStateManager enemy)
    {
        _agent = enemy.GetComponent<NavMeshAgent>();
        if (enemy._target == null)
            enemy._target = GameObject.Find("Player").transform;
        _target = enemy._target;
        _data = enemy._data;

        _agent.speed = _data.speed;

    }

    public override void UpdateState(AIStateManager enemy)
    {
      //  _attackTime -= Time.deltaTime;

        if(_target == null)
        {
            enemy.SwitchState(enemy.PatrolState);
            return;
        }


        _agent.SetDestination(_target.position);

        if(Vector3.Distance(_target.position, enemy.transform.position)< _data.range) //&& _attackTime < 0)
        {
            Attack(enemy);
        }
    }
    public override void ExitState(AIStateManager enemy)
    {

    }
    void Attack(AIStateManager enemy)
    {

        //_attackTime = _data.attackSpeed;
        enemy.SwitchState(enemy.AttackState);
    }
}
