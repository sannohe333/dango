using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class but_event : MonoBehaviour
{

    public void ScnChange()
    {
        /** 既にシーンが読み込まれているかどうか */
           if (SceneController.AlreadyLoadScene("StageSelect"))
            {
                SceneManager.UnloadSceneAsync("StageSelect");
            }

            if (SceneController.AlreadyLoadScene("Collection"))
            {
                SceneManager.UnloadSceneAsync("Collection");
            }

            if (SceneController.AlreadyLoadScene("Title"))
            {
                SceneManager.UnloadSceneAsync("Title");
            }
                 

           if(transform.parent.gameObject.name=="title"){
                //タイトルへボタン
                SceneManager.LoadScene("title", LoadSceneMode.Additive);
            }else if(transform.parent.gameObject.name=="game"){
                //ゲームスタートボタン
                SceneManager.LoadScene("StageSelect", LoadSceneMode.Additive);
            }else if(transform.parent.gameObject.name=="collection"){
                //コレクションボタン
                SceneManager.LoadScene("Collection", LoadSceneMode.Additive);
            }else {
                //各ステージボタン
                if(transform.parent.gameObject.name=="stage_panel1"){
                    GameManager.Instance.stage_st=1;
                }else if(transform.parent.gameObject.name=="stage_panel2"){
                    GameManager.Instance.stage_st=2;   
                }else if(transform.parent.gameObject.name=="stage_panel3"){
                    GameManager.Instance.stage_st=3;
                }else if(transform.parent.gameObject.name=="stage_panel4"){
                    GameManager.Instance.stage_st=4;
                }else if(transform.parent.gameObject.name=="stage_panel5"){
                    GameManager.Instance.stage_st=5;
                }else if(transform.parent.gameObject.name=="stage_panel6"){
                    GameManager.Instance.stage_st=6;
                }else if(transform.parent.gameObject.name=="stage_panel7"){
                    GameManager.Instance.stage_st=7;
                }else if(transform.parent.gameObject.name=="stage_panel8"){
                    GameManager.Instance.stage_st=8;
                }else if(transform.parent.gameObject.name=="stage_panel9"){
                    GameManager.Instance.stage_st=9;
                }else if(transform.parent.gameObject.name=="stage_panel10"){
                    GameManager.Instance.stage_st=10;
                }else if(transform.parent.gameObject.name=="stage_panel11"){
                    GameManager.Instance.stage_st=11;
                }else if(transform.parent.gameObject.name=="stage_panel12"){
                    GameManager.Instance.stage_st=12;
                }

                SceneManager.LoadScene("Game", LoadSceneMode.Additive);
            }
            //Debug.Log(transform.parent.gameObject.name);
            //Debug.Log("stage"+GameManager.Instance.stage_st);
    }
}
