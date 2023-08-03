using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterEffects : MonoBehaviour
{
    public static bool _underwater = false;
    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
        _underwater = true;
    }
    private void OnTriggerStay(Collider other)
    {
        RenderSettings.fog = true;
        _underwater = true;

    }
    private void OnTriggerExit(Collider other)
    {
        RenderSettings.fog = false;
        _underwater = false;

    }
}
