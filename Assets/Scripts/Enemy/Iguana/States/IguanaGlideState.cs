using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IguanaGlideState : IguanaBaseState
{
    Rigidbody _rb;
    IguanaData _data;
    Animator _anim;
    public override void EnterState(IguanaStateManager _iguana)
    {
        Debug.Log("glide state");
        _data = _iguana._iguanaData;
        _rb = _iguana.GetComponent<Rigidbody>();
        _anim = _iguana.GetComponentInChildren<Animator>();
        _rb.isKinematic = false;
        Vector3 targ = _iguana._target.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(_iguana._target.position, out hit, 4.0f, NavMesh.AllAreas))
        {
            targ = hit.position;
        }
        else
        {
            _iguana.SwitchState(_iguana._treeState);
            return;
        }
        
        Vector3 dir = (targ - _iguana.transform.position).normalized;
        _rb.AddForce(dir * _data._glideSpeed, ForceMode.Impulse);
        _anim.SetTrigger("Glide");
        _iguana.GetComponent<AudioSource>().Play();


        _iguana.transform.LookAt(_iguana._target);
        Vector3 eulerAngles = _iguana.transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;

        // Set the altered rotation back
        _iguana.transform.rotation = Quaternion.Euler(eulerAngles);
    }

    public override void ExitState(IguanaStateManager _iguana)
    {
        _rb.isKinematic = true;

    }

    public override void UpdateState(IguanaStateManager _iguana)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_iguana.transform.position, Vector3.down, out hit, _data._groundedDist, _data._groundLayer))
        {
            _iguana.SwitchState(_iguana._walKState);
        }
    }
}
