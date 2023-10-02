using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class ElevatorActivator : MonoBehaviour
{
    [SerializeField]
    ElevatorScript _elevator;
    bool _activated = false;
    [SerializeField]
    float _elevatorTarget = 10.1f;
    public UnityEvent NextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (_activated) return;
        if (!other.gameObject.CompareTag("Player")) return;
        _activated = true;

        other.transform.parent = transform.root;
        _elevator._targetY = _elevatorTarget;

        _elevator.StartElevator();

        other.transform.position = transform.position;

        NextLevel.Invoke();

    }
    public void NextScene()
    {
        StartCoroutine(EnterDesert());
    }
    IEnumerator EnterDesert()
    {
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene(2);
    }
}
