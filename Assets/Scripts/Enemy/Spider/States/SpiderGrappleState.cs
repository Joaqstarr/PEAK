using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpiderGrappleState : SpiderBaseState
{
    SpiderStateManager _spider;
    public override void EnterState(SpiderStateManager spider)
    {

        _spider = spider;
        foreach (Transform _grapplePoint in spider._grapplePoints)
        {
            if(spider._boulders.Count == 0)break;
            int randomBoulder = Random.Range(0, spider._boulders.Count - 1);
            Debug.Log(randomBoulder);
            
            BossBoulder grabbedBoulder = spider._boulders[randomBoulder];
            _grapplePoint.position = grabbedBoulder.transform.position;
            // _grapplePoint.GetComponent<SpringJoint>().maxDistance = Vector3.Distance(spider._grapplePoint.transform.position, grabbedBoulder.transform.position);
            _grapplePoint.GetComponent<LineCurveRenderer>()._endPoint = grabbedBoulder.transform;
            _grapplePoint.GetComponent<LineCurveRenderer>().enabled = true;
            _grapplePoint.GetComponent<SpringJoint>().connectedBody = grabbedBoulder.GetComponent<Rigidbody>();
            spider._boulders.Remove(grabbedBoulder);
            grabbedBoulder.GetComponent<Rigidbody>().isKinematic = true;
            spider.StartCoroutine(WaitBeforeYank(_grapplePoint));

        }
        spider.StartCoroutine(EndGrapple(spider));
    }
    IEnumerator WaitBeforeYank(Transform yanker)
    {
        yield return new WaitForSeconds(3f);
        yanker.GetComponent<SpringJoint>().connectedBody.isKinematic = false;

        yanker.DOLocalMove(Vector3.zero, 6f);

    }
    

    
    IEnumerator EndGrapple(SpiderStateManager spider)
    {
        yield return new WaitForSeconds(8.5f);
        spider.SwitchState(spider._throwState);
    }

    public override void ExitState(SpiderStateManager spider)
    {
    }

    public override void UpdateState(SpiderStateManager spider)
    {
        spider.RotateAtPlayer(spider);

    }
}
