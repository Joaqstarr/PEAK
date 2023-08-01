using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPatrolState : SoldierBaseClass
{
    public override void EnterState(SoldierStateManager enemy)
    {
    }

    public override void UpdateState(SoldierStateManager enemy)
    {
        Collider[] playerCheck = Physics.OverlapSphere(enemy.transform.position, enemy._data.sightRange,  enemy._data.playerLayer);
        if (playerCheck.Length > 0)
        {
            enemy._target = playerCheck[0].transform;

            enemy.SwitchState(enemy.AggroState);
        }
    }

    public override void ExitState(SoldierStateManager enemy)
    {
    }
}
