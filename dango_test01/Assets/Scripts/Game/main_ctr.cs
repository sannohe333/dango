using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_ctr : MonoBehaviour
{
    //タッチエフェクト用
    public GameObject prefab;

    //外部スクリプトアクセス用
    private Score  Score;
    private timer  Timer;

    //カメラ位置調整用
    private GameObject cam_obj;

    //ダンゴムシプレハブ
    public GameObject dango;

    //フェードエフェクト
    public GameObject ui_fade;

    //public int dango_cnt;

    //クリアーフラグ
    [HideInInspector]
    public bool clear_st;

    //ゲームオーバーフラグ
    [HideInInspector]
    public bool gameover_st;

　　//カメラ位置調整用
    private bool camset;
    private Vector3 cam_pos1;
    private Vector3 cam_pos2;

    //switchのstate
    private int state;

    //現在のステージナンバー
    public int stage_num;

    //ステージ別ダンゴムシの数リスト
    public List<int> DangoCntList = new List<int>();

    //ステージ別ダンゴムシのノルマリスト
    public List<int> DangoNormList = new List<int>();

    //ステージプレファブリスト
    public List<GameObject> StageList = new List<GameObject>();

    // ステージの親にするオブジェクト
    public GameObject Stage;

    // ステージナンバー表示
    public Text StageNumText;

    //ステージサイズ確認用
    private int stage_size_st;
    
    //天敵のON/OFF
    private bool enemy_st;

    //天敵プレファブリスト
    public List<GameObject> EnemyList = new List<GameObject>();

    void Awake()
    {
         /** 既にシーンが読み込まれているかどうか */
        if (!SceneController.AlreadyLoadScene("Common"))
        {
           SceneManager.LoadScene("Common", LoadSceneMode.Additive);
        }
    }

    //public float deleteTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        state=0;
        stage_num=1;
        enemy_st=false;
        camset=false;
        clear_st=false;
        gameover_st=false;

        //スコアスクリプトアクセス用
        Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();

        //タイマースクリプトアクセス用
        Timer=GameObject.Find("Canvas/timer").gameObject.GetComponent<timer>();

        //cameraオブジェクトを検索
        cam_obj=GameObject.Find("camera_pos").gameObject;

        //Debug.Log("ステージ数="+StageList.Count);

        //Debug.Log ("tes="+GameManager.Instance.tes);
        
    }

    // Update is called once per frame
    void Update()
    {
        //タッチエフェクト
        if(Input.GetMouseButtonDown(0))
        {
            //マウスカーソルの位置を取得。
            var mousePosition = Input.mousePosition;
            mousePosition.z = 5f;
             GameObject clone = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition),
                 Quaternion.identity);
            //Destroy(clone, deleteTime);

        }

        switch (state)
        {
            case 0:
                //カメラの初期位置
                cam_obj.transform.position=new Vector3( 0f, 10f, -3f );

                //ステージ読み込み
                GameObject StageObject = Object.Instantiate(StageList[stage_num-1]) as GameObject;
                StageObject.transform.SetParent(Stage.transform, false);

                StageNumText.text = "STAGE 0"+stage_num.ToString();


                //ステージサイズによるカメラの固定位置
                if(GameObject.Find ("size_s")){
                    stage_size_st=0;
                    cam_pos2=new Vector3( 0f, 34f, -5f );
                }else if(GameObject.Find ("size_m")){
                    stage_size_st=1;
                    cam_pos2=new Vector3( 0f, 60f, -10f );
                }
                //ダンゴムシ読み込み
                for(int i=0; i < DangoCntList[stage_num-1]; i++){
                    Invoke("dango_born", i*0.1f);
                }

                state=5;

                break;
            case 5:
                ui_fade.GetComponent<Animator>().Play("fade_in");

                if(!camset){
                    cam_obj.transform.position=new Vector3( 0,cam_obj.transform.position.y+(cam_pos2.y-cam_obj.transform.position.y)*0.015f, cam_obj.transform.position.z+(cam_pos2.z-cam_obj.transform.position.z)*0.015f );
                    cam_pos1=cam_obj.transform.position;

                    if(cam_pos2.y-cam_obj.transform.position.y<0.1f){
                        cam_obj.transform.position=cam_pos2;
                        
                        state=10;
                    }
                }
                
                break;
            case 10:
                //Debug.Log("カメラストップ！");
                
                state=11;
                break;
            case 11:
                //ダンゴムシ読み込み
                /*for(int i=0; i < dango_cnt; i++){
                    Invoke("dango_born", i*0.1f);
                }*/
                
                Timer.timerActive=true;

                state=15;
                
                break;
            case 15:
                //天敵読み込み
                if(enemy_st){
                //if(GameObject.Find ("size_s")){    
                    GameObject EnemyObject = Object.Instantiate(EnemyList[0]) as GameObject;
                    EnemyObject.transform.Translate(0, 1, 0);
                }
                
                state=30;
                break;
                
            case 30:    
                        
                if(clear_st){
                    //Time.timeScale = 10f;
                    ui_fade.GetComponent<Animator>().Play("fade_out");
                    Timer.timerActive=false;
                    if(stage_num==StageList.Count){
                        stage_num=1;
                    }else{
                        stage_num++;    
                    }
                    
                    state=50;
                }

                if(gameover_st){
                    //Time.timeScale = 10f;
                    ui_fade.GetComponent<Animator>().Play("fade_out");
                    Timer.timerActive=false;
                    state=50;
                }

                break;
            case 50:

                if(Input.GetMouseButtonDown(0))
                {
                   //リセット
                   GameObject stage = GameObject.Find("stage").gameObject;
                   GameObject stage_child = stage.transform.GetChild(0).gameObject;
                   Destroy(stage_child);
                   ui_fade.GetComponent<Animator>().Play("fade_def");
                   clear_st=false;
                   gameover_st=false;
                   Score.ScoreReset(stage_num);
                   Timer.seconds = 0f;
                   Timer.timerText.text =Timer.seconds.ToString("F1")+"sec";
                   state=0;

                }
                break;
            default:
                
                break;
        }


    }

    //ダンゴムシ生成メソッド
    void dango_born(){
        GameObject copied = Object.Instantiate(dango) as GameObject;

        if(stage_size_st==0){
            
            copied.transform.Translate(Random.Range(-4,4), 7, Random.Range(-4,4));
            int f=Random.Range(0,4);
            if(f==0){
                copied.transform.Rotate(0, 90, 0);
                
            }else if(f==1){
                copied.transform.Rotate(0, -90, 0);
                
            }else if(f==2){
                copied.transform.Rotate(0, 180, 0);
                
            }
        }else if(stage_size_st==1){
            
            copied.transform.Translate(Random.Range(-9,9), 7, Random.Range(-9,9));
            int f=Random.Range(0,4);
            if(f==0){
                copied.transform.Rotate(0, 90, 0);
                
            }else if(f==1){
                copied.transform.Rotate(0, -90, 0);
                
            }else if(f==2){
                copied.transform.Rotate(0, 180, 0);
                
            }

        }
        copied.transform.SetParent(Stage.transform, false);

    }

    
}
