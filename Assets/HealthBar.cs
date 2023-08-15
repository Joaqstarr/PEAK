using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    TMP_Text _healthText;
    Image _bar;
    // Start is called before the first frame update
    void Start()
    {
        _bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _bar.fillAmount = PlayerHealth._health / 1000f;
        int healthInt = (PlayerHealth._health / 10);
        _healthText.text = healthInt.ToString("000");

    }
}
