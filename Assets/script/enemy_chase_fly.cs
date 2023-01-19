using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_chase_fly : MonoBehaviour
{
    public enemy_fly_chase enemy_Fly_Chase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*
            if (collision.transform.position.x - gameObject.transform.position.x > 0)
            {
                //go right
                go_right = true;

            }
            else if (collision.transform.position.x - gameObject.transform.position.x < 0)
            {
                //go left
                go_left = true;

            }*/
            enemy_Fly_Chase.move_par = -(gameObject.transform.position - collision.transform.position);

        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*
            if (collision.transform.position.x - gameObject.transform.position.x > 0)
            {
                //go right
                go_right = true;
                go_left = false;

            }
            else if (collision.transform.position.x - gameObject.transform.position.x < 0)
            {
                //go left
                go_left = true;
                go_right = false;

            }*/
            enemy_Fly_Chase.move_par = -(gameObject.transform.position - collision.transform.position);
            enemy_Fly_Chase.dis = Vector3.Distance(gameObject.transform.position, collision.transform.position);

        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            /*
            if (collision.transform.position.x - gameObject.transform.position.x > 0)
            {
                //go right
                go_right = false;

            }
            else if (collision.transform.position.x - gameObject.transform.position.x < 0)
            {
                //go left
                go_left = false;

            }*/
            enemy_Fly_Chase.move_par = new Vector2(0, 0);
            enemy_Fly_Chase.dis = 0f;
            float time = Random.Range(2f, 4f);
            enemy_Fly_Chase.re_in(time);
            

        }
    }
}
