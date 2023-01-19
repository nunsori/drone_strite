using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class game_manage : MonoBehaviour
{

    public static game_manage Instance;

    public GameObject[] inven_skill;
    public GameObject[] inven_item_wep;
    public GameObject[] inven_item_top;
    public GameObject[] inven_item_bottom;
    public GameObject[] inven_item_glove;
    public GameObject[] inven_item_head;

    public GameObject inven_view_weapon;
    public GameObject inven_view_top;
    public GameObject inven_view_bottom;
    public GameObject inven_view_glove;
    public GameObject inven_view_head;
    public GameObject inven_view_skill;


    public GameObject item_info_right_bg;
    public GameObject item_info_left_bg;

    public GraphicRaycaster g_ray;
    public List<RaycastResult> g_ray_results;
    public GameObject m_cursor;
    public GameObject m_cursor2;


    public GameObject[] skill_key_set;
    public GameObject[] item_set;

    public KeyCode[] skill_key_code;

    public GameObject[] game_progress_skill_ui;
    public GameObject game_progress_player_status_ui;

    public GameObject player_obj;
    public player_movement player_Movement;
    public Image player_hp_bar;

    public bool player_died = false;

    public Transform[] spawn_area_ground;
    public Transform[] spawn_area_sky;

    public GameObject enemy_ground;
    public GameObject enemy_sky;

    public bool game_on = false;
    public float timer = 0f;
    public GameObject progress_canvus;

    public GameObject bat_ui;
    public GameObject otherui;

    private IEnumerator gamecor;

    public int total_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 30; //@프레임 조절 @@@@@@@@@@@@@@@

        item_info_right_bg.SetActive(false);
        item_info_left_bg.SetActive(false);
        /*
        for (int i = 0; i < 5; i++)
        {
            inven_item_wep[i] = new GameObject[5];
            inven_item_top[i] = new GameObject[5];
            inven_item_bottom[i] = new GameObject[5];
            inven_item_glove[i] = new GameObject[5];
            inven_item_head[i] = new GameObject[5];
        }*/

        inven_item_wep = new GameObject[25];
        inven_item_top = new GameObject[25];
        inven_item_bottom = new GameObject[25];
        inven_item_glove = new GameObject[25];
        inven_item_head = new GameObject[25];


        inven_skill = new GameObject[100];

        string[] slot = { "row_1", "row_2", "row_3", "row_4", "row_5", "row_6", "row_7", "row_8", "row_9", "row_10", "row_11", "row_12", "row_13", "row_14", "row_15", "row_16", "row_17", "row_18", "row_19", "row_20" };


        Debug.Log(inven_view_weapon.transform.Find("row_1"));
        Debug.Log(inven_view_weapon.transform.Find(slot[0]));

        Transform pivot,pivot2,pivot3,pivot4,pivot5;
        int temp_count = 0;

        for(int j = 0; j<5; j++)
        {
            pivot = inven_view_weapon.transform.Find(slot[j]);
            pivot2 = inven_view_top.transform.Find(slot[j]);
            pivot3 = inven_view_bottom.transform.Find(slot[j]);
            pivot4 = inven_view_glove.transform.Find(slot[j]);
            pivot5 = inven_view_head.transform.Find(slot[j]);

            for (int i = 0; i < 5; i++)
            {
                inven_item_wep[temp_count] = pivot.GetChild(i).gameObject;
                inven_item_top[temp_count] = pivot2.GetChild(i).gameObject;
                inven_item_bottom[temp_count] = pivot3.GetChild(i).gameObject;
                inven_item_glove[temp_count] = pivot4.GetChild(i).gameObject;
                inven_item_head[temp_count] = pivot5.GetChild(i).gameObject;
                temp_count++;
            }
        }

        Transform pivot6;
        int temp_count_skill = 0;
        for(int i = 0; i<20; i++)
        {
            pivot6 = inven_view_skill.transform.Find(slot[i]);
            for(int j = 0; j<5; j++)
            {
                inven_skill[temp_count_skill++] = pivot6.GetChild(j).gameObject;
            }
        }

        //GameObject.Find("item_drag").SetActive(false);
        for (int i = 0; i < game_progress_skill_ui.Length; i++)
        {
            game_progress_skill_ui[i].transform.GetChild(0).GetComponent<Image>().fillAmount = 0;
            game_progress_skill_ui[i].transform.GetChild(1).gameObject.SetActive(false);
        }


    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_Movement != null)
        {
            player_hp_bar.fillAmount = player_Movement.player_health / 100f;
        }
        
    }

    public void insert_item(GameObject item)
    {
        item_status item_stat = item.GetComponent<item_status>();
        if(item_stat.parts == "weapon")
        {

        }
    }

    public void on_item_info(GameObject item_slot)
    {
        item_data item = item_slot.GetComponent<inven_slot>().item;
        Debug.Log("item_infffffffffffffo");
        if(item != null && gameObject.GetComponent<UI_manage>().drag_item == null&& item_slot != gameObject.GetComponent<UI_manage>().drag_item)
        {
            Transform temp_tr = item_info_right_bg.transform.Find("item_img");
            Transform find_item_name = item_info_right_bg.transform.Find("item_name");
            Transform find_item_tool_tip = item_info_right_bg.transform.Find("tool_tip_bg").Find("tool_tip_text");
            Debug.Log(find_item_name);
            //Debug.Log(item.GetComponent<item_status>().item_name);
            temp_tr.GetComponent<Image>().sprite = item.item_image;
            if(item.item_name != "")
            {
                find_item_name.GetComponent<TextMeshProUGUI>().text = item.item_name;
            }
            
            if(item.tool_tip != "")
            {
                Debug.Log(find_item_tool_tip);
                find_item_tool_tip.GetComponent<TextMeshProUGUI>().text = item.tool_tip;
            }
            item_info_right_bg.GetComponent<item_info_left>().linked_slot = item_slot;
            item_info_right_bg.SetActive(true);
        }
        


    }

    public void on_item_info_left(GameObject item_slot)
    {
        item_data item = item_slot.GetComponent<inven_slot_left>().item;
        Debug.Log("item_infffffffffffffo");
        if (item != null && gameObject.GetComponent<UI_manage>().drag_item == null && item_slot != gameObject.GetComponent<UI_manage>().drag_item)
        {
            Transform temp_tr = item_info_left_bg.transform.Find("item_img");
            Transform find_item_name = item_info_left_bg.transform.Find("item_name");
            Transform find_item_tool_tip = item_info_left_bg.transform.Find("tool_tip_bg").Find("tool_tip_text");
            Debug.Log(find_item_name);
            //Debug.Log(item.GetComponent<item_status>().item_name);
            temp_tr.GetComponent<Image>().sprite = item.item_image;
            if (item.item_name != "")
            {
                find_item_name.GetComponent<TextMeshProUGUI>().text = item.item_name;
            }

            if (item.tool_tip != "")
            {
                Debug.Log(find_item_tool_tip);
                find_item_tool_tip.GetComponent<TextMeshProUGUI>().text = item.tool_tip;
            }
            item_info_left_bg.GetComponent<item_info_left>().linked_slot = item_slot;
            item_info_left_bg.SetActive(true);
        }
    }


    public void graphic_ray_cast_ui()
    {
        g_ray_results = new List<RaycastResult>();
        var pd = new PointerEventData(null);
        
        pd.position = m_cursor.transform.position;
        g_ray.Raycast(pd, g_ray_results);

        for(int i = 0; i<g_ray_results.Count; i++)
        {
            if (g_ray_results[i].gameObject.name == "slot_1" || g_ray_results[i].gameObject.name == "slot_2" || g_ray_results[i].gameObject.name == "slot_3" || g_ray_results[i].gameObject.name == "slot_4" || g_ray_results[i].gameObject.name == "slot_5" 
                || g_ray_results[i].gameObject.name == "top" || g_ray_results[i].gameObject.name == "weapon"|| g_ray_results[i].gameObject.name == "bottom" || g_ray_results[i].gameObject.name == "glove"|| g_ray_results[i].gameObject.name == "head"
                || g_ray_results[i].gameObject.name == "skill_1" || g_ray_results[i].gameObject.name == "skill_2" || g_ray_results[i].gameObject.name == "skill_3" || g_ray_results[i].gameObject.name == "skill_4" || g_ray_results[i].gameObject.name == "skill_5")
            {
                Debug.Log("slot1");
                if(gameObject.GetComponent<UI_manage>().drag_item != null && gameObject.GetComponent<UI_manage>().drag_item != g_ray_results[i].gameObject)
                {
                    
                    item_data draging_item = gameObject.GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().item;
                    item_data temp_data;

                    if (g_ray_results[i].gameObject.name == "top" || g_ray_results[i].gameObject.name == "weapon" || g_ray_results[i].gameObject.name == "bottom" || g_ray_results[i].gameObject.name == "glove" || g_ray_results[i].gameObject.name == "head")
                    {
                        if (g_ray_results[i].gameObject.name != draging_item.parts)
                        {
                            Debug.Log("cant equip");
                            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
                            return;
                        }
                        else
                        {
                            g_ray_results[i].gameObject.GetComponent<inven_slot_left>().item = draging_item;
                            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
                            return;
                        }
                    }else if (g_ray_results[i].gameObject.name == "skill_1" || g_ray_results[i].gameObject.name == "skill_2" || g_ray_results[i].gameObject.name == "skill_3" || g_ray_results[i].gameObject.name == "skill_4" || g_ray_results[i].gameObject.name == "skill_5")
                    {
                        bool same = false;
                        for(int j = 0; j<skill_key_set.Length; j++)
                        {
                            if(skill_key_set[j].GetComponent<inven_slot_left>().item == draging_item)
                            {
                                same = true;
                                break;
                            }
                        }

                        if (same == false)
                        {
                            g_ray_results[i].gameObject.GetComponent<inven_slot_left>().item = draging_item;
                            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
                            return;
                        }else if(same == true)
                        {
                            Debug.Log("cant equip");
                            GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
                            return;
                        }
                        
                    }
                    Debug.Log("swap_item3333333333333");
                    Debug.Log(gameObject);
                    temp_data = g_ray_results[i].gameObject.GetComponent<inven_slot>().item;
                    g_ray_results[i].gameObject.GetComponent<inven_slot>().item = draging_item;
                    GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item.GetComponent<inven_slot>().item = temp_data;

                    GameObject.Find("game_manager_all").GetComponent<UI_manage>().drag_item = null;
                    
                    return;
                }
            }

            

        }

    }


    public void game_out()
    {
        UI_manage this_ui = gameObject.GetComponent<UI_manage>();
        player_obj.SetActive(false);
        
        this_ui.ui_off(game_progress_player_status_ui);
        //this_ui.ui_on(bat_ui);

        //StopAllCoroutines();
        StopCoroutine(gamecor);
        gamecor = null;

        SceneManager.LoadScene("exit_scene");
    }

    public void game_start()
    {
        
        //player hp 100으로 만들기
        player_obj.GetComponent<player_movement>().player_health = 100;
        player_obj.transform.position = new Vector2(1, 2);
        player_obj.SetActive(true);
        enemy_ground.transform.GetChild(0).GetComponent<enemy_status>().canvas = progress_canvus;
        enemy_sky.transform.GetChild(0).GetComponent<enemy_status>().canvas = progress_canvus;
        if(game_on == false)
        {
            gamecor = timer_and_spawn();
            StartCoroutine(gamecor);
        }
        Debug.Log("game-start");
    }

    IEnumerator timer_and_spawn()
    {

        game_on = true;
        yield return new WaitForSeconds(0.1f);
        timer += 0.1f;
        while (true)
        {
            yield return new WaitForSeconds(15f);
            timer += 5f;
            spawn_every_area();

            if(player_died == true)
            {
                break;
            }
        }
        game_on = false;
    }

    private void spawn_every_area()
    {
        for(int i = 0; i<spawn_area_ground.Length; i++)
        {
            float time = Random.Range(0f, 2f);
            if (time > 0.5)
            {
                Instantiate(enemy_ground, spawn_area_ground[i]);
            }
            
        }

        for(int i = 0; i<spawn_area_sky.Length; i++)
        {
            float time = Random.Range(0f, 2f);
            
            if (time > 0.5)
            {
                Instantiate(enemy_sky, spawn_area_sky[i]);
            }
        }
    }

}
