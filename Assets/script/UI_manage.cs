using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_manage : MonoBehaviour
{
    public GameObject inven_ui;
    public GameObject skill_inven;

    public GameObject drag_item;
    public GameObject drag_item_data;

    public GameObject game_progress_ui;
    

    // Start is called before the first frame update
    void Start()
    {
        inven_off();
        ui_off(skill_inven);
        ui_off(game_progress_ui);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inven_on()
    {
        inven_ui.SetActive(true);
    }

    public void inven_off()
    {
        inven_ui.SetActive(false);
    }

    public void ui_off(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ui_on(GameObject obj)
    {
        obj.SetActive(true);
    }

    
}
