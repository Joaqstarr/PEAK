using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileStick : MonoBehaviour
{
    private bool _isStuck = false;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _isStuck = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_isStuck) return;
        _isStuck = true;
        _rb.isKinematic = true;
        transform.SetParent(collision.transform);
    }
}
