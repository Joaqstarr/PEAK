using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("General Settings")]
    public float health = 1;

    [Header("Movement")]
    public float speed = 3.5f;
    [Header("Sight")]
    public float sightRange = 10f;

    [Header("Attack Settings")]
    public int damage = 1;
    public float attackSpeed = 1;
    public float range = 2;
}
