using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EnemyBaseState
{
    public abstract void EnterState(AIStateManager enemy);

    public abstract void UpdateState(AIStateManager enemy);

    public abstract void ExitState(AIStateManager enemy);


}
