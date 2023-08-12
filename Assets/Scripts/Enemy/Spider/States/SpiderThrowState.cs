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
        DropBoulders(spider);

    }

    public override void UpdateState(SpiderStateManager spider)
    {
        spider.RotateAtPlayer(spider);

        if (_throwCount >= spider._grapplePoints.Length){
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
        if (_spider._currentState != this) return;
        Rigidbody boulderRB = _currentGrapple.GetComponent<SpringJoint>().connectedBody;
        if(boulderRB == null)
        {
            _throwCount++;
            _throwing = false;
            return;
        }
        boulderRB.GetComponent<BossBoulder>()._damaging = true;
        boulderRB.GetComponent<BossBoulder>()._throwing = true;

        _currentGrapple.GetComponent<SpringJoint>().connectedBody = null;
        _currentGrapple.GetComponent<LineCurveRenderer>().enabled = false;
        Vector3 dir = (_spider._target.transform.position - boulderRB.transform.position).normalized;
        boulderRB.drag = 0;
        boulderRB.mass = 1;
        boulderRB.useGravity = false;
        boulderRB.velocity = Vector3.zero;
        boulderRB.AddForce(dir * _spider._data._boulderSpeed, ForceMode.Impulse);
        _throwCount++;
        _throwing = false;
    }
    public void DropBoulders(SpiderStateManager spider)
    {
        foreach (Transform grapplePoint in spider._grapplePoints)
        {
            grapplePoint.DOComplete();
            Rigidbody connected = grapplePoint.GetComponent<SpringJoint>().connectedBody;
            if (connected != null)
            {
                grapplePoint.GetComponent<LineCurveRenderer>().enabled = false;

                connected.GetComponent<BossBoulder>().Explode();
            }
        }
        _throwing = false;
    }
}
