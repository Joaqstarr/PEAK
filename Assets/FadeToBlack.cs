using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeToBlack : MonoBehaviour
{
    CanvasGroup _group;
    static public bool _fading = false;
    [SerializeField]
    float _fadeTime = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        

    }
    private void OnDisable()
    {
        
    }
    public void Fade(float waitAmount)
    {
        _fading = true;
        DOVirtual.Float(0, 1, _fadeTime, x => _group.alpha = x);
        StartCoroutine(Wait(waitAmount + 0.5f));
    }

    IEnumerator Wait(float waitAmount)
    {
        yield return new WaitForSecondsRealtime(waitAmount);
        FinishFade();
        
    }
    private void FinishFade()
    {
        DOVirtual.Float(1, 0, _fadeTime, x => _group.alpha = x).onComplete = OnCompletelyFinish;

    }
    private void OnCompletelyFinish()
    {
        _fading = false;
    }
}
