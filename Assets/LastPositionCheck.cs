using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LastPositionCheck : MonoBehaviour
{
    public Vector3 _savedLocation;
    PlayerMovement _groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        _groundCheck = GetComponent<PlayerMovement>();
        _savedLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_groundCheck._grounded) return;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(transform.position, out hit, 1, NavMesh.AllAreas))
        {
            _savedLocation = transform.position;
        }
    }
    public void ResetLocation()
    {
        transform.position = _savedLocation;
    }
}
