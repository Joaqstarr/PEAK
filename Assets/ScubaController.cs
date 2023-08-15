using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaController : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
            _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("Underwater", UnderwaterEffects._underwater);
        PlayerHealth _health = transform.root.GetComponent<PlayerHealth>();
        if (_health == null)
            _health = transform.root.GetComponentInChildren<PlayerHealth>();
        _anim.SetBool("HasScuba", _health._scuba);

    }


}
