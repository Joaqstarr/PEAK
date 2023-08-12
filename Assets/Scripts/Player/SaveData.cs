using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public float[] _position;
    public int _health;
    public bool _pistol;
    public bool _grapple;
    public bool _c4;
    public bool _scuba;
    public bool _outdoors;
    public bool _spiderKilled;


    public SaveData(PlayerHealth player)
    {
        _health = PlayerHealth._health;
        _outdoors = OutdootEffects._outdoors;

        _position = new float[3];
        _position[0] = player.transform.position.x;
        _position[1] = player.transform.position.y;
        _position[2] = player.transform.position.z;

        _pistol = player._pistol;
        _grapple = player._grapple;
        _c4 = player._c4;
        _scuba = player._scuba;
        _spiderKilled = player._spiderDead;

    }
}
