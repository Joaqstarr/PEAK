using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaPickup : MonoBehaviour
{
    [SerializeField]
    ItemEquip _item;
    [SerializeField]
    string _description;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player").GetComponent<PlayerHealth>()._scuba == true)
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

        GameObject.Find("ItemGet").GetComponent<ItemGetUi>().NewItemNotify(_item, _description);


        //SaveSystem.SavePlayer(_player);
        Destroy(gameObject);
    }
}
