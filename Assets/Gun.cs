using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    PlayerControls _input;
    PlayerData _data;
    public GunData _gunData;
    public bool _reloading;
    float _shootTimer;
    public int _mag;

    [SerializeField]
    ParticleSystem _fireParticle;
    [SerializeField]
    AudioSource _fireAudio;

    public LayerMask _hittable;
    [SerializeField]
    Animator _anim;
    Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _input = GameObject.Find("Player").GetComponent<PlayerControls>();
        _data = _input._data;

        _cam = Camera.main;
        _mag = _gunData.capacity;
    }

    // Update is called once per frame
    void Update()
    {
        _shootTimer -= Time.deltaTime;
        Vector3 playerVelocity = _input.GetComponent<Rigidbody>().velocity;
        playerVelocity.y = 0;
        _anim.SetFloat("Speed", playerVelocity.magnitude);

        if (_input._fireHeld && _shootTimer <= 0 && _mag > 0 && !_reloading)
        {
            Shoot();
        }
        if (_input._reloadHeld && _shootTimer <= 0 && !_reloading)
        {
            Reload();
        }
    }

    void Shoot()
    {

        if (_mag <= 0)
        {
            return;
        }
        _mag -= 1;
        _shootTimer = _gunData.fireRate;

        RaycastHit hit;

        if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _gunData.range, _hittable))
        {
           // Debug.Log("gun hit original: "+ hit.transform.gameObject.name);
            EnemyHealth _hitAvatar = hit.transform.root.GetComponent<EnemyHealth>();
            if(_hitAvatar != null)
            {
                _hitAvatar.Hit(_gunData.damage);

            }
        }



        //ART
        _fireParticle.Play();
        _fireAudio.Play();
        _anim.SetTrigger("Fire");

    }
    private void Reload()
    {
        _reloading = true;
        _anim.SetTrigger("Reload");

    }
    public void FinishReload()
    {
        _reloading = false;
        _mag = _gunData.capacity;
    }
}
