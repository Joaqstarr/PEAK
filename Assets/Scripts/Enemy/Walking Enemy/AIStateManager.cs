using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{
    [SerializeField]
    public EnemyBaseState _currentState;

    public EnemyBaseState PatrolState = new EnemyPatrolState();
    public EnemyBaseState AggroState = new EnemyAggoState();
    public EnemyBaseState AttackState = new EnemyAttackState();
    public EnemyBaseState RagdollState = new EnemyRagdollState();

    public Transform _target;
    public WalkingEnemyData _data;
    public LayerMask _playerLayer;

    public Animator _animator;

    public Transform _pelvis;
    // Start is called before the first frame update
    void Start()
    {
        _currentState = PatrolState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
        UpdateAnimParams();
    }

    public void SwitchState(EnemyBaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }

    public void UpdateAnimParams()
    {
        _animator.SetFloat("Speed", GetComponent<NavMeshAgent>().velocity.magnitude);
    }

    public void Die()
    {
        SwitchState(RagdollState);
    }
    public void Aggro()
    {
        if (_currentState == PatrolState)
        {
            SwitchState(AggroState);

        }
    }
}
