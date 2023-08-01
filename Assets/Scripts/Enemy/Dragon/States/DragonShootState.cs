using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DragonShootState : DragonBaseState
{
    DragonData _data;
    public override void EnterState(DragonStateManager enemy)
    {
        _data = enemy._data;
        enemy._anim.SetBool("MouthOpen", true);
        enemy.StartCoroutine(FireProjectile(enemy));
        enemy._soundEffects[1].Play();

    }

    public override void ExitState(DragonStateManager enemy)
    {
    }

    public override void UpdateState(DragonStateManager enemy)
    {
        if (enemy._target != null)
            enemy._aimPosition.position = enemy.GetAimPoint();

    }
    IEnumerator FireProjectile(DragonStateManager enemy)
    {
        yield return new WaitForSeconds(0.2f);
        enemy._anim.SetBool("MouthOpen", false);
        //instantiate projectile
        ProjectileFire fireBall = enemy._fireBall.GetPooledObject().GetComponent<ProjectileFire>();
        fireBall.transform.position = enemy._fireParticle.transform.position;
        fireBall._speed = _data.fireballSpeed;
        fireBall._direction = Vector3.zero;
        Vector3 newTargetPos;
        Vector3 averageVelocity = enemy.CalculateAverageVelocity(enemy.pastPositions);
        Vector3 aimPos = enemy._aimPosition.position;
        if (enemy.TryCalculateFiringSolution(enemy._target.position, averageVelocity, _data.fireballSpeed, out newTargetPos)) aimPos = newTargetPos;

        fireBall._direction = (aimPos - enemy._fireParticle.transform.position).normalized;
        fireBall._damage = _data.fireballDamage;
        fireBall.gameObject.SetActive(true);

        //  yield return new WaitForSeconds(0.2f);

        enemy.SwitchState(enemy._aggro);

        
    }

}
