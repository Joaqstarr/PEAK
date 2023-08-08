using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerHealth : MonoBehaviour
{
    public static int _health;
    float _iFrames = 0;
    private PlayerData _data;
    [SerializeField] CinemachineImpulseSource[] _impulseAmount;
    public bool _pistol = true;
    public bool _grapple = false;
    public bool _c4 = false;
    public bool _scuba = false;
    // Start is called before the first frame update
    void Awake()
    {
        _data = GetComponent<PlayerControls>()._data;
        _health = _data.maxHealth;
        LoadPlayer();

    }
    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadData();
        if(data == null)
        {
            SaveSystem.SavePlayer(this);
        }
        _health = data._health;
        OutdootEffects._outdoors = data._outdoors;

        _pistol = data._pistol;
        _grapple = data._grapple;
        _c4 = data._c4;
        _scuba = data._scuba;
        transform.position = new Vector3(data._position[0], data._position[1], data._position[2]);

    }

    private void Update()
    {
        _iFrames -= Time.deltaTime;
    }
    public void Damage(int damage, Vector3 _damageFrom, bool isTick, int impulseSize = 0)
    {
        if (impulseSize >= _impulseAmount.Length) impulseSize = 0;
        if(_iFrames < 0 && !isTick)
        {
            _health -= damage;
            _iFrames = _data.iFrameTime;
            Debug.Log(_health);
            _impulseAmount[impulseSize].GenerateImpulseWithForce(1);
        }
        if (isTick)
        {
            _health -= damage;
            Debug.Log(_health);
            _impulseAmount[impulseSize].GenerateImpulseWithForce(1);
        }
    }
}
