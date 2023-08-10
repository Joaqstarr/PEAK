using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossBoulder : MonoBehaviour
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(StartFall());
    }
    IEnumerator StartFall()
    {
        yield return new WaitForSeconds(Random.Range(0f, 7f));
        _rb.isKinematic = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
