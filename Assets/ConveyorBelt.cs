using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject);
        Rigidbody rb = collision.rigidbody;
        if (rb)
        {
            rb.AddForce(_direction * Time.deltaTime, ForceMode.VelocityChange);

        }
    }
}
