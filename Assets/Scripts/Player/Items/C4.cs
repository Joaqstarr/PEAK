using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    public delegate void Detonate();
    public static event Detonate _explodeC4;

    public delegate void PlaceC4();
    public static event PlaceC4 _placeC4;
    private bool _readyToThrow = true;
    [SerializeField]
    GameObject _c4Projectile;
    [SerializeField]
    C4Data _data;

    PlayerControls _input;
    float _shootTimer = 0;
    float _detonateTimer = 0;

    ObjectPooler _c4ObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        _input = GameObject.Find("Player").GetComponent<PlayerControls>();
        _c4ObjectPool = GameObject.Find("C4ObjectPooler").GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        _shootTimer -= Time.deltaTime;
        _detonateTimer -= Time.deltaTime;


        if (_input._fireHeld && _shootTimer <= 0)
        {
            Throw();
        }
        if (_input._altFireHeld && _detonateTimer <= 0)
        {
            DetonateActivate();
        }
    }

    private void OnEnable()
    {
        _explodeC4 += OnDetonate;
    }
    private void OnDisable()
    {
        _explodeC4 -= OnDetonate;

    }
    private void OnDetonate()
    {

    }
    private void Throw()
    {
        _shootTimer = _data.reloadTime;




        GameObject projectile = _c4ObjectPool.GetPooledObject();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = Camera.main.transform.rotation;
        projectile.SetActive(true);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectile.transform.SetParent(null);

        Vector3 addedForce = Camera.main.transform.forward * _data.forwardForce + transform.up * _data.upwardForce;
        projectileRb.AddForce(addedForce, ForceMode.Impulse);

        _placeC4();
    }
    private void DetonateActivate()
    {
        _detonateTimer = 2f;
        _explodeC4();
    }
}
