using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePanels : MonoBehaviour
{

    //ステージパネルリスト
    //public List<GameObject> StageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //アクティブなパネルを設定
        for(int i=0; i < GameManager.Instance.clear_stage_st; i++){

            /*transform.Find("stage_panel"+(i+1)+"/OFF").gameObject.SetActive(false);
            transform.Find("stage_panel"+(i+1)+"/ON").gameObject.SetActive(true);
            transform.Find("stage_panel"+(i+1)+"/Text").gameObject.SetActive(true);*/

            if(i==GameManager.Instance.clear_stage_st-1 && GameManager.Instance.first_open){
                transform.Find("stage_panel"+(i+1)).gameObject.GetComponent<Animator>().Play("stagepanel_open");
                GameManager.Instance.first_open=false;
            }else{
                transform.Find("stage_panel"+(i+1)).gameObject.GetComponent<Animator>().Play("stagepanel_active");
            }


            //Debug.Log(GameManager.Instance.clear_stage_st);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
