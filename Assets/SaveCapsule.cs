using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCapsule : MonoBehaviour
{
    private float _timer = 0;
    AudioSource _audio;
    Notifier _notif;

    // Start is called before the first frame update
    void Start()
    {
        _notif = GameObject.Find("Notifier").GetComponent<Notifier>();
        _timer = 3f;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_timer > 0) return;
        if (!other.gameObject.CompareTag("Player")) return;
        other.transform.position = transform.position;
        PlayerHealth._health = other.GetComponent<PlayerControls>()._data.maxHealth;
        SaveSystem.SavePlayer(other.GetComponent<PlayerHealth>());
        _timer = 3f;
        _audio.Play();
        _notif.Notify("Game Saved", 2f);
        FadeToBlack._fading = true;
        Time.timeScale = 0;
        StartCoroutine(EndSave());
    }
    IEnumerator EndSave()
    {
        yield return new WaitForSecondsRealtime(1.3f);
        Time.timeScale = 1;
        FadeToBlack._fading = false;

    }
    private void OnTriggerExit(Collider other)
    {
        if (_timer < 1) return;
        if (!other.gameObject.CompareTag("Player")) return;
        _timer = 1;
    }
}
