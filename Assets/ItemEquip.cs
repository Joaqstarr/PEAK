using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquip : MonoBehaviour
{
    RadialMenu _radialmenu;
    [SerializeField]
    bool firstEquipped = false;
    // Start is called before the first frame update
    void Start()
    {
      //  _radialmenu = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();
     //   _radialmenu.AddEntry(gameObject.name,this);

        if (firstEquipped)
        {
              _radialmenu = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();
               _radialmenu.AddEntry(gameObject.name,this);
        }
        //      gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
