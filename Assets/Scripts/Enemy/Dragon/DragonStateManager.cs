using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class DragonStateManager : MonoBehaviour
{
    public DragonData _data;
    public Transform _target;
    public DragonBaseState _currentState;
    public DragonBaseState _hidden = new DragonHiddenState();
    public DragonBaseState _aggro = new DragonAggroState();
    public DragonBaseState _attack = new DragonAttackState();

    public Animator _anim;
    public Transform _ikPosition;
    public Transform _firePos1;
    public Transform _firePos2;
    public bool _readyToAttack = false;
    public ChainIKConstraint _ikConstraint;
    // Start is called before the first frame update
    void Start()
    {
        
        _currentState = _hidden;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);

    }

    public void SwitchState( DragonBaseState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }
}
