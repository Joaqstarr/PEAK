using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class C4Projectile : MonoBehaviour
{
    int c4Amt = 0;
    [SerializeField]
    C4Data _data;
    Rigidbody _rb;
    [SerializeField]
    GameObject _art;
    CinemachineImpulseSource _shake;
    AudioSource _audio;
    [SerializeField]
    LayerMask _c4hittable;

    private void OnEnable()
    {
        c4Amt = 0;
        C4._placeC4 += OnPlaceC4;
        C4._explodeC4 += Explode;
        _rb = GetComponent<Rigidbody>();
        _art.SetActive(true);
        _shake = GetComponent<CinemachineImpulseSource>();
        _audio = GetComponent<AudioSource>();

        _rb.isKinematic = false;


    }
    private void OnDisable()
    {
        
        C4._placeC4 -= OnPlaceC4;
        C4._explodeC4 -= Explode;
    }
    IEnumerator DisableObj()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
    private void Explode()
    {
        transform.SetParent(null);
        _shake.GenerateImpulseWithForce(0.1f);
        _art.SetActive(false);
        _audio.Play();
        _rb.isKinematic = true;
        StartCoroutine(DisableObj());
        GetComponentInChildren<ParticleSystem>().Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _data.explodeRadius, _c4hittable);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_data.explodeForce, transform.position, _data.explodeRadius);
                
            }
            EnemyHealth enemyHealth = nearbyObject.transform.root.GetComponent<EnemyHealth>();
            if (enemyHealth)
            {
                enemyHealth.Hit(_data.damage);
            }
            PlayerHealth playerHealth = nearbyObject.transform.root.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.Damage(Mathf.RoundToInt(_data.damage), transform.position, false);
            }
            Boulder _boulder = nearbyObject.transform.GetComponent<Boulder>();
            if (_boulder)
            {
                _boulder.Explode();
            }
            BossHitbox _boss = nearbyObject.transform.GetComponent<BossHitbox>();
            if (_boss)
            {
                _boss.DamageTaken();
            }
            BossBoulder bossboulder = nearbyObject.transform.GetComponent<BossBoulder>();
            if (bossboulder)
            {
                bossboulder.Explode();
            }
        }
    }
    private void OnPlaceC4()
    {
        c4Amt++;
        if (c4Amt > _data.capacity) gameObject.SetActive(false);
    }
}
