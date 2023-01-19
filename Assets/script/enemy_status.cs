using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_status : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hp_bar_prf;
    public GameObject hp_bar_outline_prf;
    public GameObject canvas;
    public int enemy_hp = 100;
    public Image hp_bar;
    public RectTransform hp_bar_rect;
    public RectTransform hp_bar_outline;
    public GameObject slider;
    public GameObject outline;

    void Start()
    {

        enemy_hp = 100;
        slider = Instantiate(hp_bar_prf, canvas.transform);
        outline = Instantiate(hp_bar_outline_prf, canvas.transform);
        hp_bar = slider.GetComponent<Image>();
        hp_bar_rect = hp_bar.GetComponent<RectTransform>();
        hp_bar_outline = outline.GetComponent<RectTransform>();
        Debug.Log("enemy");
        StartCoroutine(fade_cor());
    }

    // Update is called once per frame
    void Update()
    {
        hp_bar_rect.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + gameObject.transform.localScale.y / 2 + 0.3f, 0));
        hp_bar_outline.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + gameObject.transform.localScale.y / 2 + 0.3f, 0));
        hp_bar.GetComponent<Image>().fillAmount = enemy_hp / 100f;

        if(enemy_hp <= 0 || gameObject.transform.position.y < -5)
        {
            game_manage.Instance.total_count += 1;
            Destroy(slider);
            Destroy(outline);
            Destroy(gameObject.transform.parent.gameObject);
        }

    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            Debug.Log("ondamage3");
            //enemy_damage_in = enemy_damage(collision.gameObject);
            StartCoroutine("enemy_damage", collision.gameObject);
            //StartCoroutine(enemy_damage(collision.gameObject));
            //IEnumerator enemy_damage_cor = enemy_damage(collision.gameObject);
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            //Debug.Log("ondamage4"); // 이거는 여러번 호출됨
        }

    }

    IEnumerator enemy_damage(GameObject obj)
    {
        gameObject.layer = 12;
        yield return new WaitForSeconds(0.05f);
        Debug.Log("ondamage3333333");
        //enemy_hp -= obj.GetComponent<damage_src>().damage;
        enemy_hp -= 50;
        if (gameObject.GetComponent<enemy_fly_chase>())
        {
            gameObject.layer = 11;
        }
        else
        {
            gameObject.layer = 7;
        }
        
    }

    IEnumerator fade_cor()
    {
        yield return new WaitForSeconds(15f);
        Destroy(slider);
        Destroy(outline);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
