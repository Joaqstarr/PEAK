using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileStick : MonoBehaviour
{
    private bool _isStuck = false;
    private Rigidbody _rb;
    [SerializeField]
    Collider _boxCollider;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void OnEnable()
    {
        _isStuck = false;
        _rb = GetComponent<Rigidbody>();

        _boxCollider.enabled = true;
        if(_rb != null)
             _rb.mass = 1;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_isStuck) return;
        _isStuck = true;
        _rb.isKinematic = true;
        _rb.mass = 0;
        transform.SetParent(collision.transform);
        _boxCollider.enabled = false;
    }
}
