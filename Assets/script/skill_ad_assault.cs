using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_ad_assault : skill_additional_function
{
    public void Start()
    {
        Debug.Log("start");
        //StartCoroutine(start_cor());
        StartCoroutine(assault_cor());
    }

    private void Update()
    {
        //Debug.Log("mono_update");
    }
    public override void additional_function()
    {
        //gameObject.SetActive(true);
        //StartCoroutine(assault_cor());
        Debug.Log("additional function");
        Instantiate(gameObject, game_manage.Instance.player_obj.transform.position, Quaternion.identity);

        //StartCoroutine(assault_cor());

    }

    IEnumerator assault_cor()
    {
        Rigidbody2D player_rigid = game_manage.Instance.player_obj.GetComponent<Rigidbody2D>();
        player_rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        player_rigid.freezeRotation = true;
        if(game_manage.Instance.player_obj.GetComponent<SpriteRenderer>().flipX == true)
        {
            player_rigid.velocity = new Vector2(-50, 0);
        }
        else
        {
            player_rigid.velocity = new Vector2(50, 0);
        }
        
        
        yield return new WaitForSeconds(0.1f);
        player_rigid.velocity = new Vector2(0, 0);
        player_rigid.constraints = RigidbodyConstraints2D.None;
        player_rigid.freezeRotation = true;
        Destroy(gameObject);
    }

    IEnumerator start_cor()
    {
        yield return new WaitForSeconds(0.01f);
    }
}
