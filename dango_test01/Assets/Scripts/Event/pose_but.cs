using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pose_but : MonoBehaviour
{
    //外部スクリプトアクセス用
    private main_ctr  main_ctr;

    //poseボタン
    public GameObject pose_menu;

    // Start is called before the first frame update
    void Start()
    {
        main_ctr=GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();
    }

    public void PoseMenuOn()
    {
        if(!main_ctr.guide_st){
            pose_menu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
}
