using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDamage : MonoBehaviour
{
    public PlayerData _data;
    public float _oxygen;
    PlayerHealth _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = GetComponent<PlayerHealth>();
        _data = GetComponent<PlayerControls>()._data;
        _oxygen = _data.breatheTime;
    }
    private void Update()
    {
        if(!UnderwaterEffects._underwater)
            _oxygen = _data.breatheTime;
        else
            _oxygen -= Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<PlayerHealth>()._scuba) return;

        if (_oxygen <= 0) _health.Damage(_data.waterDamage, transform.position, true);
    }
}
