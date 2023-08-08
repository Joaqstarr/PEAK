using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    FadeToBlack _fade;
    [SerializeField]
    bool _leadsIndoors = true;
    private void Start()
    {
        _fade = GameObject.Find("Fadetoblack").GetComponent<FadeToBlack>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.VelocityChange);
            _fade.Fade(2f);
            StartCoroutine(Teleport(other));
        }
    }


    IEnumerator Teleport(Collision other)
    {
        yield return new WaitForSeconds(0.5f);
        OutdootEffects._outdoors = !_leadsIndoors;
        other.transform.position = transform.GetChild(0).transform.position;

    }
}
