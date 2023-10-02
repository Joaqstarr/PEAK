using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupArt : MonoBehaviour
{
    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player);
    }
}
