using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_spawn_area : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<11; i++)
        {
            game_manage.Instance.spawn_area_ground[i] = gameObject.transform.GetChild(i);
        }

        for (int i = 0; i < 11; i++)
        {
            game_manage.Instance.spawn_area_sky[i] = gameObject.transform.GetChild(11+ i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
