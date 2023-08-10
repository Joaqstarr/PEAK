using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player").GetComponent<PlayerHealth>()._grapple == true)
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth _player = other.gameObject.GetComponent<PlayerHealth>();


        if (_player._scuba == true) return;
        _player._scuba = true;
       


        SaveSystem.SavePlayer(_player);
        Destroy(gameObject);
    }
}
