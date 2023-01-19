using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_src : MonoBehaviour
{

    public int damage;
    public KeyCode skill_key_code = KeyCode.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(skill_key_code != KeyCode.None)
        {
            if (Input.GetKey(skill_key_code))
            {

            }
        }
        
    }
}
