using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WalkingEnemyData")]
public class WalkingEnemyData : EnemyData
{
    [Header("Patrol Settings")]
    public float patrolRange = 5;
    public float patrolSpeed = 0.8f;
}
