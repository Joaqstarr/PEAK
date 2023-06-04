using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoldierData")]
public class SoldierData : EnemyData
{
    public LayerMask shootLOSMask;
    public int minBurst;
    public int maxBurst;
    public Vector2 aimSpeed = new Vector2(3.7f, 6);

    [Header("Strafe")]
    public Vector2 strafeSpeed;
    public Vector2 randomTime = new Vector2(2, 5);

    [Header("Cover")]
    public float coverChance = 30;
    public float coverRange = 15;
    public LayerMask coverNodeLayer;
    public int maxNodes;
    public LayerMask coverLineOfSightCheckLayer;
    public float seekCoverSpeed = 4;
    public int burstAmount = 5;
    public float exitCoverChance = 30;

    [Header("Accuracy Settings")]
    public int initialMisses;

}
