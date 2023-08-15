using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class OxygenMeter : MonoBehaviour
{
    [SerializeField]
    Image[] sprites;
    UnderwaterDamage _player;
    bool _lastFrameUnderwater = false;
    CanvasGroup _group;
    // Start is called before the first frame update
    void Start()
    {
        _group = GetComponent<CanvasGroup>();
        _player = GameObject.Find("Player").GetComponent<UnderwaterDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_lastFrameUnderwater != UnderwaterEffects._underwater)
        {
            if (UnderwaterEffects._underwater)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        if (_player._oxygen >= 4) return;

        if(_player._oxygen < 0)
        {
            for (int i = 0; i <= Mathf.FloorToInt(_player._oxygen); i++)
            {
                sprites[i].color = Color.clear;
            }
            return;

        }
        
        Color _fadeAmount = Color.white;
        _fadeAmount.a =  _player._oxygen - Mathf.FloorToInt(_player._oxygen);
        Debug.Log(Mathf.FloorToInt(_player._oxygen));
        if ( Mathf.FloorToInt(_player._oxygen) < sprites.Length)
            sprites[Mathf.FloorToInt(_player._oxygen)].color = _fadeAmount;
        for(int i = 0; i < Mathf.FloorToInt(_player._oxygen); i++)
        {
            sprites[i].color = Color.white;

        }
        _lastFrameUnderwater = UnderwaterEffects._underwater;
    }
    private void Show()
    {
        for (int i = 0; i <= Mathf.FloorToInt(_player._oxygen); i++)
        {
            sprites[i].color = Color.white;
        }
        DOVirtual.Float(0f, 1f, 0.5f, x => _group.alpha = x).SetEase(Ease.InBack);
    }
    private void Hide()
    {
        DOVirtual.Float(1f, 0f, 0.5f, x => _group.alpha = x).SetEase(Ease.InBack);

    }
}
