using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{
    [SerializeField]
    ElevatorScript _elevator;
    bool _activated = false;
    [SerializeField]
    float _elevatorTarget = 10.1f;
    private void OnTriggerEnter(Collider other)
    {
        if (_activated) return;
        if (!other.gameObject.CompareTag("Player")) return;
        _activated = true;
        other.transform.position = transform.position;
        other.transform.parent = transform.root;

        _elevator._targetY = _elevatorTarget;
        _elevator.StartElevator();

    }
}
