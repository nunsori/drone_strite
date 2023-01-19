using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif


public class skill_effect_on : MonoBehaviour
{
    public item_data skill_data;
    public SpriteRenderer player_sprt;
    public AnimationClip sample_animation;
    public float alpha;
    #if UNITY_EDITOR
    public Animator animator;
    public AnimationState default_state;
    


    public AnimatorController controller;

    public AnimatorState state;
    #endif
    //public Animation animation;

    //public Animation animation;

    private void OnEnable()
    {
        sample_animation = skill_data.skill_effect;

        #if UNITY_EDITOR
        animator = GetComponent<Animator>();

        controller = (AnimatorController)animator.runtimeAnimatorController;
        state = controller.layers[0].stateMachine.defaultState;


        controller.SetStateEffectiveMotion(state, sample_animation);
        #endif
        alpha = 1 + (skill_data.skill_duration + skill_data.last_delay) / skill_data.skill_effect.length;
    }

    private void Awake()
    {
        
        //Vector3 temp = gameObject.transform.lossyScale;
        //gameObject.transform.localScale = skill_data.skill_hit_box.transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        //sample_animation = null;
        

        //sample_animation = skill_data.skill_effect;
        //animation = GetComponent<Animation>();
        

        /*
        if(player_sprt.flipX == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x + skill_data.hit_box_pivot_x, gameObject.transform.position.y + skill_data.hit_box_pivot_y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x - skill_data.hit_box_pivot_x, gameObject.transform.position.y - skill_data.hit_box_pivot_y, gameObject.transform.position.z);
        }*/

        /*
        if(gameObject.name == "player_effect_1")
        {
            Debug.Log("1 effect");
            if (player_sprt.flipX == false)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                //gameObject.transform.localPosition = new Vector3(skill_data.hit_box_pivot_x, skill_data.hit_box_pivot_y, gameObject.transform.position.z);
            }
            else if(player_sprt.flipX == true)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                //gameObject.transform.localPosition = new Vector3(-skill_data.hit_box_pivot_x, skill_data.hit_box_pivot_y, gameObject.transform.position.z);
            }
        }
        else if(gameObject.name == "player_effect_2")
        {
            Debug.Log("2 effect");
            if (player_sprt.flipX == false)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                //gameObject.transform.position = new Vector3(player_sprt.transform.position.x + skill_data.hit_box_pivot_x, player_sprt.transform.position.y + skill_data.hit_box_pivot_y, gameObject.transform.position.z);
            }
            else if(player_sprt.flipX == true)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                //gameObject.transform.position = new Vector3(player_sprt.transform.position.x - skill_data.hit_box_pivot_x, player_sprt.transform.position.y + skill_data.hit_box_pivot_y, gameObject.transform.position.z);
            }
        }*/

        

        //animator.SetBool("sample_anim",true);

        //animation.clip = sample_animation;

        //alpha = 1 + (skill_data.skill_duration + skill_data.last_delay) / skill_data.skill_effect.length;


        //animator.speed = alpha;

        //gameObject.GetComponent<Animator>().GetComponent<AnimationState>().clip
        //animator.runtimeAnimatorController.animationClips[0] = sample_animation;
        

        //animator.Play("flash");

        Debug.Log("alpha : " + alpha);

    }
    //����Ʈ ������Ʈ �迭�θ��� �ּ�2���̻��� �����ؾߵɵ� ��ų������ ���� �ִϸ��̼� �������ϼ��� �־ �ּ�2���̻� ���� ����
    // Update is called once per frame
    void Update()
    {
        //�ִϸ��̼� ����� ������ ��Ȱ��ȭ �� �ʱ�ȭ �۾� �����ϰԲ� �ٲٱ�
        /*
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Debug.Log("animation end");
            gameObject.SetActive(false);
        }*/



        #if UNITY_EDITOR
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("none")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            gameObject.SetActive(false);
            
        }
        #endif

    }
}
