using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_01 : MonoBehaviour
{

    //外部スクリプトアクセス用
    private main_ctr  main_ctr;

    private Sound  sound;

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

    //ダメージを受けた
    private bool damage_st;

    //ダメージカウント
    private int damage_cnt;

    //気絶中
    private bool faint_st;

    //マテリアル変更用
    private GameObject kaeru;
    public Material[] _material;
    private Renderer render;

    //ダメージ揺らし用
    private int i2;
    private bool col_st;
    private GameObject kaeru_bone;
    private Vector3 set_pos;

    // 捕食エフェクト
    //public GameObject eat_effect;

    

    // Start is called before the first frame update
    void Start()
    {
        move_st=true;

        eat_st=false;

        damage_st=false;

        damage_cnt=0;

        faint_st=false;

        animator = GetComponent<Animator>();

        //メインスクリプトアクセス用
        main_ctr = GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();

        //SEスクリプトアクセス用
        sound=GameObject.Find("se_object").gameObject.GetComponent<Sound>();

        //一定時間毎に処理
        StartCoroutine( FuncCoroutine() );

        //マテリアルアクセス用
        kaeru= transform.Find("Retopo_Mesh").gameObject;
        render = kaeru.GetComponent<Renderer>();

        render.material = _material[0];

        //Debug.Log("material="+render.sharedMaterials[0]);
        
        //ダメージ揺らし用
        i2=0;
        col_st=false;
        kaeru_bone = transform.Find("アーマチュア").gameObject;
        set_pos = kaeru_bone.transform.localPosition;

        //this.GetComponent<Renderer>().sharedMaterial = _material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(move_st && !faint_st){
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

            move_st=false;
            transform.position += transform.forward * (speed*2) * Time.deltaTime;

        }else if(main_ctr.eat_area_st && !eat_st　&& !faint_st){
                eat_st=true;
                move_st=false;

                int i=Random.Range(0,5);
                if(i==0){
                    animator.Play("Attack");
                }else{
                    animator.Play("Attack_2");
                }

                sound.audioSource.PlayOneShot(sound.sound5,0.2f);
                //Debug.Log("eat_area_cnt="+main_ctr.eat_area_cnt);

        }
        //Debug.Log("eat="+eat_st);

        //ダメージリアクション
        if(damage_st){
            kaeru_bone.transform.localPosition = new Vector3 (Mathf.PingPong(Time.time,0.05f), 0f, Mathf.PingPong(Time.time,set_pos.z+0.03f));
            
            i2++;

            if(i2 >= 15 ){
                i2 = 0;
                //Debug.Log("material=+"+render.material);
                if(!col_st){
                    col_st=true;
                    render.material = _material[1];
                }else{
                    col_st=false;
                    render.material = _material[0];
                }
            }
            
        }
    }

    void OnCollisionEnter(Collision collision)
	{
         if(collision.gameObject.tag=="dango" && !faint_st){
             float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;
            if(collisionForce>=1000){
                

                if(damage_cnt>=2){
                    animator.Play("Fall");
                    faint_st=true;
                    sound.audioSource.PlayOneShot(sound.sound6,0.8f);
                    sound.audioSource.PlayOneShot(sound.sound7,0.6f);
                    Invoke("GetUp", 5);//5秒後にリスタートメソッド実行
                }else{
                    render.material = _material[1];
                    damage_st=true;
                    damage_cnt++;

                    sound.audioSource.PlayOneShot(sound.sound6,0.8f);

                    Invoke("Damage", 0.5f);//0.5秒後にメソッド実行
                }

                //Debug.Log("衝突の強さ"+collisionForce);
            } 
         }

    }

    IEnumerator FuncCoroutine() {
        while(true){
            
            if(!eat_st && !jump_st && !faint_st){
                int i=Random.Range(0,3);
                if(i==0){
                    move_st=true;
                    rot_speed=-rot_speed;
                    animator.Play("Walk");

                }else if(i==1){
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

    //捕食アニメーション終了
    public void EatEnd()
    {
        eat_st=false;
    }

    //ジャンプアニメーション終了
    public void JumpEnd()
    {
        jump_st=false;
    }

    //ダメージリアクション終了
    public void Damage()
    {
        render.material = _material[0];
        damage_st=false;
        i2=0;
        col_st=false;
        kaeru_bone.transform.localPosition = set_pos;
    }

    //気絶終了
    void GetUp() {
        //faint_st=false;
        damage_cnt=0;
        animator.Play("GetUp");
    }

    //気絶終了2
    void GetUp2() {
        faint_st=false;
    }

    
}
