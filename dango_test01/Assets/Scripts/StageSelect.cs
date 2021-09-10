using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using UnityEngine.EventSystems;


public class StageSelect : MonoBehaviour
{
    void Awake()
    {
         /** 既にシーンが読み込まれているかどうか */
        if (!SceneController.AlreadyLoadScene("Common"))
        {
           SceneManager.LoadScene("Common", LoadSceneMode.Additive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerが初期値の場合
        if(GameManager.Instance.stage_st==0){
            GameManager.Instance.stage_st=1;
        }

        //debugモード
        if(GameManager.Instance.debug_mode){
            if(GameManager.Instance.clear_stage_st==0)
            GameManager.Instance.clear_stage_st=7;
        }else{

            if(GameManager.Instance.clear_stage_st==0)
            GameManager.Instance.clear_stage_st=1;
        
        }
        
    }

 
    // Update is called once per frame
    void Update()
    {
       
    }
}
