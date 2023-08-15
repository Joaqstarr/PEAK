using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertPosition : MonoBehaviour
{
    [SerializeField]
    Vector3 _setPos;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").transform.position = _setPos;
    }

}
