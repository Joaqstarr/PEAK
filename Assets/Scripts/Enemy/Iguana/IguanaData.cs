using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IguanaData")]
public class IguanaData : EnemyData
{
    public float treeHeight = 10f;
    public float treeDistance = 1f;
    public float treeClingDistance = 1f;

    public float _climbSpeed = 10f;

    public LayerMask _playerLayer;
    public LayerMask _groundLayer;

    public float _glideSpeed = 10;
    public float _groundedDist = 0.3f;

}
