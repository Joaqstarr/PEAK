using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class RadialMenuEntry : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI Label;
    RadialMenu _menu;

    public ItemEquip _item;

    private void Start()
    {
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("poop");
        _menu.SwitchNewItem(_item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }
}
