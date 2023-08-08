using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaTreeState : IguanaBaseState
{
    IguanaData _iguanaData;
    Animator _anim;
    public override void EnterState(IguanaStateManager _iguana)
    {
        _iguanaData = _iguana._iguanaData;

        Vector3 _clingDir = (_iguana.transform.position - _iguana._tree.transform.position);
        _clingDir.y = 0;
        _clingDir = _clingDir.normalized;
        Vector3 _clingPos = _iguana._tree.transform.position + (_clingDir * _iguanaData.treeClingDistance);
        _clingPos.y = _iguana.transform.position.y;
        _iguana.transform.position = _clingPos;
        _anim = _iguana.GetComponentInChildren<Animator>();

    }

    public override void ExitState(IguanaStateManager _iguana)
    {
    }

    public override void UpdateState(IguanaStateManager _iguana)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_iguana.transform.position, Vector3.down, out hit, _iguanaData.treeHeight, _iguanaData._groundLayer))
        {
            _anim.SetFloat("Speed", 1f);
            _iguana.transform.position = new Vector3(_iguana.transform.position.x, _iguana.transform.position.y + (Time.deltaTime * _iguanaData._climbSpeed), _iguana.transform.position.z);
        }
        else
        {
            _anim.SetFloat("Speed", 0f);

            Collider[] playerCheck = Physics.OverlapSphere(_iguana.transform.position, _iguanaData.sightRange, _iguanaData._playerLayer);
            if (playerCheck.Length > 0)
            {
                _iguana._target = playerCheck[0].transform;
                _iguana.SwitchState(_iguana._glideState);
            }
        }


    }
}
