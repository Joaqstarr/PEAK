using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BossTrigger : MonoBehaviour
{
    bool _started = false;
    public UnityEvent _startBoss;
    private void OnTriggerEnter(Collider other)
    {
        if (_started) return;
        _started = true;
        StartCoroutine(StartTheFight());
    }
    IEnumerator StartTheFight()
    {
        yield return new WaitForSeconds(0.3f);
        _startBoss.Invoke();

    }
}
