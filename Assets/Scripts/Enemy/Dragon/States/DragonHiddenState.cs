using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHiddenState : DragonBaseState
{
    DragonData _data;
    public override void EnterState(DragonStateManager enemy)
    {
        enemy._readyToAttack = false;
        _data = enemy._data;
        enemy._anim.SetBool("Hidden", true);

    }
    public override void UpdateState(DragonStateManager enemy)
    {

        Collider[] playerCheck = Physics.OverlapSphere(enemy.transform.position, _data._radius, _data._playerLayer);
        if (playerCheck.Length > 0)
        {
            enemy._target = playerCheck[0].transform;
            enemy.previousPosition = enemy._target.position;
            enemy.SwitchState(enemy._aggro);
        }
    }

    public override void ExitState(DragonStateManager enemy)
    {
        enemy._soundEffects[0].Play();
        enemy._anim.SetBool("Hidden", false);
        //enemy._rumble.GenerateImpulse(1);
    }
}
