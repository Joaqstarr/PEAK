using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IguanaWalk : IguanaBaseState
{
    float _minTimer = 1f;
    NavMeshAgent _agent;

    Animator _anim;
    public override void EnterState(IguanaStateManager _iguana)
    {
        _minTimer = 1f;
        _anim = _iguana.GetComponentInChildren<Animator>();
        _anim.SetTrigger("Ground");
        _agent = _iguana.GetComponent<NavMeshAgent>();
        _agent.enabled = true;
        Vector3 treeToPlayerDir = (_iguana._target.position - _iguana._tree.transform.position).normalized;
        Vector3 newPos = _iguana._tree.transform.position + (treeToPlayerDir * _iguana._iguanaData.treeDistance);
        _agent.SetDestination(newPos);

    }

    public override void ExitState(IguanaStateManager _iguana)
    {
        _agent.enabled = false;
        _anim.SetTrigger("Climb");

    }

    public override void UpdateState(IguanaStateManager _iguana)
    {
        _minTimer -= Time.deltaTime;
        _anim.SetFloat("Speed", _agent.velocity.magnitude);

        if (_minTimer > 0) return;
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                _iguana.SwitchState(_iguana._treeState);

            }
        }

    }
}
