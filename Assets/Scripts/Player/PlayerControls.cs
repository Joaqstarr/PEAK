using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("Input Values")]
    public Vector2 _look;
    public Vector2 _movement;
    public float _jump = 0;
    public bool _jumpHeld = false;
    public bool _fireHeld = false;
    public bool _weaponWheelHeld = false;
    public bool _altFireHeld = false;

    public float _reelValue = 0;

    [Header("Modifiers")]
    public float xSens = 30;
    public float ySens = 30;

    [Header("Misc")]
    public PlayerData _data;
    PlayerInput _inputComp;
    RadialMenu _radial;
    // Start is called before the first frame update
    void Start()
    {
        _inputComp = GetComponent<PlayerInput>();
        _radial = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();
    }


    // Update is called once per frame
    void Update()
    {
        if (_jump > 0)
        {
            _jump -= Time.deltaTime;
        }
        if (_jump < 0)
        {
            _jump = 0;
        }
    }

    public void Look(InputAction.CallbackContext context)
    { 
            Vector2 modifiedInput = new Vector2(context.ReadValue<Vector2>().x * xSens, context.ReadValue<Vector2>().y * ySens);
            _look = modifiedInput;

        

    }
    public void Movement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            _jump = _data.jumpTimer;
            _jumpHeld = true;
        }
        else
        {
            _jumpHeld = false;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {

            _fireHeld = true;
        }
        else
        {
            _fireHeld = false;
        }
    }
    public void WeaponWheel(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            _radial.Open();
            _weaponWheelHeld = true;
        }
        else
        {
            _radial.Close();
            _weaponWheelHeld = false;
        }
    }
    public void AltFire(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            _altFireHeld = true;
        }
        else
        {
            _altFireHeld = false;
        }
    }
    public void Reel(InputAction.CallbackContext context)
    {
        _reelValue = context.ReadValue<float>();

    }
}
