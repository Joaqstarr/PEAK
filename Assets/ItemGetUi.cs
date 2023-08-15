using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemGetUi : MonoBehaviour
{
    CanvasGroup _group;
    [SerializeField]
    TMP_Text _title;
    [SerializeField]
    TMP_Text _description;
    [SerializeField]
    Image _icon;
    // Start is called before the first frame update
    void Start()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void NewItemNotify(ItemEquip item,  string desc)
    {
        _title.text = "Received " + item.gameObject.name;
        _description.text = desc;
        _icon.sprite = item._icon;
        _group.alpha = 1;
        _group.interactable = true;
        _group.blocksRaycasts = true;
        Cursor.lockState = CursorLockMode.Confined;
        FadeToBlack._fading = true;
        Time.timeScale = 0;
    }
    public void ExitMenu()
    {
        _group.alpha = 0;
        _group.interactable = false;
        _group.blocksRaycasts = false;
        Cursor.lockState = CursorLockMode.Locked;
        FadeToBlack._fading = false;
        Time.timeScale = 1;
    }
}
