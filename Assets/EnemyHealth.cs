using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    EnemyData _data;
    public float _health;
    public UnityEvent OnDeath;
    // Start is called before the first frame update
    void Start()
    {
        _health = _data.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage)
    {
        _health -= damage;

        GetComponentInChildren<Animator>().SetTrigger("hit");
        //Debug.Log(gameObject.name + ", " + _health);
        if(_health <= 0)
        {
            //KILLL
            OnDeath.Invoke();
           // Destroy(gameObject);


        }

    }
}