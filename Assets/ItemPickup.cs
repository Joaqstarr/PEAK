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
        if (_item.gameObject.name == "Spider Remains")
        {
            if( GameObject.Find("Player").GetComponent<PlayerHealth>()._grapple == true)
            {
                _radialmenu.AddEntry(_item.gameObject.name, _item);
                Debug.Log("loaded");
                Destroy(gameObject);

            }
            

        }
        if (_item.gameObject.name == "Remote Bomb")
        {
            if (GameObject.Find("Player").GetComponent<PlayerHealth>()._c4 == true)
            {
                _radialmenu.AddEntry(_item.gameObject.name, _item);
                Debug.Log("loaded");
                Destroy(gameObject);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_item.gameObject.name == "Spider Remains")
            if (other.gameObject.GetComponent<PlayerHealth>()._grapple == true) return;

        if (_item.gameObject.name == "Remote Bomb")
            if (other.gameObject.GetComponent<PlayerHealth>()._c4 == true) return;



        _radialmenu.AddEntry(_item.gameObject.name, _item);
        PlayerHealth _player = other.gameObject.GetComponent<PlayerHealth>();

        if (_item.gameObject.name == "Spider Remains")
        {
            _player._grapple = true;

        }

        if (_item.gameObject.name == "Remote Bomb")
        {
            _player._c4 = true;

        }
        Destroy(gameObject);
    }
}
