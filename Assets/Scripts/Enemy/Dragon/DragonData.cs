using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DragonData")]
public class DragonData : ScriptableObject
{
    public float _radius = 10f;
    public LayerMask _playerLayer;
    public float _attackTimer = 3f;
    public float _moveHeadDownTime = 2.5f;
    public float _moveHeadAcrossTime = 7f;
}
