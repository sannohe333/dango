using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pose_menu : MonoBehaviour
{
    public GameObject pose_menu_obj;

    //外部スクリプト参照
    private main_ctr  main_ctr;

    // Start is called before the first frame update
    void Start()
    {
        main_ctr=GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();
    }

    // つづけるボタンプッシュ
    public void Continue()
    {
        Time.timeScale = 1f;
        pose_menu_obj.SetActive(false);
    }

    // やり直すボタンプッシュ
    public void Retry()
    {
        Time.timeScale = 1f;
        pose_menu_obj.SetActive(false);
        main_ctr.retry_st=true;
    }

    // ステージセレクトボタンプッシュ
    public void StageSelect()
    {
        Time.timeScale = 1f;
        main_ctr.stageselect_st=true;
    }

    
}
