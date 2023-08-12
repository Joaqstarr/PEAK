using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BossHitbox : MonoBehaviour
{
    public UnityEvent Damage;
    public void DamageTaken()
    {
        Damage.Invoke();
    }
}
