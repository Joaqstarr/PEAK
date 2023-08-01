using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSpew : MonoBehaviour
{
    public bool _attacking;
    PlayerHealth _target;
    DragonData _data;
    [SerializeField] private int _damage;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.root.GetComponent<DragonStateManager>())
            _data = transform.root.GetComponent<DragonStateManager>()._data;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (_target == null) return;
        if (!_attacking) return;

        int _dealtDamage = _damage;
        if (_data != null)
            _dealtDamage = _data._flameSpewDamage;
        _target.Damage(_dealtDamage, transform.position, true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _target = other.GetComponent<PlayerHealth>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _target = null;
        }
    }
}
