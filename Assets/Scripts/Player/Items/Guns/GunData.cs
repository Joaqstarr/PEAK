using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GunData")]
public class GunData : ScriptableObject
{
    public float damage = 20;
    public float fireRate = 1;
    public int capacity = 10;
    public float reloadTime = 4;
    public float aimInTime = 1;
    public float recoil = 3;
    public float range = 1000f;
}
