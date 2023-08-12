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
        _rb = GetComponent<Rigidbody>();

    }
    
    private void OnEnable()
    {
        _isStuck = false;

        _boxCollider.enabled = true;
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
