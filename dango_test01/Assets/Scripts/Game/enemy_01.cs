using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_01 : MonoBehaviour
{

    //外部スクリプトアクセス用
    private main_ctr  main_ctr;

    //コルーチンの待ち時間（Inspectorで指定）
    public float timeOut;

    //移動中
    private bool move_st;

    //ジャンプ中 
    private bool jump_st;
    
    //移動速度
    public float speed = 1.0f;
    
    //回転速度
    public float rot_speed = 0.1f;

    //private GameObject mouth;

    private Animator animator;

    //捕食中
    private bool eat_st;

    // 捕食エフェクト
    //public GameObject eat_effect;

    

    // Start is called before the first frame update
    void Start()
    {
        move_st=true;

        eat_st=false;

        animator = GetComponent<Animator>();

        //メインスクリプトアクセス用
        main_ctr = GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();

        //一定時間毎に処理
        StartCoroutine( FuncCoroutine() );
    }

    // Update is called once per frame
    void Update()
    {
        if(move_st){
            transform.position += transform.forward * speed * Time.deltaTime;
            //transform.Rotate(0, rot_speed, 0);

            // x軸を軸にして毎秒2度、回転させるQuaternionを作成（変数をrotとする）
            Quaternion rot = Quaternion.AngleAxis(rot_speed, Vector3.up);
            // 現在の自信の回転の情報を取得する。
            Quaternion q = this.transform.rotation;
            // 合成して、自身に設定
            this.transform.rotation = q * rot;
        }

        if(jump_st){

            transform.position += transform.forward * (speed*2) * Time.deltaTime;

        }else if(main_ctr.eat_area_st && !eat_st){
                eat_st=true;
                move_st=false;

                animator.Play("Attack");
                //Debug.Log("eat_area_cnt="+main_ctr.eat_area_cnt);

        }
        //Debug.Log("eat="+eat_st);
    }
    IEnumerator FuncCoroutine() {
        while(true){
            // Do anything
            
            /*if(main_ctr.eat_area_cnt>0){
                move_st=false;

                animator.Play("Attack");
                Debug.Log("eat_area_cnt="+main_ctr.eat_area_cnt);

            }else{
                int f=Random.Range(0,2);
                if(f==0){
                    move_st=true;
                    rot_speed=-rot_speed;
                    animator.Play("Walk");

                }else{
                    move_st=false;
                    animator.Play("Wait");
                }
            }*/

            if(!eat_st && !jump_st){
                int f=Random.Range(0,3);
                if(f==0){
                    move_st=true;
                    rot_speed=-rot_speed;
                    animator.Play("Walk");

                }else if(f==1){
                    move_st=false;
                    animator.Play("Wait");
                }else{
                    move_st=false;
                    jump_st=true;
                    animator.Play("Jump");
                }
            }
            
            
            yield return new WaitForSeconds(timeOut);
        }
    }

    public void EatEnd()
    {
        eat_st=false;
    }

    public void JumpEnd()
    {
        jump_st=false;
    }

    
}
