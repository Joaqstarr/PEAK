using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DragonData")]
public class DragonData : EnemyData
{
    public float _radius = 10f;
    public float _leaveDetectionRadius = 90f;
    public LayerMask _playerLayer;
    public float _attackTimer = 3f;
    public float _moveHeadDownTime = 2.5f;
    public float _moveHeadAcrossTime = 7f;
    public float _rotSpeed = 30f;
    public float _fireSpewChance = 30;
    public float _shootAgainChance = 50;
    public int _flameSpewDamage = 0;
    [Header("Fireball Settings")]
    public float fireballSpeed = 10;
    public int fireballDamage = 50;
    


}
