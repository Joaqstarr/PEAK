using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IguanaDeadState : IguanaBaseState
{
    Animator _anim;
    public override void EnterState(IguanaStateManager _iguana)
    {
        _iguana.GetComponent<NavMeshAgent>().enabled = false;
        _anim = _iguana.GetComponentInChildren<Animator>();
        _anim.enabled = false;

        Rigidbody[] rigidbodies = _anim.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    public override void ExitState(IguanaStateManager _iguana)
    {
    }

    public override void UpdateState(IguanaStateManager _iguana)
    {
    }


}
