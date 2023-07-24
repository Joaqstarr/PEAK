using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Rotation Pivots")]
    [SerializeField]
    Transform _horizontalRotationTrans;
    [SerializeField]
    Transform _verticalRotationTrans;

    [Header("Input")]
    [SerializeField]
    PlayerControls _input;
    PlayerData _data;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerControls>();
        _data = _input._data;
        Cursor.lockState = CursorLockMode.Locked;
        _verticalRotationTrans.eulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalRotationTrans.rotation = Quaternion.Euler(_horizontalRotationTrans.eulerAngles.x, _horizontalRotationTrans.eulerAngles.y + _input._look.x * _data.sensitivity, _horizontalRotationTrans.eulerAngles.z);
        float newVertRot = _verticalRotationTrans.eulerAngles.x  - _input._look.y * _data.sensitivity;
        if (180 > newVertRot  && newVertRot > _data.maxAngle)
        {
           newVertRot = _data.maxAngle;
          //  Debug.Log("PEE");

        }
        else if (newVertRot >= 180 && newVertRot < (360- _data.maxAngle))
        {
              newVertRot = - _data.maxAngle;
         //   Debug.Log("POOP");
        }
        _verticalRotationTrans.rotation = Quaternion.Euler(newVertRot, _verticalRotationTrans.eulerAngles.y, _verticalRotationTrans.eulerAngles.z);
       
    }
}
