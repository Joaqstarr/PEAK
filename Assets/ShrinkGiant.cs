using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShrinkGiant : MonoBehaviour
{
    [SerializeField]
    float _duration  = 500f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), _duration).SetEase(Ease.Linear);
    }

}
