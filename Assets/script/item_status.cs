using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_status : MonoBehaviour
{
    public Sprite item_img;
    public SpriteRenderer item_renderer;

    public int item_code;
    public bool obj;
    public string item_type;
    public string parts;

    public string element_type, item_name;
    public int atk, def, hp, rank, enhance;


    public string skill_name,tool_tip;
    public int damage_per;
    public GameObject hitbox;


    // Start is called before the first frame update
    void Start()
    {
        item_renderer.sprite = item_img;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
