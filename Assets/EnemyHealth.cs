using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    EnemyData _data;
    public float _health;
    public UnityEvent OnDeath;
    // Start is called before the first frame update
    void Awake()
    {
        transform.parent = null;
        _health = _data.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage, bool ragdoll = false)
    {
        if (_health <= 0) return;

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
    public void ShrinkToDestroy()
    {
        transform.DOScale(new Vector3(0.01f,0.01f, 0.01f), 10f).SetEase(Ease.InOutBack);
        Destroy(gameObject, 7f);

    }

}
