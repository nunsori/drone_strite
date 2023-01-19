using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class item_data : ScriptableObject
{
    [SerializeField]
    public string item_name;
    [SerializeField]
    public Sprite item_image;
    [SerializeField]
    public int item_code;
    [SerializeField]
    public string item_type;  //skill or item
    [SerializeField]
    public string parts;
    [SerializeField]
    public string item_element;
    [SerializeField]
    public int atk, def, hp, rank, enhance, skill_cool;
    [SerializeField]
    public string tool_tip;
    [SerializeField]
    public int skill_damage_percent;
    [SerializeField]
    public GameObject skill_hit_box;
    [SerializeField]
    public float hit_box_pivot_x, hit_box_pivot_y;
    [SerializeField]
    public item_data next_skill,previous_skill;
    [SerializeField]
    public float skill_duration, first_delay, last_delay;
    [SerializeField]
    public AnimationClip skill_effect;
    [SerializeField]
    public GameObject additional_function;
    [SerializeField]
    public bool fasten;
    [SerializeField]
    public float hitbox_x, hitbox_y, hitbox_rotation;
}
