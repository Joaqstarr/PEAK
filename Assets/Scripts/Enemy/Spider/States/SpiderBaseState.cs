using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpiderBaseState
{
    public abstract void EnterState(SpiderStateManager spider);

    public abstract void UpdateState(SpiderStateManager spider);

    public abstract void ExitState(SpiderStateManager spider);
}
