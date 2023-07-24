using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHiddenState : DragonBaseState
{
    DragonData _data;
    public override void EnterState(DragonStateManager enemy)
    {

        _data = enemy._data;
    }
    public override void UpdateState(DragonStateManager enemy)
    {

        Collider[] playerCheck = Physics.OverlapSphere(enemy.transform.position, _data._radius, _data._playerLayer);
        if (playerCheck.Length > 0)
        {
            enemy._target = playerCheck[0].transform;
            enemy.SwitchState(enemy._aggro);
        }
    }

    public override void ExitState(DragonStateManager enemy)
    {
        enemy._anim.SetBool("Hidden", false);
    }
}
