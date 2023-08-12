using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BossTrigger : MonoBehaviour
{
    public UnityEvent _startBoss;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartTheFight());
    }
    IEnumerator StartTheFight()
    {
        yield return new WaitForSeconds(0.3f);
        _startBoss.Invoke();

    }
}
