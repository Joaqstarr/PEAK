using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossBoulder : MonoBehaviour
{
    Rigidbody _rb;
    public int _damage = 50;
    public bool _damaging = true;
    public bool _throwing = false;

    ParticleSystem _system;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _system = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(StartFall());
    }
    IEnumerator StartFall()
    {
        yield return new WaitForSeconds(Random.Range(0f, 7f));
        _rb.isKinematic = false;
        _damaging = true;
        _rb.AddTorque(new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), Random.Range(-300, 300)),ForceMode.Impulse);
        GetComponent<AudioSource>().Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!_damaging) return;
        _damaging = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(_damage, transform.position, false, 1);
            Explode();
        }
        else
        {
            if (_throwing) Explode();
        }


        

    }
    public void Explode()
    {
        GameObject.Find("Boss").GetComponent<SpiderStateManager>()._boulders.Remove(this);
        _damaging = false;
        _system.Play();
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 3f);
    }

}
