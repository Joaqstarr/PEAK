using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IguanaWalk : IguanaBaseState
{
    NavMeshAgent _agent;

    Animator _anim;
    public override void EnterState(IguanaStateManager _iguana)
    {
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
        _anim.SetFloat("Speed", _agent.velocity.magnitude);
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                _iguana.SwitchState(_iguana._treeState);

            }
        }

    }
}
