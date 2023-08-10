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
    [SerializeField]
    Animator _anim;
    PlayerControls _input;
    float _shootTimer = 0;
    float _detonateTimer = 0;
    int _c4Out = 0;
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

        Vector3 playerVelocity = _input.GetComponent<Rigidbody>().velocity;
        playerVelocity.y = 0;
        _anim.SetFloat("Speed", playerVelocity.magnitude);
        _anim.SetInteger("C4Out", _c4Out);
        if (_input._fireHeld && _shootTimer <= 0)
        {
            Throw();
        }
        if (_input._altFireHeld && _detonateTimer <= 0 && _c4Out >0)
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
        _c4Out = 0;
    }
    private void Throw()
    {
        _shootTimer = _data.reloadTime;
        _anim.SetTrigger("Fire");


        StartCoroutine(ThrowWait());

    }
    IEnumerator ThrowWait()
    {
        yield return new WaitForSeconds(0.4f);
        GameObject projectile = _c4ObjectPool.GetPooledObject();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = Camera.main.transform.rotation;
        projectile.SetActive(true);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectile.transform.SetParent(null);

        Vector3 addedForce = Camera.main.transform.forward * _data.forwardForce + transform.up * _data.upwardForce;
        projectileRb.AddForce(addedForce, ForceMode.Impulse);
        _c4Out++;
        _placeC4();
    }
    private void DetonateActivate()
    {
        _detonateTimer = 2f;

        _anim.SetTrigger("C4Detonate");
        StartCoroutine(DetonateWait());
    }
    IEnumerator DetonateWait()
    {
        yield return new WaitForSeconds(0.3f);
        _explodeC4();
    }
}
