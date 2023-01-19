using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class player_attack : MonoBehaviour
{
    public Transform player_trans;
    private Vector2 attack_pos;
    private Vector2 size;

    public GameObject[] skill_set_player;

    public bool test_attack_cor_on = false;
    public game_manage game_manager_all_cs;
    

    public bool sample_skill_cor_on = false;

    public GameObject skill_effect_1;
    public GameObject skill_effect_2;

    public static GameObject Player_atk_instance;


    public int player_atk = 10;
    //public GameObject[] skill_hitbox = new GameObject[10];

    [Serializable]
    public struct skill_set {
        public string skill_code;
        public GameObject skill_hit_box;
        /*
        public skill_set(string skill_code, GameObject skill_hit_box)
        {
            this.skill_code = skill_code;
            this.skill_hit_box = skill_hit_box;
        }*/
    }

    public skill_set[] skill_allocation = new skill_set[4];
    

    public GameObject sample_attack;

    IEnumerator[] linkage_skill_cool_cor;
    bool[] linkage_cor_bool;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Player_atk_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Player_atk_instance = this.gameObject;
        DontDestroyOnLoad(gameObject);



    }
    /*
    private void OnEnable()
    {
        game_manager_all_cs = game_manage.Instance;
        player_trans = gameObject.GetComponent<Transform>();
        size = new Vector2(player_trans.localScale.x, player_trans.localScale.y);
        sample_attack.SetActive(false);

        game_manager_all_cs.game_progress_player_status_ui.SetActive(true);
        skill_set_player = new GameObject[game_manager_all_cs.skill_key_set.Length];

        for (int i = 0; i < skill_set_player.Length; i++)
        {
            if (game_manager_all_cs.skill_key_set[i].GetComponent<inven_slot_left>().item == null)
            {
                continue;
            }
            skill_set_player[i] = game_manager_all_cs.skill_key_set[i];
            game_manager_all_cs.game_progress_skill_ui[i].GetComponent<Image>().sprite = game_manager_all_cs.skill_key_set[i].GetComponent<inven_slot_left>().item.item_image;
        }

        linkage_skill_cool_cor = new IEnumerator[game_manage.Instance.game_progress_skill_ui.Length];
        linkage_cor_bool = new bool[game_manage.Instance.game_progress_skill_ui.Length];
        for (int i = 0; i < linkage_cor_bool.Length; i++)
        {
            linkage_cor_bool[i] = false;
        }
    }*/

    void Start()
    {
        //game_manager_all_cs = gameObject.transform.Find("game_manager_all").GetComponent<game_manage>();
        game_manager_all_cs = game_manage.Instance;
        player_trans = gameObject.GetComponent<Transform>();
        size = new Vector2(player_trans.localScale.x, player_trans.localScale.y);
        sample_attack.SetActive(false);
        

        game_manager_all_cs.game_progress_player_status_ui.SetActive(true);

        skill_set_player = new GameObject[game_manager_all_cs.skill_key_set.Length];

        for(int i =0; i<skill_set_player.Length; i++)
        {
            if (game_manager_all_cs.skill_key_set[i].GetComponent<inven_slot_left>().item == null)
            {
                continue;
            }
            skill_set_player[i] = game_manager_all_cs.skill_key_set[i];
            game_manager_all_cs.game_progress_skill_ui[i].GetComponent<Image>().sprite = game_manager_all_cs.skill_key_set[i].GetComponent<inven_slot_left>().item.item_image;
        }

        linkage_skill_cool_cor = new IEnumerator[game_manage.Instance.game_progress_skill_ui.Length];
        linkage_cor_bool = new bool[game_manage.Instance.game_progress_skill_ui.Length];
        for(int i = 0; i<linkage_cor_bool.Length; i++)
        {
            linkage_cor_bool[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        attack_pos = new Vector2(player_trans.position.x - (player_trans.localScale.x / 2), player_trans.position.y);


        if(test_attack_cor_on == false)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //sample_attack.transform.position = new Vector3(sample_attack.transform.position.x * -1 , sample_attack.transform.position.y, sample_attack.transform.position.z);
                if (sample_attack.transform.localPosition.x > 0)
                {
                    sample_attack.transform.localPosition = new Vector3(sample_attack.transform.localPosition.x * -1, sample_attack.transform.localPosition.y, sample_attack.transform.localPosition.z);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {

                //sample_attack.transform.position = new Vector3(sample_attack.transform.position.x * -1, sample_attack.transform.position.y, sample_attack.transform.position.z);
                if (sample_attack.transform.localPosition.x < 0)
                {
                    sample_attack.transform.localPosition = new Vector3(sample_attack.transform.localPosition.x * -1, sample_attack.transform.localPosition.y, sample_attack.transform.localPosition.z);
                }
            }
        }

        /*
        if (Input.GetKey(KeyCode.Z))
        {
            //attack_pos = new Vector2(player_trans.position.x - (player_trans.localScale.x / 2), player_trans.position.y);
            if (test_attack_cor_on == false)
            {
                StartCoroutine("test_attack");
            }
        }
        else if (Input.GetKey(KeyCode.X))
        {
            if(test_attack_cor_on == false)
            {

            }
        }*/

        for(int i = 0; i< skill_set_player.Length; i++)
        {
            if (Input.GetKey(game_manager_all_cs.skill_key_code[i]))
            {
                if(sample_skill_cor_on == false && game_manager_all_cs.game_progress_skill_ui[i].GetComponent<skill_cool_down>().is_skill_enable == true)
                {
                    StartCoroutine(sample_skill(game_manager_all_cs.skill_key_set[i],i)); // @@@@@@@@@@@@@@@@@@@@@@@@@@스킬 구현부
                }
                
            }
        }
        
        if(sample_skill_cor_on == true)
        {
            gameObject.layer = 10;
        }
        else
        {
            gameObject.layer = 9;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attack_pos, size);
    }

    IEnumerator test_attack()
    {
        test_attack_cor_on = true;
        Debug.Log("start_test_attack");
        yield return new WaitForSeconds(0.05f);

        //insert attack
        /*
        Collider2D[] hit = Physics2D.OverlapBoxAll(attack_pos, size, 0);
        
        foreach (Collider2D hit2 in hit)
        {
            if (hit2.name == "enemy")
            {
                Debug.Log("hit enemy");
                Debug.Log(hit2.GetComponent<Transform>().position.x); //뭐지..

            }
        }*/
        

        sample_attack.SetActive(true);
        //sample_attack.transform.position = gameObject.transform.position;

        yield return new WaitForSeconds(0.2f);

        sample_attack.SetActive(false);
        test_attack_cor_on = false;
    }

    IEnumerator skill_dash()
    {
        test_attack_cor_on = true;
        Debug.Log("start_test_attack_x");
        yield return new WaitForSeconds(0.05f);


    }

    IEnumerator sample_skill(GameObject skill_data, int index)
    {
        if(skill_data.GetComponent<inven_slot_left>().item.previous_skill != null || skill_data.GetComponent<inven_slot_left>().item.next_skill != null)
        {
            linkage_cor_bool[index] = true;
        }
        
        sample_skill_cor_on = true;
        yield return new WaitForSeconds(skill_data.GetComponent<inven_slot_left>().item.first_delay);

        Vector3 skill_pos;
        if(gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            skill_pos = new Vector3(gameObject.transform.position.x + skill_data.GetComponent<inven_slot_left>().item.hit_box_pivot_x, gameObject.transform.position.y + skill_data.GetComponent<inven_slot_left>().item.hit_box_pivot_y, gameObject.transform.position.z);
        }
        else
        {
            skill_pos = new Vector3(gameObject.transform.position.x - skill_data.GetComponent<inven_slot_left>().item.hit_box_pivot_x, gameObject.transform.position.y - skill_data.GetComponent<inven_slot_left>().item.hit_box_pivot_y, gameObject.transform.position.z);
        }
        

        skill_data.GetComponent<inven_slot_left>().item.additional_function.GetComponent<skill_additional_function>().additional_function(); //additional function 주로 이동기


        GameObject temp_hit_box = Instantiate(skill_data.GetComponent<inven_slot_left>().item.skill_hit_box, skill_pos, Quaternion.identity); // 히트박스 생성
        //temp_hit_box.transform.localScale = new Vector2(skill_data.GetComponent<inven_slot_left>().item.hitbox_x, skill_data.GetComponent<inven_slot_left>().item.hitbox_y);
        if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            temp_hit_box.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -skill_data.GetComponent<inven_slot_left>().item.hitbox_rotation));
        }
        else
        {
            temp_hit_box.transform.rotation = Quaternion.Euler(new Vector3(0, 0, skill_data.GetComponent<inven_slot_left>().item.hitbox_rotation));
        }
        



        if (skill_data.GetComponent<inven_slot_left>().item.fasten == true)
        {
            
                Debug.Log("1 effect");
                if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
                {
                    skill_effect_1.GetComponent<SpriteRenderer>().flipX = true;
                    //gameObject.transform.localPosition = new Vector3(skill_data.hit_box_pivot_x, skill_data.hit_box_pivot_y, gameObject.transform.position.z);
                }
                else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
                {
                    skill_effect_1.GetComponent<SpriteRenderer>().flipX = false;
                    //gameObject.transform.localPosition = new Vector3(-skill_data.hit_box_pivot_x, skill_data.hit_box_pivot_y, gameObject.transform.position.z);
                }


            #if UNITY_EDITOR
            skill_effect_1.GetComponent<skill_effect_on>().skill_data = skill_data.GetComponent<inven_slot_left>().item;
            #endif
            skill_effect_1.transform.localPosition = temp_hit_box.transform.position;
            skill_effect_1.transform.localScale = new Vector2(skill_data.GetComponent<inven_slot_left>().item.hitbox_x, skill_data.GetComponent<inven_slot_left>().item.hitbox_y);
            if(gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                skill_effect_1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -skill_data.GetComponent<inven_slot_left>().item.hitbox_rotation));
            }
            else
            {
                skill_effect_1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, skill_data.GetComponent<inven_slot_left>().item.hitbox_rotation));
            }
            
            //skill_effect_1.GetComponent<skill_effect_on>().sample_animation = skill_data.GetComponent<inven_slot_left>().item.skill_effect;
            skill_effect_1.SetActive(true); //이펙트 생성
        }
        else
        {
            
                Debug.Log("2 effect");
                if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
                {
                    skill_effect_2.GetComponent<SpriteRenderer>().flipX = true;
                    //gameObject.transform.position = new Vector3(player_sprt.transform.position.x + skill_data.hit_box_pivot_x, player_sprt.transform.position.y + skill_data.hit_box_pivot_y, gameObject.transform.position.z);
                }
                else if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
                {
                    skill_effect_2.GetComponent<SpriteRenderer>().flipX = false;
                    //gameObject.transform.position = new Vector3(player_sprt.transform.position.x - skill_data.hit_box_pivot_x, player_sprt.transform.position.y + skill_data.hit_box_pivot_y, gameObject.transform.position.z);
                }


            #if UNITY_EDITOR
            skill_effect_2.GetComponent<skill_effect_on>().skill_data = skill_data.GetComponent<inven_slot_left>().item;
            #endif
            skill_effect_2.transform.position = temp_hit_box.transform.position;
            skill_effect_2.transform.localScale = new Vector2(skill_data.GetComponent<inven_slot_left>().item.hitbox_x, skill_data.GetComponent<inven_slot_left>().item.hitbox_y);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                skill_effect_2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -skill_data.GetComponent<inven_slot_left>().item.hitbox_rotation));
            }
            else
            {
                skill_effect_2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, skill_data.GetComponent<inven_slot_left>().item.hitbox_rotation));
            }
            //skill_effect_2.GetComponent<skill_effect_on>().sample_animation = skill_data.GetComponent<inven_slot_left>().item.skill_effect;
            skill_effect_2.SetActive(true); //이펙트 생성
        }

        



        yield return new WaitForSeconds(skill_data.GetComponent<inven_slot_left>().item.skill_duration);
        Destroy(temp_hit_box);

        

        yield return new WaitForSeconds(skill_data.GetComponent<inven_slot_left>().item.last_delay);
        if(skill_data.GetComponent<inven_slot_left>().item.next_skill == null)
        {
            float temp_cool = skill_data.GetComponent<inven_slot_left>().item.skill_cool;
            //bool previous_true = false;
            while(skill_data.GetComponent<inven_slot_left>().item.previous_skill != null)//연계기의 끝이었을 경우 맨 앞스킬로 초기화
            {
                skill_data.GetComponent<inven_slot_left>().item = skill_data.GetComponent<inven_slot_left>().item.previous_skill;
                //previous_true = true;
                if(skill_data.GetComponent<inven_slot_left>().item.previous_skill == null)
                {
                    break;
                }
            }


            StartCoroutine(sample_skill_cool(game_manager_all_cs.game_progress_skill_ui[index], temp_cool)); //그냥 쿨타임 적용
        }
        else
        {
            // 연계기 따로 쿨타임 시작
            // 다음 연계기로 교체
            skill_data.GetComponent<inven_slot_left>().item = skill_data.GetComponent<inven_slot_left>().item.next_skill;
            linkage_skill_cool_cor[index] = null;
            linkage_skill_cool_cor[index] = linkage_cool(skill_data, game_manager_all_cs.game_progress_skill_ui[index], skill_data.GetComponent<inven_slot_left>().item.skill_cool, index);
            linkage_cor_bool[index] = false;
            StartCoroutine(linkage_skill_cool_cor[index]);

        }
        
        sample_skill_cor_on = false;
    }

    IEnumerator sample_skill_cool(GameObject skill_ui, float cool_time)
    {
        float text_cool = cool_time;
        skill_ui.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:F1}", text_cool);
        skill_ui.transform.GetChild(1).gameObject.SetActive(true);
        skill_ui.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 1;
        skill_ui.GetComponent<skill_cool_down>().is_skill_enable = false;
        for(float i = 0; i<cool_time; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            text_cool -= 0.1f;
            //text_cool /= 0.01f;
            skill_ui.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 1 - (i / cool_time);
            skill_ui.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:F1}", text_cool);//text_cool.ToString();
        }
        skill_ui.GetComponent<skill_cool_down>().is_skill_enable = true;
        skill_ui.transform.GetChild(1).gameObject.SetActive(false);
    }

    IEnumerator linkage_cool(GameObject skill_data, GameObject skill_ui, float cool_time, int index)
    {

        Debug.Log("linkage cool @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        // 이 딜레이중에 skill_cor 이 on되면 이 코루틴을 중단하는 매커니즘 제작 필요
        float text_cool = cool_time;
        //while(sample_skill_cor_on != true)
        //{
        if (linkage_cor_bool[index] == true)
        {
            Debug.Log("stop linkage cool");
            StopCoroutine(linkage_skill_cool_cor[index]);
        }
        skill_ui.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.F1}", text_cool);
        skill_ui.transform.GetChild(1).gameObject.SetActive(true);
        skill_ui.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 1;
        //skill_ui.GetComponent<skill_cool_down>().is_skill_enable = false;
        for (float i = 0; i < cool_time; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);

            text_cool -= 0.1f;
            //text_cool /= 0.01f;
            skill_ui.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 1 - (i / cool_time);
            skill_ui.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:F1}", text_cool);//text_cool.ToString();
            if (linkage_cor_bool[index] == true)
            {
                Debug.Log("stop linkage cool");
                StopCoroutine(linkage_skill_cool_cor[index]);
            }
        }
        //skill_ui.GetComponent<skill_cool_down>().is_skill_enable = true;
        if (linkage_cor_bool[index] == true)
        {
            Debug.Log("stop linkage cool");
            StopCoroutine(linkage_skill_cool_cor[index]);
        }
        skill_ui.transform.GetChild(1).gameObject.SetActive(false);
        //break;
        //재사용 안했을때 맨 처음 스킬로 돌려주기
        while (skill_data.GetComponent<inven_slot_left>().item.previous_skill != null)//연계기의 끝이었을 경우 맨 앞스킬로 초기화
        {
            skill_data.GetComponent<inven_slot_left>().item = skill_data.GetComponent<inven_slot_left>().item.previous_skill;
            //previous_true = true;
            if (skill_data.GetComponent<inven_slot_left>().item.previous_skill == null)
            {
                break;
            }
        }



        float temp_cool = skill_data.GetComponent<inven_slot_left>().item.skill_cool;
        StartCoroutine(sample_skill_cool(game_manager_all_cs.game_progress_skill_ui[index], temp_cool));
        //쿨타임 다 됬을 때 맨 끝의 스킬의 쿨타임을 적용하여 sample_skill_cor 호출하기
        //}

    }

}
