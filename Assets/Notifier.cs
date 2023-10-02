using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Notifier : MonoBehaviour
{
    [SerializeField]
    TMP_Text _text;
    [SerializeField]
    CanvasGroup _group;

    public void Notify(string text, float time)
    {
        _text.text = text;
        _group.alpha = 1;
        StartCoroutine(HideNotify(time));
    }
    IEnumerator HideNotify(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        _group.alpha = 0;

    }
}
