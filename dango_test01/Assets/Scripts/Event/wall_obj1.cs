using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_obj1 : MonoBehaviour
{

    private GameObject wall_parent;
    private wall parentcs;

    // Start is called before the first frame update
    void Start()
    {
        wall_parent=transform.parent.gameObject ;
        parentcs=wall_parent.GetComponent<wall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //コライダーイベント（触れた時）
    void OnCollisionEnter(Collision collision)
	{
        
        //天敵に当たった時の処理
        if(collision.gameObject.tag=="enemy"){
            
            //親クラスのメソッドを実行
            //hit_cnt++;
            parentcs.change_col();
            //Debug.Log("あたり");
        }

        if(collision.gameObject.tag=="Wall"){
            
            //親クラスのメソッドを実行
            parentcs.not_down();
            Debug.Log("置けない");
        }

        //Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
   
		
	}

    //コライダーイベント（触れている間）
    void OnCollisionStay(Collision collision){
        //Debug.Log("触れてる");
        parentcs.col_state=true;
    }

    //コライダーイベント（離れた時）
    void OnCollisionExit(Collision collision){
        //Debug.Log("離れたー");
        parentcs.col_state=false;
    }

}
