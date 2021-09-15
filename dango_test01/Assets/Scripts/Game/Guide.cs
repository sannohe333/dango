using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{

    //外部スクリプトアクセス用
    private main_ctr  main_ctr;

    //ステージガイド有無リスト
    public List<int> StageGuideList = new List<int>();

    // ガイドパネル
    private GameObject guide_panel;

    // ガイドパネルアニメーション
    private Animator guide_anime;

    //ページナンバー
    private int page_num;

    // 操作ボタン
    public GameObject guide_but_next,guide_but_prev,guide_but_play;

    [SerializeField]
    private List<Transform> targetParentList = new List<Transform>();
    //private Transform targetParents1;
    private List<GameObject> pages = new List<GameObject>();

    // Start is called before the first frame update
    public void Start()
    {
        //メインスクリプトアクセス用
        main_ctr=GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();

        page_num=0;

        guide_panel=GameObject.Find("Canvas/guide_panel").gameObject;
        guide_anime=guide_panel.GetComponent<Animator>();

        Debug.Log("pages.Count="+pages.Count+ ": page_num="+page_num);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuidePlay(int i){
        Transform targetParents=targetParentList[i];
        
        targetParents.gameObject.SetActive(true);

        foreach (Transform child in targetParents)
        {
            this.pages.Add(child.gameObject);
            
            child.gameObject.SetActive(false); 
        }
        
        pages[page_num].SetActive(true);
        if(pages.Count>1){
            guide_but_next.SetActive(true);
            guide_but_prev.SetActive(false);
            guide_but_play.SetActive(false);
        }else{
            guide_but_next.SetActive(false);
            guide_but_prev.SetActive(false);
            guide_but_play.SetActive(true);
        }
        guide_anime.Play("guide_in");
        
    }

    public void GuideButEvent_next(){
        
        //Debug.Log("pages.Count="+pages.Count+ ": page_num="+page_num);
            if(pages.Count-2!=page_num){
                pages[page_num].SetActive(false);
                page_num++;
                pages[page_num].SetActive(true);
                //guide_but_next.SetActive(true);
                guide_but_prev.SetActive(true);
                guide_but_play.SetActive(false);
            }else{
                pages[page_num].SetActive(false);
                page_num++;
                pages[page_num].SetActive(true);
                guide_but_next.SetActive(false);
                guide_but_prev.SetActive(true);
                guide_but_play.SetActive(true);
            }
    }

    public void GuideButEvent_prev(){
        
        //Debug.Log("pages.Count="+pages.Count+ ": page_num="+page_num);
            if(page_num>=2){
                pages[page_num].SetActive(false);
                page_num--;
                pages[page_num].SetActive(true);
                guide_but_next.SetActive(true);
                guide_but_prev.SetActive(true);
                guide_but_play.SetActive(false);
            }else{
                pages[page_num].SetActive(false);
                page_num--;
                pages[page_num].SetActive(true);
                guide_but_next.SetActive(true);
                guide_but_prev.SetActive(false);
                guide_but_play.SetActive(false);
            }     
    }

    public void GuideButEvent_play(){
        pages[page_num].SetActive(false);
        guide_but_next.SetActive(false);
        guide_but_prev.SetActive(false);
        guide_but_play.SetActive(false);
        pages.Clear();
        page_num=0;
        guide_anime.Play("guide_out");
        Time.timeScale = 1f;
        main_ctr.guide_st=false;
    }

    void TimeStop(){
        main_ctr.guide_st=true;
        Time.timeScale = 0f;
    }
}
