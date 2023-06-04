using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRagdollState : EnemyBaseState
{
    bool _adjusted = false;
    Animator _anim;
    float _timer = 0;
    float _maxTimer = 3;
    public override void EnterState(AIStateManager enemy)
    {
        enemy.GetComponent<NavMeshAgent>().isStopped = true;

        _anim = enemy.GetComponentInChildren<Animator>();

        Rigidbody[] rigidbodies = _anim.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        _anim.enabled = false;
        // enemy.GetComponent<NavMeshAgent>();

       _timer = 0;

    }

    public override void UpdateState(AIStateManager enemy)
    {
        if (enemy._pelvis.GetComponent<Rigidbody>().velocity.magnitude < 0.01 && _adjusted == false && _timer >= _maxTimer)
        {
            _adjusted = true;
            Vector3 newPos = enemy._pelvis.position;
            enemy.transform.position = newPos;
            enemy._pelvis.localPosition = new Vector3(0, enemy._pelvis.localPosition.y, 0);
           // Debug.Log("FARTTTTTTTTTTTTTTTTTTTTT");
        }
        _timer += Time.deltaTime;
    }

    public override void ExitState(AIStateManager enemy)
    {
        Rigidbody[] rigidbodies = _anim.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        _anim.enabled = true;
        enemy.GetComponent<NavMeshAgent>().isStopped = false;

    }
}
