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
        _anim.SetBool("HasScuba", transform.root.GetComponent<PlayerHealth>()._scuba);

    }


}
