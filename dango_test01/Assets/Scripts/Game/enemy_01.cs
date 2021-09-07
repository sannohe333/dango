using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_01 : MonoBehaviour
{
    //コルーチンの待ち時間（Inspectorで指定）
    public float timeOut;
    private bool move_st; 
    public float speed = 1.0f;
    public float rot_speed = 0.1f;
    private GameObject mouth;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        move_st=true;

        animator = GetComponent<Animator>();

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
    }
    IEnumerator FuncCoroutine() {
        while(true){
            // Do anything
            
            int f=Random.Range(0,2);
            if(f==0){
                move_st=true;
                rot_speed=-rot_speed;
                animator.Play("Walk");

            }else{
                move_st=false;
                animator.Play("Wait");
            }
            
            yield return new WaitForSeconds(timeOut);
        }
    }
}
