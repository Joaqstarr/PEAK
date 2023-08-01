using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public Vector3 _direction;
    public float _speed;
    public int _damage;
    Rigidbody _rb;
    private void Awake()
    {
        
        StopAllCoroutines();

        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deactivateObj());
        _rb.velocity = Vector3.zero;

    }
    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;

    }
    // Update is called once per frame
    void Update()
    {
        _rb.velocity =  _direction * _speed;
        Debug.Log(_rb.velocity.magnitude);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Damage(_damage, transform.position, false, 1);
        }
        gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        _rb.velocity = Vector3.zero;

        StopAllCoroutines();
    }
    IEnumerator deactivateObj()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);

    }
}
