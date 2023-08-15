using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStateManager : MonoBehaviour
{
    public int _health;
    public SpiderBaseState _currentState;
    public SpiderBaseState _hiddenState { get; private set; } = new SpiderHiddenState();
    public SpiderBaseState _idleState { get; private set; } = new SpiderIdleState();
    public SpiderBaseState _grappleState { get; private set; } = new SpiderGrappleState();
    public SpiderBaseState _throwState { get; private set; } = new SpiderThrowState();
    public SpiderBaseState _hitState { get; private set; } = new SpiderHitState();
    public SpiderBaseState _slamState { get; private set; } = new SpiderSlamState();
    public SpiderBaseState _deadState { get; private set; } = new Spider_dead();


    public Transform _target { get; private set; }

    public SpiderData _data;
    
    public List<BossBoulder> _boulders = new List<BossBoulder>();
    public GameObject _boulderPrefab;
    public Transform[] _grapplePoints;
    public Animator _anim;
    public GameObject _handCamera { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        _handCamera = GameObject.Find("HandCamera");
        _target = GameObject.Find("Player").transform;
        _health = _data._hitsToKill;
        _currentState = _hiddenState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);

    }
    public void SwitchState(SpiderBaseState newState)
    {
        if(_currentState != null)
            _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);

    }

    public void RotateAtPlayer(SpiderStateManager spider)
    {
        Vector3 _targetPos = spider._target.transform.position;
        _targetPos.y = spider.transform.position.y;
        if (Vector3.Distance(_targetPos, spider.transform.position) > _data._rotationDeadzone)
        {
            Vector3 dir = (_targetPos - spider.transform.position).normalized;
            Vector3 rotateAmount = Vector3.RotateTowards(spider.transform.forward, dir, _data._rotationSpeed * Time.deltaTime, 1f);
         //   Debug.Log((spider.transform.forward - dir).normalized.magnitude);
            float animSpeed = 0;
            if ((spider.transform.forward - dir).normalized.x < 0) animSpeed = -1f;
            if ((spider.transform.forward - dir).normalized.x > 0) animSpeed = 1f;

            //if (animSpeed != 0)
                _anim.SetFloat("Speed", animSpeed);//Mathf.Lerp(_anim.GetFloat("speed"), animSpeed, Time.deltaTime * _data._rotationAnimLerp));
            spider.transform.rotation = Quaternion.LookRotation(rotateAmount, Vector3.up);
        }
    }
    public void ActivateBoss()
    {
        if(_currentState != _hiddenState)return;
        _handCamera.SetActive(false);
        _anim.SetTrigger("Activate");
        FadeToBlack._fading = true;
    }
    public void TakeDamage()
    {
        if (_currentState == _hitState || _currentState == _deadState || _currentState == _hiddenState) return;
        if (_health <= 0)
        {
            SwitchState(_deadState);
            return;
        }
            SwitchState(_hitState);
    }
}
