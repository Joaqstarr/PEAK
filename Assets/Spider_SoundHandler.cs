using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_SoundHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource _slam;
    [SerializeField]
    AudioSource _hit;
    [SerializeField]
    AudioSource _stomp;
    [SerializeField]
    AudioSource _distantExplosion;
    [SerializeField]
    AudioSource _treeCreak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slam()
    {
        _slam.Play();
    }
    public void Hit()
    {
        _hit.Play();
    }
    public void Stomp()
    {
        _stomp.Play();
    }
    public void DistantExplosion()
    {
        _distantExplosion.Play();
    }
    public void Creak()
    {
        _treeCreak.Play();
    }
}
