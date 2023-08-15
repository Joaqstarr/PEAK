using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldierAggroState : SoldierBaseClass
{
    Transform _target;
    NavMeshAgent _agent;
    SoldierData _data;
    Animator _animator;

    public override void EnterState(SoldierStateManager enemy)
    {
        _agent = enemy.GetComponent<NavMeshAgent>();
        if (enemy._target == null)
            enemy._target = GameObject.Find("Player").transform;
        _target = enemy._target;
        _data = enemy._data;
        _animator = enemy._animator;
        _agent.speed = _data.speed;
    }

    public override void UpdateState(SoldierStateManager enemy)
    {

        if (_target == null)
        {
            enemy.SwitchState(enemy.PatrolState);
            return;
        }


        _agent.SetDestination(_target.position);

        if (Vector3.Distance(_target.position, enemy.transform.position) < _data.range) //&& _attackTime < 0)
        {
            Attack(enemy);
        }

        //animation
        Vector3 agentVelocity = _agent.velocity;
        Vector3 localVelocity = enemy._art.transform.InverseTransformDirection(agentVelocity);
        _animator.SetFloat("XMotion", localVelocity.x);
        _animator.SetFloat("ZMotion", localVelocity.z);
    }

    public override void ExitState(SoldierStateManager enemy)
    {
        
    }

    void Attack(SoldierStateManager enemy)
    {

       
        enemy.SwitchState(enemy.AttackState);
    }
}
