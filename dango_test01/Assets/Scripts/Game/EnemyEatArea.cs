using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEatArea : MonoBehaviour
{
    //外部スクリプトアクセス用
    private main_ctr  main_ctr;

    // Start is called before the first frame update
    void Start()
    {
        //メインスクリプトアクセス用
        main_ctr=GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();
    }

    void OnTriggerStay(Collider other)
    {
        //ダンゴムシが捕食エリアに入っている場合
        if(other.gameObject.tag=="dango"){
            main_ctr.eat_area_st=true;
            //Debug.Log("入っている");
        }else{
            main_ctr.eat_area_st=false;
            //Debug.Log("いない");
        }
    }
}
