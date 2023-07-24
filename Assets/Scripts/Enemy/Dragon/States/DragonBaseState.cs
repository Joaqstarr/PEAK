using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class DragonBaseState
{

    public abstract void EnterState(DragonStateManager enemy);

    public abstract void UpdateState(DragonStateManager enemy);

    public abstract void ExitState(DragonStateManager enemy);
}
