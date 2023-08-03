using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    ParticleSystem _system;
    // Start is called before the first frame update
    void Start()
    {
        _system = GetComponentInChildren<ParticleSystem>();
    }



    public void Explode()
    {
        _system.Play();
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 3f);
    }
}
