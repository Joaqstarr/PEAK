using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations.Rigging;



public class DragonAggroState : DragonBaseState
{
    bool _lastFrameAttackReady = false;
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
        Collider[] playerCheck = Physics.OverlapSphere(enemy.transform.position, enemy._data._leaveDetectionRadius, enemy._data._playerLayer);
        if (playerCheck.Length == 0)
        {
            enemy._target = null;
            enemy.SwitchState(enemy._hidden);
        }

        if (enemy._readyToAttack == true && _lastFrameAttackReady != true)
            DOVirtual.Float(0, 1, enemy._data._moveHeadDownTime, x => enemy._aimHeadAtPlayer.weight = x);

        if (enemy._target != null)
            enemy._aimPosition.position = enemy.GetAimPoint();

        

        if (enemy._readyToAttack)
        {
            _timer -= Time.deltaTime;

        }
        else
        {
            enemy._rumble.GenerateImpulseWithForce(1);
        }
        if (_timer <= 0)
        {

            //ATTACK LOGIC
            if (enemy._flameSpewArea.bounds.Intersects(enemy._target.GetComponent<Collider>().bounds))
            {
                int ranNum = Random.Range(0, 100); 
                if(ranNum < enemy._data._fireSpewChance)
                {
                    enemy.SwitchState(enemy._attack);

                }
                else
                {
                    enemy.SwitchState(enemy._shoot);

                }

            }
            else
            {
                enemy.SwitchState(enemy._shoot);
            }

        }

        _lastFrameAttackReady = enemy._readyToAttack;
    }
}
