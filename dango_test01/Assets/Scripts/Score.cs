using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //外部スクリプト参照
    private main_ctr  main_ctr;

    public Text scoreText;
    public Text scoreText2;
    public GameObject clear_logo;
    public GameObject gameover_logo;

    //各ステージのノルマ数リスト
    //public List<int> normList = new List<int>();
    
    // スコア
    //private static int score;
    //private static int norm_score;
    private int score;
    private int norm_score;

    private int delete_cnt;

    // Start is called before the first frame update
    void Start()
    {
        main_ctr=GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();
        score = 0;
        norm_score = main_ctr.DangoNormList[0];
        scoreText2.text = main_ctr.DangoNormList[0].ToString();
        clear_logo.SetActive(false);
        gameover_logo.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = score.ToString ();

        if(!main_ctr.clear_st && score == norm_score){
            main_ctr.clear_st=true;
            if(!clear_logo.activeSelf){
                clear_logo.SetActive(true);
            }
        }

        if(!main_ctr.clear_st && delete_cnt == main_ctr.DangoCntList[main_ctr.stage_num-1]){
            main_ctr.gameover_st=true;
            if(!gameover_logo.activeSelf){
                gameover_logo.SetActive(true);
            }
        }
        //Debug.Log("ポイント:"+norm_score);

        
    }
 
    // ポイントの追加
    public void AddPoint (int point)
    {
        score = score + point;
        scoreText.text = score.ToString ();
        delete_cnt++;
        
        //Debug.Log("delete:"+delete_cnt+" :dango_cnt : "+main_ctr.dango_cnt);
    }

    // ポイントの追加
    public void deleteCnt()
    {
        delete_cnt++;

        //ノルマが達成できないとき
        if(delete_cnt>(main_ctr.DangoCntList[main_ctr.stage_num-1]-main_ctr.DangoNormList[main_ctr.stage_num-1])+score){
            main_ctr.gameover_st=true;
            if(!gameover_logo.activeSelf){
                gameover_logo.SetActive(true);
            }
        }
        //Debug.Log("delete:"+delete_cnt+" :dango_cnt : "+main_ctr.dango_cnt);
    }

    // スコアリセット
    public void ScoreReset (int stage)
    {
        score = 0;
        delete_cnt = 0;
        scoreText.text = score.ToString ();
        norm_score = main_ctr.DangoNormList[stage-1];
        scoreText2.text = main_ctr.DangoNormList[stage-1].ToString();
        clear_logo.SetActive(false);
        gameover_logo.SetActive(false);
        
        //Debug.Log("ステージ:"+normList[stage]);
    }
}
