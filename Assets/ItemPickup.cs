using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    RadialMenu _radialmenu;
    [SerializeField]
    ItemEquip _item;
    // Start is called before the first frame update
    void Start()
    {
        _radialmenu = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();
        if (_item.gameObject.name == "PhysicsGun")
        {
            if( GameObject.Find("Player").GetComponent<PlayerHealth>()._grapple == true)
            {
                _radialmenu.AddEntry(_item.gameObject.name, _item);
                Debug.Log("loaded");
                Destroy(gameObject);

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_item.gameObject.name == "PhysicsGun")
            if (other.gameObject.GetComponent<PlayerHealth>()._grapple == true) return;
        _radialmenu.AddEntry(_item.gameObject.name, _item);
        PlayerHealth _player = other.gameObject.GetComponent<PlayerHealth>();

        if (_item.gameObject.name == "PhysicsGun")
        {
            _player._grapple = true;

        }
        SaveSystem.SavePlayer(_player);
        Destroy(gameObject);
    }
}
