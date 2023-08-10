using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpiderThrowState : SpiderBaseState
{
    bool _throwing = false;
    int _throwCount = 0;
    Transform _currentGrapple;
    SpiderStateManager _spider;
    public override void EnterState(SpiderStateManager spider)
    {
        _spider = spider;
        _throwCount = 0;
    }

    public override void ExitState(SpiderStateManager spider)
    {
    }

    public override void UpdateState(SpiderStateManager spider)
    {
        if(_throwCount >= spider._grapplePoints.Length){
            spider.SwitchState(spider._idleState);
            return;
        }
        if(!_throwing){
            Throw(spider._grapplePoints[_throwCount]);
        }
    }
    void Throw(Transform grapple){
        _currentGrapple = grapple;
        _throwing = true;
        grapple.DOLocalMove(new Vector3(0, -4,0), 1f).onComplete = Launch;
    }
    private void Launch(){
        Rigidbody boulderRB = _currentGrapple.GetComponent<SpringJoint>().connectedBody;
        _currentGrapple.GetComponent<SpringJoint>().connectedBody = null;
        _currentGrapple.GetComponent<LineCurveRenderer>().enabled = false;
        Vector3 dir = (_spider._target.transform.position - boulderRB.transform.position).normalized;
        boulderRB.drag = 0;
        boulderRB.useGravity = false;
        boulderRB.AddForce(dir * _spider._data._boulderSpeed, ForceMode.Impulse);
        _throwCount++;
        _throwing = false;
    }
}
