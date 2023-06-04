using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum _pState
    {
        grounded, 
        inAir
    };
    public _pState _state = _pState.grounded;
    PlayerControls _input;
    PlayerData _data;
    Rigidbody _rb;
    public bool _grounded = false;
    [SerializeField]
    LayerMask _ground;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerControls>();
        _data = _input._data;
    }
    private void Update()
    {
        _grounded = Physics.Raycast(transform.position, Vector3.down, _data.playerHeight * 0.5f + 0.2f, _ground);
        if (_grounded)
        {
            _state = _pState.grounded;
        }
        else
        {
            _state = _pState.inAir;

        }
    }

    private void FixedUpdate()
    {
        switch (_state)
        {
            case (_pState.grounded):
                Movement();
                if (_input._jump > 0)
                {
                    Jump();
                    _input._jump = 0;
                }
               // _rb.drag = _data.groundedDrag;
                break;

            case (_pState.inAir):
                // Movement();
                // _rb.drag = _data.groundedDrag;
                AirMove();
                break;
        }

        
    }
    public void Movement()
    {
        Vector3 currrentVelocity = _rb.velocity;
        Vector3 targetVelocity = new Vector3(_input._movement.x, 0, _input._movement.y);
        targetVelocity *= _data.moveSpeed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - currrentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        Vector3.ClampMagnitude(velocityChange, _data.maxForce);

        _rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    public void AirMove()
    {
        Vector3 currrentVelocity = _rb.velocity;
        Vector3 targetVelocity = new Vector3(_input._movement.x, 0, _input._movement.y);
        targetVelocity *= _data.moveSpeed * 10;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - currrentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        Vector3.ClampMagnitude(velocityChange, _data.maxForce);

        _rb.AddForce(targetVelocity, ForceMode.Force);
    }
    public void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * _data.jumpForce, ForceMode.Impulse);
    }
}
