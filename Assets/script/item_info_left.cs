using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_info_left : MonoBehaviour
{
    public GameObject linked_slot;
    public string type;

    public GameObject[] skill_inven_left = new GameObject[5];
    public GameObject[] item_inven_left = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void erase_slot()
    {
        linked_slot.GetComponent<inven_slot_left>().item = null;
        
    }


    public void equip_item()
    {
        if (type == "left")
        {
            
        }else if(type == "right")
        {
            if(linked_slot.GetComponent<inven_slot>().item.item_type == "skill")
            {
                for(int i = 0; i<skill_inven_left.Length; i++)
                {
                    if (skill_inven_left[i].GetComponent<inven_slot_left>().item == linked_slot.GetComponent<inven_slot>().item)
                    {
                        return;
                    }
                }
                for(int i = 0; i<skill_inven_left.Length; i++)
                {
                    if (skill_inven_left[i].GetComponent<inven_slot_left>().item == null)
                    {
                        skill_inven_left[i].GetComponent<inven_slot_left>().item = linked_slot.GetComponent<inven_slot>().item;
                        break;
                    }
                }
            }else if(linked_slot.GetComponent<inven_slot>().item.item_type == "item")
            {
                for(int i =0; i<item_inven_left.Length; i++)
                {
                    if (item_inven_left[i].name == linked_slot.GetComponent<inven_slot>().item.parts)
                    {
                        item_inven_left[i].GetComponent<inven_slot_left>().item = linked_slot.GetComponent<inven_slot>().item;
                        break;
                    }
                }
            }
        }
    }
}
