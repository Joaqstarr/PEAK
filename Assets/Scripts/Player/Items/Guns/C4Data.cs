using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "C4Data")]

public class C4Data : ScriptableObject
{
    public float damage = 20;
    public float fireRate = 1;
    public int capacity = 3;
    public float reloadTime = 4;
    public float forwardForce = 3;
    public float upwardForce = 2;
    public float explodeRadius = 1.43f;
    public float explodeForce = 10f;

}
