using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField]
    float _damage = 0.5f;
    Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("ball hit");

        EnemyHealth enemy = collision.transform.root.GetComponent<EnemyHealth>();
        if (enemy == null) return;

        Debug.Log(_damage * _rb.velocity.magnitude);
        enemy.Hit(_damage * _rb.velocity.magnitude, true);
    }
}
