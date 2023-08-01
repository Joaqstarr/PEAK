using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragonDeadState : DragonBaseState
{
    public override void EnterState(DragonStateManager enemy)
    {
        enemy._soundEffects[3].Play();
        enemy._ikConstraint.DOComplete();
        enemy._pointAtPlayer.DOComplete();
        enemy._aimHeadAtPlayer.DOComplete();
        enemy._ikPosition.DOComplete();
        MonoBehaviour.Destroy(enemy.gameObject, 5f);
        DOVirtual.Float(1, 0, 1, x => enemy._aimHeadAtPlayer.weight = x);


    }

    public override void ExitState(DragonStateManager enemy)
    {
    }

    public override void UpdateState(DragonStateManager enemy)
    {
    }
}
