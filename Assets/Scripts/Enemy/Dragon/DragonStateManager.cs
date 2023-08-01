using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;
public class DragonStateManager : MonoBehaviour
{
    public DragonData _data;
    public Transform _target;
    [field: SerializeField] public Transform _aimPosition { get; private set; }

    public DragonBaseState _currentState;
    public DragonBaseState _hidden { get; private set; } = new DragonHiddenState();
    public DragonBaseState _aggro { get; private set; } = new DragonAggroState();
    public DragonBaseState _attack { get; private set; } = new DragonAttackState();
    public DragonBaseState _shoot { get; private set; } = new DragonShootState();
    public DragonBaseState _dead { get; private set; } = new DragonDeadState();

    public CinemachineImpulseSource _rumble;


    public Animator _anim;
    public Transform _ikPosition;
    public Transform _firePos1;
    public Transform _firePos2;
    public bool _readyToAttack = false;
    [field: SerializeField] public ChainIKConstraint _ikConstraint { get; private set; }
    [field: SerializeField]public MultiAimConstraint _pointAtPlayer { get; private set; }
    [field: SerializeField] public MultiAimConstraint _aimHeadAtPlayer { get; private set; }

    [field:SerializeField] public Collider _flameSpewArea { get; private set; }
    [field: SerializeField] public FlameSpew _flameSpewFunction { get; private set; }
    [field: SerializeField] public ObjectPooler _fireBall { get; private set; }


    [field: SerializeField] public ParticleSystem _fireParticle { get; private set; }

    //calculate moving target
    public Queue pastPositions;
    public Vector3 previousPosition;
    [field: SerializeField] public int frameCount { get; private set; }
    [SerializeField]
    public AudioSource[] _soundEffects;

// Start is called before the first frame update
void Start()
    {
        _fireBall = GameObject.Find("FireballObjectPooler").GetComponent<ObjectPooler>();
        _currentState = _hidden;
        _currentState.EnterState(this);
        pastPositions = new Queue(frameCount);
        
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

    public void Die()
    {
        _anim.SetTrigger("Dead");
        SwitchState(_dead);
    }

    public bool TryCalculateFiringSolution(Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed, out Vector3 firingSolution)
    {
        Vector3 deltaPosition = targetPosition - transform.position;
        float a = Vector3.Dot(targetVelocity, targetVelocity) - projectileSpeed * projectileSpeed;
        float b = 2f * Vector3.Dot(targetVelocity, deltaPosition);
        float c = Vector3.Dot(deltaPosition, deltaPosition);

        float discriminant = b * b - 4f * a * c;

        if (discriminant < 0)
        {
            firingSolution = Vector3.zero;
            return false;
        }

        float t1 = (-b + Mathf.Sqrt(discriminant)) / (2f * a);
        float t2 = (-b - Mathf.Sqrt(discriminant)) / (2f * a);

        if (t1 < 0 && t2 < 0)
        {
            firingSolution = Vector3.zero;
            return false;
        }

        float t = Mathf.Max(t1, t2);
        firingSolution = targetPosition + targetVelocity * t;
        return true;
    }

    public Vector3 GetAimPoint()
    {
        pastPositions.Enqueue(_target.GetComponent<Rigidbody>().velocity);
        if (pastPositions.Count > frameCount)
        {
            pastPositions.Dequeue();
        }
        return _target.position;



        Vector3 averageVelocity = CalculateAverageVelocity(pastPositions);
        Vector3 newTargetPos;

        previousPosition = _target.position;

        if (TryCalculateFiringSolution(_target.position, averageVelocity, _data.fireballSpeed, out newTargetPos))
        {
            return newTargetPos;

        }
        else
        {
            return  _target.position;
        }
    }
    public Vector3 CalculateAverageVelocity(Queue velocities)
    {
        Vector3 sum = Vector3.zero;
        foreach (Vector3 velocity in velocities)
        {
            sum += velocity;
        }
        //Debug.Log(sum / velocities.Count);
        return sum / velocities.Count;
    }
}
