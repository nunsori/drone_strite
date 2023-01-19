using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prototype_1 : skill_additional_function
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(jump());
    }

    public override void additional_function()
    {
        Instantiate(gameObject, game_manage.Instance.player_obj.transform.position, Quaternion.identity);
    }

    IEnumerator jump()
    {
        //Rigidbody2D player_rigid = game_manage.Instance.player_obj.GetComponent<Rigidbody2D>();
        //Debug.Log("j_skill");
        //player_rigid.AddForce(new Vector2(0, 500));
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
