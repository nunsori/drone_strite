using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inven_slot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler//, IDropHandler, IPointerEnterHandler
{
    public Image slot_img;
    //public GameObject slot_item_obj;
    public item_data item;


    public ScrollRect parentsr;

    public RectTransform slot_rect;

    public bool trans_cor_on = false;
    public bool have_item = false;
    public Vector3 slot_pos;
    //public Sprite item_sprite;
    private IEnumerator co_trnas_item;
    private bool cor_pointer_up = false;


    public GameObject item_drag;
    public GameObject m_cursor;

    // Start is called before the first frame update
    void Start()
    {
        slot_img = GetComponent<Image>();
        parentsr = transform.parent.parent.parent.parent.GetComponent<ScrollRect>();
        if(parentsr == null)
        {
            //parentsr = transform.parent.parent
        }
        slot_rect = GetComponent<RectTransform>();
        slot_pos = slot_rect.localPosition;
        item_drag = GameObject.Find("item_drag");
        m_cursor = GameObject.Find("mobile_cursor");
        //item_drag.SetActive(false);
        //co_trnas_item = trans_item();
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

    public item_data slot_info()
    {
        return item;
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (have_item == true)
        {
            //item_drag = GameObject.Find("item_drag");
            //gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
            item_drag.SetActive(true);
            m_cursor.SetActive(true);
            item_drag.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            m_cursor.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
            //Debug.Log(slot_pos);
        }
        else
        {
            
            parentsr.OnDrag(eventData);
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if(have_item == true)
        {
            //item_drag = GameObject.Find("item_drag");
            //gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
            item_drag.SetActive(true);
            m_cursor.SetActive(true);
            item_drag.GetComponent<drag_ui>().on_last_sb();
            item_drag.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            m_cursor.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            //Debug.Log(Input.mousePosition);
        }
        else
        {
            parentsr.OnBeginDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (have_item == true)
        {
            //item_drag = GameObject.Find("item_drag");
            //gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
            item_drag.SetActive(true);
            m_cursor.SetActive(true);
            item_drag.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            m_cursor.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            //Debug.Log(Input.mousePosition);
        }
        else
        {
            parentsr.OnEndDrag(eventData);
        }
    }



    public void OnPointerDown(PointerEventData e)
    {
        //item_drag = GameObject.Find("item_drag");
        Debug.Log("down");
        slot_pos = new Vector3(slot_rect.localPosition.x, slot_rect.localPosition.y, slot_rect.localPosition.z);
        if (trans_cor_on == false && item != null)
        {
            co_trnas_item = trans_item();
            //StartCoroutine(trans_item());
            StartCoroutine(co_trnas_item);
        }
    }

    public void OnPointerUp(PointerEventData e)
    {

        GameObject manager_all = GameObject.Find("game_manager_all");
        manager_all.GetComponent<game_manage>().graphic_ray_cast_ui();
        if(trans_cor_on == true)
        {
            StopCoroutine(co_trnas_item);
            trans_cor_on = false;
            Debug.Log("false");
        }
        //Debug.Log("has item false");
        have_item = false;
        //Debug.Log(slot_pos);
        //Debug.Log(gameObject.GetComponent<RectTransform>().localPosition.x);
        slot_pos = new Vector3(slot_pos.x, slot_pos.y, 0);
        slot_rect.localPosition = slot_pos;
        item_drag.SetActive(false);
        //manager_all.GetComponent<UI_manage>().drag_item = null;
        //manager_all.GetComponent<UI_manage>().drag_item_data = null;
        if (cor_pointer_up == false)
        {
            StartCoroutine(pointer_up());
        }
    }


    IEnumerator trans_item()
    {
        trans_cor_on = true;
        //slot_pos = new Vector3(slot_rect.localPosition.x, slot_rect.localPosition.y, slot_rect.localPosition.z);
        //slot_rect.SetAsFirstSibling();
        yield return new WaitForSeconds(1f);
        have_item = true;
        //item_drag.GetComponent<drag_ui>().on_last_sb();


        if(item != null && item.item_image != null)
        {
            item_drag.GetComponent<Image>().sprite = item.item_image;
        }
        
        GameObject temp_obj = GameObject.Find("game_manager_all");
        temp_obj.GetComponent<UI_manage>().drag_item = gameObject;
        Debug.Log("have_item_true");
        trans_cor_on = false;
        //yield return null;
    }

    IEnumerator pointer_up()
    {
        Debug.Log("pointer_up");
        cor_pointer_up = true;
        yield return new WaitForSeconds(0.1f);
        cor_pointer_up = false;
    }


    /*
    public void OnDrop(PointerEventData eventData) //모바일에서는 가상의 커서 오브젝트도 추가해서 포인터 엔터나 드롭에 커서 오브젝트 투하되면 호출되는거로 해보기 드롭에는 가상의 커서가 하이어라키에서 맨 앞에 있어야 슬롯에 커서가 드롭된거로 판별됨
    {
        item_data draging_item = GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().item;
        item_data temp_data;
        Debug.Log("drop_active");
        Debug.Log(gameObject);
        Debug.Log(eventData);
        Debug.Log(gameObject == GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item);
        if (draging_item != null)
        {
            Debug.Log("swap_item");
            Debug.Log(gameObject);
            temp_data = item;
            item = draging_item;
            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().item = temp_data;
            if(!(gameObject == GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item))
            {
                GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
            }
            
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("enter");
        //Debug.Log(gameObject);
        //Debug.Log(eventData);
        if (GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item != null && GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().cor_pointer_up == true)
        {
            //swapitem구현
            item_data draging_item = GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().item;
            item_data temp_data;
            Debug.Log("swap_item2");
            Debug.Log(gameObject);
            temp_data = item;
            item = draging_item;
            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().item = temp_data;

            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
        }
        GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
    }*/

    /*
    public void OnPointerExit(PointerEventData eventData)
    {
        if (trans_cor_on == false)
        {
            //StartCoroutine(trans_item());
            StartCoroutine(co_trnas_item);
        }
    }*/
}
