using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_single : MonoBehaviour
{
    //public GameObject camera_instance;
    private Transform player_trnas;

    private void Awake()
    {
        /*
        if (camera_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        camera_instance = this.gameObject;
        DontDestroyOnLoad(gameObject);*/
    }


    // Start is called before the first frame update
    void Start()
    {
        player_trnas = player_attack.Player_atk_instance.transform;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector3(player_trnas.position.x, player_trnas.position.y, player_trnas.position.z - 5);
        
    }
}
