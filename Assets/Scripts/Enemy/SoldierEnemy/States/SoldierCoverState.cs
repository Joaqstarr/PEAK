using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldierCoverState : SoldierBaseClass
{
    SoldierData _data;
    NavMeshAgent _agent;
    Animator _animator;
    bool _isInCover = false;
    bool _crouched = true;
    float _crouchTimer = 0;
    float _maxTime;
    int _magazine = 0;
    Transform _chosenNode;
    float _fireTimer = 0;
    public override void EnterState(SoldierStateManager enemy)
    {
        _chosenNode = null;
        _crouchTimer = 0;
        _crouched = true;
        _data = enemy._data;
        _agent = enemy.GetComponent<NavMeshAgent>();
        _animator = enemy._animator;

        _maxTime = Random.Range(_data.randomTime.x, _data.randomTime.y);

        Collider[] nodesInRange = new Collider[_data.maxNodes];

        int numColliders = Physics.OverlapSphereNonAlloc(enemy.transform.position, _data.coverRange, nodesInRange, _data.coverNodeLayer);
        if(numColliders > 0)
        {
            List<Transform> hiddenNodes = new List<Transform>();
            foreach (Collider node in nodesInRange)
            {
                if (node != null)
                {
                    RaycastHit hit;
                    Vector3 dir = enemy._target.position - node.transform.position;
                    dir = dir.normalized;
                    Debug.DrawRay(node.transform.position, dir * 50, Color.green, 60);
                    if (Physics.Raycast(node.transform.position, dir, out hit, 50, _data.coverLineOfSightCheckLayer))
                    {

                        if (!hit.transform.gameObject.CompareTag("Player"))
                            hiddenNodes.Add(node.transform);
                    }
                }
            }
          //  Debug.Log(hiddenNodes.Count);

            if (hiddenNodes.Count > 0)
            {
                Transform closestNode = hiddenNodes[0];
                float closestNodeDist = Vector3.Distance(hiddenNodes[0].position, enemy.transform.position);
                foreach(Transform node in hiddenNodes)
                {
                    float nodeDist = Vector3.Distance(node.position, enemy.transform.position);

                    if (nodeDist < closestNodeDist)
                    {
                        closestNodeDist = nodeDist;
                        closestNode = node;
                    }
                }
                _chosenNode = closestNode;
                _agent.SetDestination(closestNode.position);
                _agent.speed = _data.seekCoverSpeed;
                enemy._aimPoint.position = enemy._target.position;

            }
        }
        else
        {
            enemy.SwitchState(enemy.AttackState);
            Debug.Log("no cover available");
        }

        
    }

    public override void UpdateState(SoldierStateManager enemy)
    {
        if (_chosenNode == null) return;
        if (_isInCover)
        {
            _crouchTimer += Time.deltaTime;
            _fireTimer -= Time.deltaTime;
            if(_crouched && _crouchTimer > _maxTime)
            {
                if (Random.Range(0, 100) < _data.exitCoverChance)
                {
                    ExitCover(enemy);
                    return;
                }
                else
                {
                    _animator.SetBool("crouch", false);
                    _crouched = false;
                    _magazine = _data.burstAmount;
                }

            }
            if(_magazine == 0 && _crouched == false)
            {
                if (Random.Range(0, 100) < _data.exitCoverChance)
                {
                    ExitCover(enemy);
                    return;
                }
                else
                {
                    _crouched = true;
                    _animator.SetBool("crouch", true);
                }

            }

            if(_magazine > 0 && _fireTimer <= 0)
            {
                Shoot(enemy);
            }



            Vector3 dir = enemy._target.position - _chosenNode.position;
            dir = dir.normalized;
            RaycastHit hit;
            if(Physics.Raycast(_chosenNode.position, dir, out hit, 50, _data.coverLineOfSightCheckLayer))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    ExitCover(enemy);
                    return;
                }
            }

        }







       // animation
       if(_agent.velocity.magnitude < 0.2 && !_isInCover && Vector3.Distance(_chosenNode.position, enemy.transform.position)<1.2)
        {
            _isInCover = true;
            _animator.SetBool("crouch", true);
        }
        LookAtPLayer(enemy);

        Vector3 agentVelocity = _agent.velocity;
        Vector3 localVelocity = enemy._art.transform.InverseTransformDirection(agentVelocity);
        // Debug.Log(localVelocity);
        _animator.SetFloat("XMotion", localVelocity.x);
        _animator.SetFloat("ZMotion", localVelocity.z);

        enemy.AimPoint(enemy);
    }

    public override void ExitState(SoldierStateManager enemy)
    {
       // throw new System.NotImplementedException();
    }

    void LookAtPLayer(SoldierStateManager enemy)
    {
        Vector3 directionToPlayer = enemy._target.position;
        directionToPlayer.y = enemy._art.transform.position.y;

        enemy._art.transform.LookAt(directionToPlayer);
    }



    void Shoot(SoldierStateManager enemy)
    {
        _crouchTimer = 0;
        _maxTime = Random.Range(_data.randomTime.x, _data.randomTime.y);
        enemy.Shoot();
        _fireTimer = _data.attackSpeed;
        Debug.Log("FIRE");
        _magazine -=  1;
    }

    void ExitCover(SoldierStateManager enemy)
    {
        _isInCover = false;
        _animator.SetBool("crouch", false);
        _crouched = false;

        enemy.SwitchState(enemy.AggroState);
    }
}
