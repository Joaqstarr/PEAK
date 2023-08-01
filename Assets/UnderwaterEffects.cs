using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterEffects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
    }
    private void OnTriggerStay(Collider other)
    {
        RenderSettings.fog = true;

    }
    private void OnTriggerExit(Collider other)
    {
        RenderSettings.fog = false;

    }
}
