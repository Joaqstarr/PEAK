using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    Transform _target;
    NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_target.position);
    }
}
