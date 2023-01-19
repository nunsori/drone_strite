using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D player_rigidbody;
    public float speed = 0.7f;
    public float max_speed = 3f;
    public bool onground = false;
    public player_attack player_attack_script;
    public Animator player_anim;

    public int player_health;
    //public GameObject sample_attack;


    //private List<int>
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D boxcollider;
    void Start()
    {
        
        player_health = 100;
        player_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxcollider = gameObject.GetComponent<CapsuleCollider2D>();
        player_attack_script = gameObject.GetComponent<player_attack>();
        player_anim = gameObject.GetComponent<Animator>();
        game_manage.Instance.player_obj = gameObject;
        game_manage.Instance.player_Movement = this;
        game_manage.Instance.player_died = false;
        game_manage.Instance.game_start();
        Debug.Log("start_@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        //game_manage.Instance.game_start();
    }

    /*
    private void OnEnable()
    {
        player_health = 100;
        player_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxcollider = gameObject.GetComponent<CapsuleCollider2D>();
        player_attack_script = gameObject.GetComponent<player_attack>();
        player_anim = gameObject.GetComponent<Animator>();
        game_manage.Instance.player_obj = gameObject;
        game_manage.Instance.player_Movement = this;
        game_manage.Instance.player_died = false;
        game_manage.Instance.game_start();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onground && gameObject.layer != 8)
            {
                Debug.Log("jump");
                jump();
            }

        }

        if (Input.GetButtonUp("Horizontal"))
        {
            if (onground)
            {
                //player_rigidbody.velocity = new Vector2(0, player_rigidbody.velocity.y);
            }
            
        }


        if(player_attack_script.test_attack_cor_on == false)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;

            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;

            }
        }

        if(onground == false)
        {
            player_anim.SetBool("is_ground", false);
        }else if(onground == true)
        {
            player_anim.SetBool("is_ground", true);
        }

        if (player_health <= 0)
        {
            player_died();
        }

        if(gameObject.transform.position.y < -6)
        {
            playerre();
        }
        
    }

    private void FixedUpdate()
    {
        float horize = Input.GetAxisRaw("Horizontal");

        if(player_attack_script.test_attack_cor_on == false && player_attack_script.sample_skill_cor_on==false)
        {
            if (onground && gameObject.layer != 8) //바닥에 있을때
            {
                player_rigidbody.AddForce(new Vector2(speed * horize, 0), ForceMode2D.Impulse);
                //player_anim.SetBool("run", true);

                if (player_rigidbody.velocity.x > max_speed)
                {
                    player_rigidbody.velocity = new Vector2(max_speed, player_rigidbody.velocity.y);
                }

                if (player_rigidbody.velocity.x < -1 * max_speed)
                {
                    player_rigidbody.velocity = new Vector2(-max_speed, player_rigidbody.velocity.y);
                }

                if (player_rigidbody.velocity.x < 0.5f && player_rigidbody.velocity.x > -0.5f /*&& horize == 0*/)
                {
                    player_anim.SetBool("run", false);
                }

                if (player_rigidbody.velocity.x != 0 && horize != 0)
                {
                    player_anim.SetBool("run", true);
                }

            }
            else if (gameObject.layer != 8) //공중에 떠있을 때
            {
                player_rigidbody.AddForce(new Vector2(horize / 50f, 0), ForceMode2D.Impulse);

                if (player_rigidbody.velocity.x > max_speed)
                {
                    player_rigidbody.velocity = new Vector2(max_speed, player_rigidbody.velocity.y);
                }

                if (player_rigidbody.velocity.x < -1 * max_speed)
                {
                    player_rigidbody.velocity = new Vector2(-max_speed, player_rigidbody.velocity.y);
                }
            }
        }

        
        

        Debug.DrawRay(player_rigidbody.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D ground_ray = Physics2D.Raycast(player_rigidbody.position, Vector3.down, 2, LayerMask.GetMask("ground"));

        //Debug.Log(gameObject.transform.localScale.x);


        if(ground_ray.collider != null)
        {
            //Debug.Log(ground_ray.distance);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //if (ground_ray.distance <= gameObject.transform.localScale.x / 2 + 0.1f)
            if(ground_ray.distance <= boxcollider.size.y/2 + 0.1f + Mathf.Abs(boxcollider.offset.y))
            {
                //Debug.Log("onground");
                onground = true;
            }
            else
            {
                onground = false;
            }
        }

        
    }

    private void jump()
    {
        player_rigidbody.AddForce(new Vector2(0, 300f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 11)
        {
            damaged(collision.transform.position);
        }
    }

    private void damaged(Vector2 target)
    {
        if(gameObject.layer != 8)
        {
            player_health -= 10;
            //gameObject.layer = LayerMask.GetMask("damaged");
            gameObject.layer = 8;

            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

            int dir = (gameObject.transform.position.x > target.x) ? 1 : -1;

            player_rigidbody.AddForce(new Vector2(dir , 1) * 3, ForceMode2D.Impulse);

            Invoke("offdamaged", 2);
        }
        
    }

    private void offdamaged()
    {
        // gameObject.layer = LayerMask.GetMask("player_default");
        gameObject.layer = 9;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        
    }

    private void player_died()
    {
        //died
        player_health = 100;
        game_manage.Instance.player_died = true;
        game_manage.Instance.game_out();
        
    }

    private void playerre()
    {
        player_health /= 2;
        gameObject.transform.position = new Vector3(1, 2);
    }

}
