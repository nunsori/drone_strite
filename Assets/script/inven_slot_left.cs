using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inven_slot_left : MonoBehaviour
{
    public Image slot_img;
    //public GameObject slot_item_obj;
    public item_data item;

    // Start is called before the first frame update
    void Start()
    {
        slot_img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {
            //Debug.Log("on_item");
            slot_img.sprite = item.item_image;
            //slot_img.color = new Color(0, 0, 0);
        }
        else
        {
            slot_img.sprite = null;
            //slot_img.color = new Color(slot_img.color.r, slot_img.color.g, slot_img.color.b, 0);
        }
    }

    public void out_btn()
    {

    }
}
