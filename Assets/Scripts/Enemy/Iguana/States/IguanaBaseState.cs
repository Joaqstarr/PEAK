using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IguanaBaseState
{
    public abstract void EnterState(IguanaStateManager _iguana);
    public abstract void UpdateState(IguanaStateManager _iguana);

    public abstract void ExitState(IguanaStateManager _iguana);

}
