using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerHealth : MonoBehaviour
{
    public static int _health;
    float _iFrames = 0;
    private PlayerData _data;
    [SerializeField] CinemachineImpulseSource[] _impulseAmount;
    // Start is called before the first frame update
    void Start()
    {
        _data = GetComponent<PlayerControls>()._data;
        _health = _data.maxHealth;

    }

    private void Update()
    {
        _iFrames -= Time.deltaTime;
    }
    public void Damage(int damage, Vector3 _damageFrom, bool isTick, int impulseSize = 0)
    {
        if (impulseSize >= _impulseAmount.Length) impulseSize = 0;
        if(_iFrames < 0 && !isTick)
        {
            _health -= damage;
            _iFrames = _data.iFrameTime;
            Debug.Log(_health);
            _impulseAmount[impulseSize].GenerateImpulseWithForce(1);
        }
        if (isTick)
        {
            _health -= damage;
            Debug.Log(_health);
            _impulseAmount[impulseSize].GenerateImpulseWithForce(1);
        }
    }
}
