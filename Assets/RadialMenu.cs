using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RadialMenu : MonoBehaviour
{
    [SerializeField]
    TMP_Text _text;
    [SerializeField]
    Image _image;
    private CanvasGroup _radialGroup;
    [SerializeField]
    private RadialMenuEntry _entryPrefab;
    List<RadialMenuEntry> Entries;
    [SerializeField]
    private float _radius = 300f;

    // Start is called before the first frame update
    ItemEquip _newItem;
    AudioSource _source;
    void Awake()
    {
        _source = GetComponent<AudioSource>();
        _radialGroup = GetComponent<CanvasGroup>();
        Entries = new List<RadialMenuEntry>();
    }

    private void Start()
    {

        _newItem = null;
    }

    public void AddEntry(string label, ItemEquip item)
    {
        RadialMenuEntry entry = Instantiate(_entryPrefab);
        entry.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
        entry.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        entry.SetItem(item);
        Entries.Add(entry);
        entry.SetLabel(label);
        entry.SetIcon(item._icon);
    }

    public void Open()
    {
        _text.text = "";

        _radialGroup.alpha = 1;
        _radialGroup.interactable = true;
        _radialGroup.blocksRaycasts = true;
        Rearrange();
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = 0.001f;
    }
    public void Close()
    {
        if(_newItem != null)
        {
            //switch item
            FindAnyObjectByType<EquipManager>().SwitchWeapon(_newItem);
        }
        _radialGroup.alpha = 0;
        _radialGroup.interactable = false;
        _radialGroup.blocksRaycasts = false;
        Rearrange();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        _newItem = null;

    }
    private void Rearrange()
    {
        float radiansOfSeperation = (Mathf.PI * 2) / Entries.Count;
        for (int i = 0; i < Entries.Count; i++)
        {
            float x = Mathf.Sin(radiansOfSeperation * i) * _radius;
            float y = Mathf.Cos(radiansOfSeperation * i) * _radius;

            Entries[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0);
        }
    }
    public void SwitchNewItem(ItemEquip item)
    {
        _newItem = item;
        //play sound;
        _source.Play();
        _text.text = item.gameObject.name;

    }

}
