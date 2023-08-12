using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_dead : SpiderBaseState
{
    public override void EnterState(SpiderStateManager spider)
    {
        spider._target.GetComponent<PlayerHealth>()._spiderDead = true;
        spider._anim.SetBool("Dead", true);
    }

    public override void ExitState(SpiderStateManager spider)
    {
    }

    public override void UpdateState(SpiderStateManager spider)
    {
    }
}
