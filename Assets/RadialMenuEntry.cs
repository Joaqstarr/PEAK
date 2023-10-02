using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class RadialMenuEntry : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI Label;
    RadialMenu _menu;

    public ItemEquip _item;
    RectTransform _size;
    [SerializeField]
    Image _icon;
    private void Start()
    {
        _size = GetComponent<RectTransform>();
        _menu = GetComponent<RectTransform>().parent.GetComponent<RadialMenu>();
    }
    public void SetLabel(string labelText)
    {
        Label.text = labelText;
    }
    public void SetItem(ItemEquip item)
    {
        _item = item;
    }
    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _menu.SwitchNewItem(_item);
        transform.DOScale(1.1f, 0.02f).SetEase(Ease.OutElastic);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _size.DOScale(new Vector3(1, 1, 1), 0.02f).SetEase(Ease.OutBounce);

    }
    private void OnEnable()
    {
        _size.localScale = new Vector3(1, 1, 1);
    }
}
