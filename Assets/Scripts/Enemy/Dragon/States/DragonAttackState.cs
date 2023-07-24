using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations.Rigging;

public class DragonAttackState : DragonBaseState
{

    DragonStateManager manager;
    public override void EnterState(DragonStateManager enemy)
    {
        manager = enemy;
        enemy._ikPosition.position = enemy._firePos1.position;


        DOVirtual.Float(0, 1, manager._data._moveHeadDownTime, x =>  enemy._ikConstraint.weight = x).onComplete = OnMovedHeadDown;
       // enemy._ikPosition.DOMove(enemy._firePos2.position, 7f);

    }

    public override void ExitState(DragonStateManager enemy)
    {
    }

    public override void UpdateState(DragonStateManager enemy)
    {
        
    }
    public void OnMovedHeadDown()
    {
        manager._ikPosition.DOMove(manager._firePos2.position, manager._data._moveHeadAcrossTime).onComplete = OnMoveHeadAcross; 

    }

    public void OnMoveHeadAcross()
    {
        DOVirtual.Float(1, 0, manager._data._moveHeadDownTime, x => manager._ikConstraint.weight = x).onComplete = OnHeadReturn;

    }
    public void OnHeadReturn()
    {
        manager.SwitchState(manager._aggro);
    }
}
