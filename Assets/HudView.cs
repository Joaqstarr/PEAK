using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudView : MonoBehaviour
{
    CanvasGroup _group;

    // Start is called before the first frame update
    void Start()
    {
        _group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeToBlack._fading == true)
        {

            _group.alpha = 0;
        }
        else
        {
            _group.alpha = 1;
        }
    }
}
