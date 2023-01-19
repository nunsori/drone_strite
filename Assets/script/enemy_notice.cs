using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_notice : MonoBehaviour
{
    public enemy_chase enemy_Chase;
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
            if (collision.transform.position.x - gameObject.transform.position.x > 0)
            {
                //go right
                enemy_Chase.go_right = true;

            }
            else if (collision.transform.position.x - gameObject.transform.position.x < 0)
            {
                //go left
                enemy_Chase.go_left = true;

            }
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x - gameObject.transform.position.x > 0)
            {
                //go right
                enemy_Chase.go_right = true;
                enemy_Chase.go_left = false;

            }
            else if (collision.transform.position.x - gameObject.transform.position.x < 0)
            {
                //go left
                enemy_Chase.go_left = true;
                enemy_Chase.go_right = false;

            }

            enemy_Chase.dis = Vector3.Distance(gameObject.transform.position, collision.transform.position);

        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x - gameObject.transform.position.x > 0)
            {
                //go right
                enemy_Chase.go_right = false;

            }
            else if (collision.transform.position.x - gameObject.transform.position.x < 0)
            {
                //go left
                enemy_Chase.go_left = false;

            }
            enemy_Chase.dis = 0f;
            float time = Random.Range(2f, 4f);
            //Invoke("enemy_behavior", time);
            enemy_Chase.re_in(time);

        }
    }
}
