using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SpiderData")]
public class SpiderData : ScriptableObject
{
    public int _hitsToKill = 3;
    public Vector2 _attackTimer = new Vector2(3, 8);
    public Vector2 _slamDistribution = new Vector2(20, 20);
    public Vector2 _slamAmount = new Vector2(15, 25);
    public float _slamHeight = -1.7f;
    public Vector2 _boulderX = new Vector2(-7.305802f, 48.51712f);
    public Vector2 _boulderZ = new Vector2(-31.8919f, 11.88195f);
    public float _boulderSpeed = 100;

}
