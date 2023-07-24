using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragonAggroState : DragonBaseState
{
    float _timer;
    public override void EnterState(DragonStateManager enemy)
    {
        _timer = enemy._data._attackTimer;
    }

    public override void ExitState(DragonStateManager enemy)
    {
       
    }

    public override void UpdateState(DragonStateManager enemy)
    {
        if (enemy._readyToAttack)
            _timer -= Time.deltaTime;
        if (_timer <= 0)
            enemy.SwitchState(enemy._attack);
    }
}
