using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevator : MonoBehaviour
{
    Notifier _notif;

    bool _activated = false;
    [SerializeField]
    ElevatorScript _elevator;
    // Start is called before the first frame update
    void Start()
    {
        _notif = GameObject.Find("Notifier").GetComponent<Notifier>();
        _activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (other.gameObject.GetComponent<PlayerHealth>()._elevatorCalled) return;
        other.transform.position = transform.position;
        other.gameObject.GetComponent<PlayerHealth>()._elevatorCalled = true;
        _elevator.StartElevator();
        _notif.Notify("Called Elevator", 3f);

        FadeToBlack._fading = true;
        Time.timeScale = 0;
        StartCoroutine(EndSave());
    }
    IEnumerator EndSave()
    {
        yield return new WaitForSecondsRealtime(1.4f);
        Time.timeScale = 1;
        FadeToBlack._fading = false;
    }
}
