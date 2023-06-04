using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SoldierBaseClass 
{
    public abstract void EnterState(SoldierStateManager enemy);

    public abstract void UpdateState(SoldierStateManager enemy);

    public abstract void ExitState(SoldierStateManager enemy);
}
