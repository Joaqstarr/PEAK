using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStateManager : MonoBehaviour
{

    SpiderBaseState _currentState;
    public SpiderBaseState _hiddenState { get; private set; } = new SpiderHiddenState();
    public SpiderBaseState _idleState { get; private set; } = new SpiderIdleState();
    public SpiderBaseState _grappleState { get; private set; } = new SpiderGrappleState();
    public SpiderBaseState _throwState { get; private set; } = new SpiderThrowState();
    public SpiderBaseState _hitState { get; private set; } = new SpiderHitState();
    public SpiderBaseState _slamState { get; private set; } = new SpiderSlamState();
    
    public Transform _target { get; private set; }

    public SpiderData _data;
    
    public List<BossBoulder> _boulders = new List<BossBoulder>();
    public GameObject _boulderPrefab;
    public Transform[] _grapplePoints;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player").transform;
        _currentState = _idleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);

    }
    public void SwitchState(SpiderBaseState newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);

    }
}
