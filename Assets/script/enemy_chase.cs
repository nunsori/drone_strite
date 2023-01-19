using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_chase : MonoBehaviour
{
    public Rigidbody2D enemy_rigid_2d;
    public int move_par;
    public float scale;
    public BoxCollider2D enemy_notice;
    public GameObject attack_obj;


    public bool go_right = false;
    public bool go_left = false;

    bool attack_cor_on = false;

    public float dis;


    // Start is called before the first frame update

    private void Awake()
    {
        enemy_rigid_2d = GetComponent<Rigidbody2D>();
        Invoke("enemy_behavior", 3);
        attack_obj.SetActive(false);
        go_left = false;
        go_right = false;
    }

    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        enemy_rigid_2d.velocity = new Vector2(move_par, enemy_rigid_2d.velocity.y);

        Vector2 frontVec = new Vector2(enemy_rigid_2d.position.x + move_par*scale, enemy_rigid_2d.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("ground"));
        
        
        
        if (raycast.collider == null) //이거 나중에 다르게 꾸면 될거같음
        {
            Debug.Log("경고! 이 앞은 낭떨어지");
            move_par *= -1; //우리가 직접 방향을 바꾸어 주었으니 Think는 잠시 멈추어야함
            CancelInvoke(); //think를 잠시 멈춘 후 재실행
            float time = Random.Range(2f, 4f);
            Invoke("enemy_behavior", time);
        }


        if(raycast.collider != null && go_left)
        {
            CancelInvoke();
            move_par = -1;
        }
        else if(raycast.collider != null && go_right)
        {
            CancelInvoke();
            move_par = 1;
        }
        else if(raycast.collider != null && !go_right && !go_left)
        {

        }


        

    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(dis) <= 1.5 && attack_cor_on == false && dis!=0f)
        {
            //@@@@@ attack
            StartCoroutine(attack());
        }

        enemy_notice.transform.position = gameObject.transform.position;
        
    }


    public void enemy_behavior()
    {
        move_par = Random.Range(-1, 2);

        float time = Random.Range(2f, 5f);

        Invoke("enemy_behavior", time);

    }


    

    IEnumerator attack()
    {
        attack_cor_on = true;
        yield return new WaitForSeconds(0.5f);
        attack_obj.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attack_obj.SetActive(false);
        attack_cor_on = false;
    }

    public void re_in(float time)
    {
        Invoke("enemy_behavior", time);
    }
}
