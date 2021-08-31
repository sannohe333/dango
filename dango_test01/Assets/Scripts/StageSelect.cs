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

        if(GameManager.Instance.clear_stage_st==0){
            GameManager.Instance.clear_stage_st=1;
        }
    }

 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            /** 既にシーンが読み込まれているかどうか */
           
            /*if (SceneController.AlreadyLoadScene("StageSelect"))
            {
                SceneManager.UnloadSceneAsync("StageSelect");
            }
            
            SceneManager.LoadScene("Game", LoadSceneMode.Additive);*/

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
        
                if (Physics.Raycast(ray, out hit)){
                    //Rayがcolにヒットした場合
                    //if (hit.collider == col){
                        Debug.Log("hit!");
                    //}
                    
                }
        }
    }
}
