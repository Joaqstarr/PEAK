using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdootEffects : MonoBehaviour
{
    public static bool _outdoors = true;
    GameObject _holder;
    GameObject _indoorHolder;

    // Start is called before the first frame update
    void Start()
    {
        _holder = transform.GetChild(0).gameObject;
        if(transform.childCount > 1)
        _indoorHolder = transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (_indoorHolder != null)
            _holder.SetActive(_outdoors);
        if(_indoorHolder != null)
        _indoorHolder.SetActive(!_outdoors);

    }
}
