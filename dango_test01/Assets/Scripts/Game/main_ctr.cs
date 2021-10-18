using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_ctr : MonoBehaviour
{
	/// <summary>
	/// Scoreスクリプトアクセス用
	/// </summary>	
	private Score  Score;
	/// <summary>
	/// Timerスクリプトアクセス用
	/// </summary>	
	private timer  Timer;
	/// <summary>
	/// Guideスクリプトアクセス用
	/// </summary>	
	private Guide  Guide;

	/// <summary>
	/// カメラ位置調整用オブジェクト
	/// </summary>
	private GameObject cam_obj;

	//ダンゴムシプレハブ
	//public GameObject dango;

	/// <summary>
	/// ステージ別ダンゴムシの数リスト
	/// </summary>	
	public List<GameObject> DangoTypeList = new List<GameObject>();

	/// <summary>
	/// フェードエフェクトオブジェクト
	/// </summary>	
	public GameObject ui_fade;

	/// <summary>
	/// ポーズメニューオブジェクト
	/// </summary>	
	public GameObject pose_menu_obj;

	/// <summary>
	/// デンジャーパネルオブジェクト
	/// </summary>	
	public GameObject danger_panel;

	/// <summary>
	/// ガイド表示フラグ：表示中はtrue
	/// </summary>	
	[HideInInspector]
	public bool guide_st;

	/// <summary>
	/// ゲームプレイフラグ：ゲームプレイ中はtrue
	/// </summary>	
	[HideInInspector]
	public bool play_st;

	/// <summary>
	/// クリアーフラグ
	/// </summary>	
	[HideInInspector]
	public bool clear_st;

	/// <summary>
	/// ゲームオーバーフラグ
	/// </summary>	
	[HideInInspector]
	public bool gameover_st;

	/// <summary>
	/// リトライフラグ
	/// </summary>	
	[HideInInspector]
	public bool retry_st;

	/// <summary>
	/// ステージセレクトへ戻るフラグ
	/// </summary>	
	[HideInInspector]
	public bool stageselect_st;

　　//カメラ位置調整用
	private bool camset;
	private Vector3 cam_pos1;
	private Vector3 cam_pos2;

	//switchのstate
	private int state;

	/// <summary>
	/// 現在のステージナンバー
	/// </summary>	
	public int stage_num;

	/// <summary>
	/// ステージ別ダンゴムシの数リスト
	/// </summary>	
	public List<int> DangoCntList = new List<int>();

	/// <summary>
	/// ステージ別ダンゴムシのノルマリスト
	/// </summary>	
	public List<int> DangoNormList = new List<int>();

	/// <summary>
	/// ステージプレファブリスト
	/// </summary>	
	public List<GameObject> StageList = new List<GameObject>();

	/// <summary>
	/// ステージの親にするオブジェクト
	/// </summary>	
	public GameObject Stage;

	/// <summary>
	/// ステージナンバー表示
	/// </summary>	
	public Text StageNumText;

	/// <summary>
	/// ステージサイズ確認用
	/// </summary>	
	private int stage_size_st;

	//天敵のON/OFF
	//private bool enemy_st;

	/// <summary>
	/// ステージ別天敵リスト
	/// </summary>	
	public List<int> EnemyEntryList = new List<int>();

	/// <summary>
	/// 天敵プレファブリスト
	/// </summary>	
	public List<GameObject> EnemyList = new List<GameObject>();

	/// <summary>
	/// 天敵の捕食エリアに獲物が居る
	/// </summary>
	public bool eat_area_st;

	/// <summary>
	/// 捕食エフェクト
	/// </summary>	
	public GameObject eat_effect;

	/// <summary>
	/// レアゲットエフェクト
	/// </summary>	
	public GameObject rare_effect;

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
		//GameManagerが初期値の場合
		if(GameManager.Instance.stage_st==0){
			GameManager.Instance.stage_st=1;
		}

		if(GameManager.Instance.clear_stage_st==0){
			GameManager.Instance.clear_stage_st=1;
		}

		//ステージナンバー参照
		stage_num=GameManager.Instance.stage_st; 

			
		state=0;
		//stage_num=1;
		//enemy_st=false;
		camset=false;
		clear_st=false;
		retry_st=false;
		stageselect_st=false;
		gameover_st=false;
		eat_area_st=false;
		guide_st=false;
		play_st=false;

		//スコアスクリプトアクセス用
		Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();

		//タイマースクリプトアクセス用
		Timer=GameObject.Find("Canvas/timer").gameObject.GetComponent<timer>();

		//ガイドスクリプトアクセス用
		Guide=GameObject.Find("Canvas/guide_panel").gameObject.GetComponent<Guide>();

		//cameraオブジェクトを検索
		cam_obj=GameObject.Find("camera_pos").gameObject;

		//Debug.Log("ステージ数="+StageList.Count);
		//Debug.Log ("tes="+GameManager.Instance.tes);
	}

	// Update is called once per frame
	void Update()
	{
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
					this.stage_size_st = 0;
					cam_pos2=new Vector3( 0f, 34f, -5f );
					//シーンの影の強さ調整
					QualitySettings.shadowDistance=54f;
				}else if(GameObject.Find ("size_m")){
					this.stage_size_st = 1;
					cam_pos2=new Vector3( 0f, 46f, -8f );
					//シーンの影の強さ調整
					QualitySettings.shadowDistance=64f;
				}
				//ダンゴムシ読み込み
				for(int i=0; i < DangoCntList[stage_num-1]; i++){
					Invoke("dango_born", i*0.1f);
				}
				state=5;
			break;
			case 5:
				//天敵エントリー
				if(EnemyEntryList[stage_num-1]==1){    
					GameObject EnemyObject = Object.Instantiate(EnemyList[0]) as GameObject;
					EnemyObject.transform.SetParent(Stage.transform, false);
					EnemyObject.transform.Translate(0, 1, -5);
					danger_panel.SetActive(true);
				}
				state=6;
							
			break;
			case 6:
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
				//ガイド表示
				if(Guide.StageGuideList[stage_num-1]==1){
					guide_st=true;
					if(stage_num==1){
						Guide.GuidePlay(0);
					}else if(stage_num==2){
						Guide.GuidePlay(1);
					}else if(stage_num==4){
						Guide.GuidePlay(2);
					}else if(stage_num==7){
						Guide.GuidePlay(3);
					}else if(stage_num==8){
						Guide.GuidePlay(4);
					}
				}
				state=11;
			break;
			case 11:
				//ガイド表示中
				if(!guide_st){
					state=12;
				}
			break;
			case 12:
				//タイムカウントスタート
				Timer.timerActive=true;

				/*if(EnemyEntryList[stage_num-1]==1){
					danger_panel.SetActive(true);
				}*/
				play_st=true;
				/*if(EnemyEntryList[stage_num-1]==1){   
						GameObject.FindWithTag("enemy").GetComponent<enemy_01>().StartCoroutine( FuncCoroutine() );
				}*/
				state=30;
			break;
			case 30:
				//ゲームプレイ中
				if(clear_st){
					//Time.timeScale = 10f;
					ui_fade.GetComponent<Animator>().Play("fade_out");
					Timer.timerActive=false;
					/*if(stage_num==StageList.Count){
							//stage_num=1;
							GameManager.Instance.clear_stage_st=stage_num;

					}else{
							//stage_num++;
							GameManager.Instance.clear_stage_st=stage_num+1;
					}*/
					if(stage_num!=StageList.Count){
						if(GameManager.Instance.clear_stage_st==stage_num){
							GameManager.Instance.clear_stage_st=stage_num+1;
							GameManager.Instance.first_open=true;
						}
					}
					state=50;
				}
				if(gameover_st){
						//Time.timeScale = 10f;
						ui_fade.GetComponent<Animator>().Play("fade_out");
						Timer.timerActive=false;
						state=50;
				}
				if(retry_st||stageselect_st){
						state=51;
				}
			break;
			case 50:
				//リザルト
				if(Input.GetMouseButtonDown(0))
				{
					//リセット
					/*GameObject stage = GameObject.Find("stage").gameObject;
					GameObject stage_child = stage.transform.GetChild(0).gameObject;
					Destroy(stage_child);
					ui_fade.GetComponent<Animator>().Play("fade_def");
					clear_st=false;
					gameover_st=false;
					Score.ScoreReset(stage_num);
					Timer.seconds = 0f;
					Timer.timerText.text =Timer.seconds.ToString("F1")+"sec";*/
					state=51;
				}
			break;
			case 51:
				//リセット
				//GameObject stage = GameObject.Find("stage").gameObject;
				//GameObject stage_child = stage.transform.GetChild(0).gameObject;
				//Destroy(stage_child);
				
				//Stage以下の子を全削除
				foreach (Transform child in Stage.transform)
				{
					Destroy(child.gameObject);
				}
				
				ui_fade.GetComponent<Animator>().Play("fade_def");
				clear_st=false;
				gameover_st=false;
				Score.ScoreReset(stage_num);
				Timer.seconds = 0f;
				Timer.timerText.text =Timer.seconds.ToString("F1")+"sec";
				eat_area_st=false;
				guide_st=false;
				play_st=false;
				
				state=52;

			break;
			case 52:
				if(retry_st){
					//リトライの場合
					retry_st=false;
					state=0;
				}else{
					//ステージセレクトへ
					state=60;
				}
			break;
			case 60:
				if (SceneController.AlreadyLoadScene("StageSelect"))
				{
					SceneManager.UnloadSceneAsync("StageSelect");
				}
				if (SceneController.AlreadyLoadScene("Game"))
				{
					SceneManager.UnloadSceneAsync("Game");
				}
				SceneManager.LoadScene("StageSelect", LoadSceneMode.Additive);
							
			break;
			default:
			break;
		}
	}

	/// <summary>
	// ダンゴムシ生成メソッド
	/// </summary>
	private void dango_born(){
		// ダンゴムシ生成
		GameObject _dango;
		int _dangoType = Random.Range(0,4);
		_dango = Object.Instantiate(DangoTypeList[_dangoType]) as GameObject;

		// ダンゴムシにレアフラグを設定
		_dango.GetComponent<dango>().rare_state = _dangoType > 0; //dangoidが0のものだけfalse;

		// ステージサイズによってダンゴムシの表示位置を指定する
		if(this.stage_size_st == 0)
		{
			// ダンゴムシの表示位置
			_dango.transform.Translate(Random.Range(-4,4), 7, Random.Range(-4,4));
		}
		else if(this.stage_size_st == 1)
		{
			_dango.transform.Translate(Random.Range(-6,6), 7, Random.Range(-6,6));
		}

		// ダンゴムシの回転
		int _rotateType = Random.Range(0, 3);
		if (_rotateType == 0)
		{
			_dango.transform.Rotate(0, 90, 0);
		}
		else if (_rotateType == 1)
		{
			_dango.transform.Rotate(0, -90, 0);
		}
		else if (_rotateType == 2)
		{
			_dango.transform.Rotate(0, 180, 0);
		}

		_dango.transform.SetParent(Stage.transform, false);
	}

	public void EatEff()
	{
		GameObject copied;
		GameObject enemy;

		copied = Object.Instantiate(eat_effect) as GameObject;
		//enemy = GameObject.Find("stage/kaeru(Clone)").gameObject;
		enemy = GameObject.FindWithTag("enemy");
		
		copied.transform.SetParent(enemy.transform, false);
		copied.transform.Translate(Random.Range(-1f,2f), Random.Range(2f,3f), Random.Range(1f,3f));
	}

	public void RareGet()
	{
		GameObject copied;
		GameObject goal;

		copied = Object.Instantiate(rare_effect) as GameObject;
		goal = GameObject.FindWithTag("Goal");
		
		copied.transform.SetParent(goal.transform, false);
		copied.transform.Translate(Random.Range(-0.5f,1.5f), 6f, Random.Range(0.5f,-1f));
	}
}
