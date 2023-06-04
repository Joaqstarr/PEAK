using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldierAttackState : SoldierBaseClass
{
    float strafeDistance = 4;
    NavMeshAgent _agent;
    Animator _animator;
    SoldierData _data;
    float ranTime;
    float stateTimer;
    float _inbetweenBurstTimer = 0;
    bool _firing = false;
    int _magazine;
    float _fireTimer = 0;
    public override void EnterState(SoldierStateManager enemy)
    {
        enemy._aimPoint.position = enemy._target.position;
        _agent = enemy.GetComponent<NavMeshAgent>();
        _animator = enemy._animator;
        _data = enemy._data;
        strafeDistance = Random.Range(_data.strafeSpeed.x, _data.strafeSpeed.y);

        if (Mathf.Abs(strafeDistance) < 0.5)
        {
            strafeDistance = 0;
            _agent.speed = Mathf.Abs(0.5f);

        }
        else
        {
            _agent.speed = Mathf.Abs(strafeDistance);

        }
     //   Debug.Log(strafeDistance);

        stateTimer = 0;
        ranTime = Random.Range(_data.randomTime.x, _data.randomTime.y);

        if(Random.Range(0, 100)<= _data.coverChance)
        {
            enemy.SwitchState(enemy.CoverState);
        }
    }

    public override void UpdateState(SoldierStateManager enemy)
    {
        _inbetweenBurstTimer -= Time.deltaTime;
        _fireTimer -= Time.deltaTime;

        
        if (_inbetweenBurstTimer <= 0 && _firing == false)
        {
            if (SightCheck(enemy))
            {
                _magazine = Random.Range(_data.minBurst, _data.maxBurst);
                _firing = true;
            }

        }
        if (_firing)
        {
            if(_magazine > 0 && _fireTimer <= 0)
            {
                Shoot(enemy);
            }
            if(_magazine <= 0)
            {
                _firing = false;
                _inbetweenBurstTimer = Random.Range(_data.randomTime.x, _data.randomTime.y);
            }
        }
        
        
        
        
        
        
        
        DistanceCheck(enemy);


        Vector3 playerToSoldier = enemy.transform.position - enemy._target.position;
        Vector3 right = Vector3.Cross(playerToSoldier.normalized, Vector3.up);
        Vector3 strafePosition = enemy.transform.position + (right * strafeDistance);

        _agent.SetDestination(strafePosition);
        LookAtPLayer(enemy);

        Vector3 agentVelocity = _agent.velocity;
        Vector3 localVelocity = enemy._art.transform.InverseTransformDirection(agentVelocity);
       // Debug.Log(localVelocity);
        _animator.SetFloat("XMotion", localVelocity.x);
        _animator.SetFloat("ZMotion", localVelocity.z);

        stateTimer += Time.deltaTime;
        if (stateTimer >= ranTime) enemy.SwitchState(enemy.AttackState);

        enemy.AimPoint(enemy);
    }

    public override void ExitState(SoldierStateManager enemy)
    {
       // Debug.Log("exit");
     ///   throw new System.NotImplementedException();
    }

    void LookAtPLayer(SoldierStateManager enemy)
    {
        Vector3 directionToPlayer =   enemy._target.position;
        directionToPlayer.y = enemy._art.transform.position.y;

        enemy._art.transform.LookAt(directionToPlayer);
    }



    void DistanceCheck(SoldierStateManager enemy)
    {
        if (Vector3.Distance(enemy._target.position, enemy.transform.position) > _data.range) //&& _attackTime < 0)
        {
            enemy.SwitchState(enemy.AggroState);
        }
    }

    bool SightCheck(SoldierStateManager enemy)
    {
        RaycastHit hit;
        Vector3 dir = enemy._target.position - enemy._barrel.transform.position;

        if (Physics.Raycast(enemy._barrel.transform.position, dir, out hit, _data.coverLineOfSightCheckLayer)) return true;
        else return false;
    }
    void Shoot(SoldierStateManager enemy)
    {
        _fireTimer = _data.attackSpeed;
        _magazine -= 1;
        enemy.Shoot();

    }
}
