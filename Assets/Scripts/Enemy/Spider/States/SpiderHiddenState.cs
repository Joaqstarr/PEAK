using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHiddenState : SpiderBaseState
{
    public override void EnterState(SpiderStateManager spider)
    {
    }

    public override void ExitState(SpiderStateManager spider)
    {
        FadeToBlack._fading = false;
        spider._handCamera.SetActive(true);


    }

    public override void UpdateState(SpiderStateManager spider)
    {
    }
}
