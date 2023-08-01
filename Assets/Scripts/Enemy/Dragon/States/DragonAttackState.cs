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

        DOVirtual.Float(1, 0, manager._data._moveHeadDownTime, x => manager._pointAtPlayer.weight = x);
        DOVirtual.Float(1, 0, manager._data._moveHeadDownTime, x => manager._aimHeadAtPlayer.weight = x);
        DOVirtual.Float(0, 1, manager._data._moveHeadDownTime, x => manager._ikConstraint.weight = x).SetEase(Ease.OutBack).onComplete = OnMovedHeadDown;
        // enemy._ikPosition.DOMove(enemy._firePos2.position, 7f);
        manager._anim.SetBool("MouthOpen", true);

    }

    public override void ExitState(DragonStateManager enemy)
    {
    }

    public override void UpdateState(DragonStateManager enemy)
    {
        if(enemy._fireParticle.isEmitting)
            enemy._rumble.GenerateImpulseWithForce(0.3f);

        if (enemy._target != null)
            enemy._aimPosition.position = enemy._target.position;
    }
    public void OnMovedHeadDown()
    {
        manager._ikPosition.DOMove(manager._firePos2.position, manager._data._moveHeadAcrossTime).SetEase(Ease.InOutBack).onComplete = OnMoveHeadAcross;
        manager._fireParticle.Play();
        manager._flameSpewFunction._attacking = true;
        manager._soundEffects[2].Play();

    }

    public void OnMoveHeadAcross()
    {
        manager._anim.SetBool("MouthOpen", false);

        DOVirtual.Float(1, 0, manager._data._moveHeadDownTime, x => manager._ikConstraint.weight = x).SetEase(Ease.OutBack).onComplete = OnHeadReturn;
        DOVirtual.Float(0, 1, manager._data._moveHeadDownTime, x => manager._pointAtPlayer.weight = x);
        DOVirtual.Float(0, 1, manager._data._moveHeadDownTime, x => manager._aimHeadAtPlayer.weight = x);
        manager._fireParticle.Stop();
        manager._flameSpewFunction._attacking = false;

    }
    public void OnHeadReturn()
    {
        manager.SwitchState(manager._aggro);
    }
}
