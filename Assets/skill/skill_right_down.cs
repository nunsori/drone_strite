using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_right_down : skill_additional_function
{
    void Start()
    {

        StartCoroutine(right_down());
    }

    public override void additional_function()
    {
        Instantiate(gameObject, game_manage.Instance.player_obj.transform.position, Quaternion.identity);
    }

    IEnumerator right_down()
    {
        Rigidbody2D player_rigid = game_manage.Instance.player_obj.GetComponent<Rigidbody2D>();
        Debug.Log("right_down_skill");
        if(game_manage.Instance.player_obj.GetComponent<SpriteRenderer>().flipX == true)
        {
            player_rigid.velocity = new Vector2(-30, -15);
        }
        else
        {
            player_rigid.velocity = new Vector2(30, -15);
        }
        
        float temp_g = player_rigid.gravityScale;
        player_rigid.gravityScale = 0;
        yield return new WaitForSeconds(0.2f);
        player_rigid.velocity = Vector2.zero;
        player_rigid.gravityScale = temp_g;
        Destroy(gameObject);
    }
}
