using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BossTrigger : MonoBehaviour
{
    public UnityEvent _startBoss;
    private void OnTriggerEnter(Collider other)
    {
        _startBoss.Invoke();
    }
}
