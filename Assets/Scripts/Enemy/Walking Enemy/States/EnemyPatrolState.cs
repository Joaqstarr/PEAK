using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrolState : EnemyBaseState
{
    WalkingEnemyData _data;
    Vector3 walkpoint;
    Transform _enemyTrans;
    bool walkpointSet = false;
    NavMeshAgent _agent;
    public override void EnterState(AIStateManager enemy)
    {
        _data = enemy._data;
        _enemyTrans = enemy.transform;
        _agent = enemy.GetComponent<NavMeshAgent>();

        _agent.speed = _data.patrolSpeed;
    }

    public override void UpdateState(AIStateManager enemy)
    {
        if (_data == null) return;
        if (_agent == null) return;

        if (!walkpointSet) SearchWalkPoint();
        else
        {
            _agent.SetDestination(walkpoint);
        }
       
        if (Vector3.Distance(_enemyTrans.position, walkpoint) < 2) walkpointSet = false;

        Collider[] playerCheck = Physics.OverlapSphere(enemy.transform.position, _data.sightRange, enemy._playerLayer);
        if (playerCheck.Length > 0) 
        {
            enemy._target = playerCheck[0].transform;
            enemy.SwitchState(enemy.AggroState);
        }

    }

    public override void ExitState(AIStateManager enemy)
    {

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-_data.patrolRange, _data.patrolRange);
        float randomX = Random.Range(-_data.patrolRange, _data.patrolRange);

        Vector3 checkPoint = new Vector3(_enemyTrans.position.x + randomX, _enemyTrans.position.y, _enemyTrans.position.z + randomZ);
        NavMeshHit hit;
        if(NavMesh.SamplePosition(checkPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            walkpoint = hit.position;
            walkpointSet = true;
        }
        
    }
}
