using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    WalkingEnemyData _data;
    // Start is called before the first frame update
    void Start()
    {
        _data = transform.root.GetComponent<AIStateManager>()._data;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(_data.damage, transform.root.position, false, 0);
        }
    }
}
