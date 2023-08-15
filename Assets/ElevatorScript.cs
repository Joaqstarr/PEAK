using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ElevatorScript : MonoBehaviour
{
    [SerializeField]
    public float _targetY = 10.1f;
    [SerializeField]
    float _speed = 30.1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartElevator()
    {
        FadeToBlack._fading = true;
        transform.DOLocalMoveY(_targetY, _speed).SetEase(Ease.Linear).onComplete = EndElevator;
    }
    private void EndElevator()
    {
        FadeToBlack._fading = false;
        GameObject.Find("Player").transform.parent = null;

    }
}
