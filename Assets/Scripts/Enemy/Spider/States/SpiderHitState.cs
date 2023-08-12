using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHitState : SpiderBaseState
{
    public override void EnterState(SpiderStateManager spider)
    {
        spider._anim.SetTrigger("Hit");
        spider._throwState.ExitState(spider);
        spider._health--;
    }

    public override void ExitState(SpiderStateManager spider)
    {
    }

    public override void UpdateState(SpiderStateManager spider)
    {
    }
}
