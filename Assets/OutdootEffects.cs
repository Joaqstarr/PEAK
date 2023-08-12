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
        _indoorHolder = transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        _holder.SetActive(_outdoors);
        _indoorHolder.SetActive(!_outdoors);

    }
}
