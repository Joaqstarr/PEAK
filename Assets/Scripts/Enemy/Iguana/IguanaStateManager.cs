using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaStateManager : MonoBehaviour
{
    public IguanaData _iguanaData;
    
    IguanaBaseState _currentState;
    public IguanaBaseState _treeState = new IguanaTreeState();
    public IguanaBaseState _glideState = new IguanaGlideState();
    public IguanaBaseState _walKState = new IguanaWalk();
    public IguanaBaseState _deadState = new IguanaDeadState();

    public Transform _target;
    public GameObject _tree;

    // Start is called before the first frame update
    void Start()
    {
        _currentState = _treeState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);

    }
    public void SwitchState(IguanaBaseState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);

    }
    public void Dead()
    {
        SwitchState(_deadState);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(_currentState == _glideState)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().Damage(_iguanaData.damage, transform.position, false, 1);
            }
        }
    }
}
