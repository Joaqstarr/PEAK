using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStateManager : MonoBehaviour
{
    [SerializeField]
    public SoldierBaseClass _currentState;

    public SoldierBaseClass PatrolState = new SoldierPatrolState();
    public SoldierBaseClass AggroState = new SoldierAggroState();
    public SoldierBaseClass AttackState = new SoldierAttackState();
    public SoldierBaseClass CoverState = new SoldierCoverState();
    public SoldierBaseClass RagdollState = new SoldierRagdollState();
    //public SoldierBaseClass RagdollState =

    public Transform _target;
    public SoldierData _data;
    public LayerMask _playerLayer;

    public Animator _animator;

    public Transform _pelvis;
    public Transform _art;
    public Transform _aimPoint;
    public Transform _barrel;

    bool _aimOnTarget = false;
    int _bulletsShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        _bulletsShot = 0;
        _currentState = AggroState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(SoldierBaseClass state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }


    public void Die()
    {
        SwitchState(RagdollState);
    }

    public void Shoot()
    {

        _aimOnTarget = ShouldShotHit();
        AimPoint(this);
        _barrel.GetChild(0).GetComponent<ParticleSystem>().Play();
        _barrel.GetComponent<AudioSource>().Play();
        RaycastHit hit;
        if(Physics.Raycast(_barrel.position, _barrel.up, out hit, 60f, _data.shootLOSMask))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(_barrel.position, _barrel.up * 30, Color.green, 1f);

               // Debug.Log("SHOT HIT");
            }
            else
            {
                Debug.DrawRay(_barrel.position, _barrel.up * 30, Color.red, 1f);
                Debug.Log("miss: " + hit.transform.gameObject.name);
            }
        }
        else
        {
            Debug.Log("airball");
        }
        _bulletsShot++;

    }
    public bool ShouldShotHit()
    {
        return true;

        if (_bulletsShot < _data.initialMisses)
        {
            return false;
        }
        if (Random.Range(0, 100) < 50){
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AimPoint(SoldierStateManager enemy)
    {
        
        enemy._aimPoint.LookAt(enemy.transform);

        Vector3 playerRelativePos = enemy.transform.InverseTransformPoint(enemy._target.position);

        //add missOffset
        if(!_aimOnTarget)
        playerRelativePos.z += 2;


        //enemy._aimPoint.position = enemy._target.position;
        enemy._aimPoint.localPosition = playerRelativePos;
    }
}
