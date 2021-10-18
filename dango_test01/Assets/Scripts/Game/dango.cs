using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dango : MonoBehaviour
{
	/// <summary>
	/// ダンゴキャラのid（DangoInfoで定義されているid）
	/// </summary>
	public int dangoId;

	//外部スクリプトアクセス用
	private Score  Score;
	private main_ctr  main_ctr;
	private Sound  sound;

	//コルーチンの待ち時間（Inspectorで指定）
	public float timeOut;

	//衝突カウント
	private int collision_cnt;

	private float pos_x;
	private float pos_z;
	public float speed = 2f;
	public float roll;

	/// <summary>
	/// 移動中
	/// </summary>
	private bool move_st;

	/// <summary>
	/// ゲームスタート時
	/// </summary>
	private bool start_st;

	/// <summary>
	/// 落下判定
	/// </summary>
	private bool fall_st;

	/// <summary>
	/// 食べられた
	/// </summary>
	private bool eat_destroy;

	/// <summary>
	/// レア
	/// </summary>
	public bool rare_state;

	//捕食エリアに入っている時
	//private bool danger_st;

	//リジッドボディ
	public Rigidbody rb;
　　
	//各種コライダー（通常時/丸まり時）
	private BoxCollider col1;
	private SphereCollider col2;

	//トレイル
	private TrailRenderer tr;

	private GameObject dango_def;
	private GameObject dango_maru;
	private GameObject dango_goal;
	private GameObject dango_dead;
	private GameObject delete_eff;
	//private GameObject dead_eff;

	//private GameObject goal_txt;

	private GameObject enemy;
	private GameObject Arrow_L;
	private GameObject Arrow_R;

	// Start is called before the first frame update
	void Start()
	{
		start_st=false;
		//move_st=true;

		fall_st=false;

		eat_destroy=false;

		collision_cnt=0;

		//スコアスクリプトアクセス用
		Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();

		//メインスクリプトアクセス用
		main_ctr=GameObject.Find("ctr_obj").gameObject.GetComponent<main_ctr>();

		//SEスクリプトアクセス用
		sound=GameObject.Find("se_object").gameObject.GetComponent<Sound>();

		

		//子オブジェクトを検索
		dango_def=transform.Find("dango_def").gameObject;
		dango_def.SetActive(false);
		
		dango_maru=transform.Find("dango_maru").gameObject;
		dango_maru.SetActive(true);
		
		dango_goal=transform.Find("dango_goal").gameObject;
		dango_goal.SetActive(false);

		dango_dead=transform.Find("dango_dead").gameObject;
		dango_dead.SetActive(false);

		delete_eff=transform.Find("delete_effect").gameObject;
		delete_eff.SetActive(false);

		//dead_eff=transform.Find("death_eff").gameObject;
		//dead_eff.SetActive(false);

		//enemy=GameObject.Find("enemy").gameObject;
		
		//リジットボディを取得
		rb = GetComponent<Rigidbody>();
		//rb.AddForce(new Vector3(0f, 0f, 0f), ForceMode.Impulse);

		//コライダ１（ボックス）を取得
		col1= GetComponent<BoxCollider>();
		col1.enabled = false;

		//コライダ２（球体）を取得
		col2= GetComponent<SphereCollider>();
		col2.enabled = true;

		tr=dango_maru.GetComponent<TrailRenderer>();
		tr.enabled = false;
		
		//矢印オブジェクト（左）を取得
		Arrow_L=transform.Find("arrow_l").gameObject;
		Arrow_L.SetActive(false);

		//矢印オブジェクト（右）を取得
		Arrow_R=transform.Find("arrow_r").gameObject;
		Arrow_R.SetActive(false);

		//一定時間毎に処理
		StartCoroutine( FuncCoroutine() );

		float forceAngle = 90f;
		float rad = forceAngle * Mathf.Deg2Rad;
			//Debug.Log("Cos="+Mathf.Cos(rad)+": Tan="+Mathf.Tan(rad));
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log("速度="+rb.velocity);
		/*if(!start_st){
				transform.position += transform.forward * 0.2f * Time.deltaTime;
		}*/

		if(move_st){
			transform.position += transform.forward * speed * Time.deltaTime;
		}
			
		//台から落下判定
		if(!fall_st){
			if(transform.position.y<=0.2f){
				sound.audioSource.PlayOneShot(sound.sound3,0.01f);

				Arrow_L.SetActive(false);
				Arrow_R.SetActive(false);

				//回転の制限を解除（Constraints制御）
				rb.constraints = RigidbodyConstraints.None ;
				tr.enabled = false;
				fall_st=true;
			}
		}else{
			//float f=2f;
			transform.Rotate(4f, 0f, 0f);
			transform.Translate (0, -0.1f, 0, Space.World);
		}

		//台から落ちたダンゴムシは削除
		if(transform.position.y<=-30){
			Score.deleteCnt();
			Destroy(gameObject);
		}

		//クリアー時やゲームオーバー時に残ったダンゴムシは削除
		if(main_ctr.clear_st || main_ctr.gameover_st){
			Destroy(gameObject);
		}

		//回転補正
		//回転座標をy軸の回転のみに限定
		if(!fall_st){
			transform.rotation = Quaternion.Euler(new Vector3( 0f, transform.eulerAngles.y, 0f ));
		}

		//食べられた時
		if(eat_destroy){
			transform.position += (enemy.transform.position-transform.position)/30;
			if(Vector3.Distance(transform.position, enemy.transform.position)<2 || transform.position.y<=-1){
				main_ctr.EatEff();
				Destroy(gameObject);
			}
			//Debug.Log("Distance="+Vector3.Distance(transform.position, enemy.transform.position));
		}
			
	}

		//コライダーイベント
		void OnCollisionEnter(Collision collision)
	{
		//スタート時に地面に触れた時に、丸まり解除
		if(!start_st && collision.gameObject.tag=="ground"){
			col1.enabled = true;
			col2.enabled = false;
			start_st=true;
			move_st=true;
			//tr=dango_maru.GetComponent<TrailRenderer>();
			tr.enabled = true;
			restart();
		}

		if(collision.gameObject.tag=="Wall"||collision.gameObject.tag=="dango"||collision.gameObject.tag=="enemy"){
			//障害物に触れると方向転換
			transform.Rotate(0, roll, 0);

			//回転方向を逆転
			roll=-roll;

			//矢印表示変更
			if(start_st){
				Arrow_L=transform.Find("arrow_l").gameObject;
				Arrow_R=transform.Find("arrow_r").gameObject;
				if(Arrow_L.activeSelf){
					Arrow_L.SetActive(false);
					Arrow_R.SetActive(true);
				}else if(Arrow_R.activeSelf){
					Arrow_L.SetActive(true);
					Arrow_R.SetActive(false);
				}
			}else{
				//スタート時に壁の上に乗りっぱなしの時があるため回避策
				rb = GetComponent<Rigidbody>();
				rb.AddForce(new Vector3(0.5f, 0f, 0.5f), ForceMode.Impulse);
			}
				

			//ぶつかったカウント（ハマり回避用）
			collision_cnt++;

			//衝突の強さを取得
			/*if(collision.gameObject.tag=="enemy"){
					float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;
					if(collisionForce>=1000){
							Debug.Log("衝突の強さ"+collisionForce);
					} 
			}*/
		}

		//ゴールに着いた時の処理
		if(collision.gameObject.tag=="Goal"){
			//goal_txt.SetActive(true);
			move_st=false;
			dango_def.SetActive(false);
			dango_maru.SetActive(false);
			dango_goal.SetActive(true);
			Arrow_L.SetActive(false);
			Arrow_R.SetActive(false);
			col1.enabled = false;
			col2.enabled = false;
			rb.useGravity = false;
			delete_eff.SetActive(true);

			if(rare_state){
				main_ctr.RareGet();
			}
			
			sound.audioSource.PlayOneShot(sound.sound4,0.3f);
			/*if(danger_st){
					main_ctr.eat_area_cnt-=1;
			}*/
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//天敵に食べられた時の処理
		if(other.gameObject.tag=="mouth"){
			//main_ctr.EatEff();
			Score.deleteCnt();
			//Destroy(gameObject);
			col1.enabled = false;
			col2.enabled = false;
			rb.useGravity = false;
			enemy = GameObject.FindWithTag("enemy");
			eat_destroy=true;
			//Debug.Log("enemy="+enemy);
		}

		//捕食エリアに入った時の処理
		/*if(other.gameObject.tag=="EatArea"){
				Debug.Log("入った");
		}*/
	}

	void OnTriggerExit(Collider other)
	{
		//main_ctr.eat_area_cnt-=1;
		//Debug.Log("出た");
	}

	/// <summary>
	/// ダンゴムシがはじかれる方向を返す(加藤さん作成)
	/// </summary>
	/// <param name="tapPos">タップした位置</param>
	/// <param name="power">移動スピード</param>
	/// <returns></returns>
	private Vector3 GetJumpDirection(Vector3 tapPos, int power){
		Vector3 resDirection;

		// ダンゴムシの場所
		Vector3 targetPos = transform.position;

				//ダンゴムシの位置からタッブした位置を引く（ベクトル確定）
		Vector3 junpVector = targetPos - tapPos;

				//Vector3.Scaleで２つの成分を乗算し、強さを設定
		resDirection = Vector3.Scale(junpVector, new Vector3(1 * power, 0, 1 * power));//上下の回転を排除
		//タップの位置と反対向きのベクトル
		return resDirection;
	}

	/// <summary>
	/// ダンゴムシをタップした時の処理
	/// </summary>
	public void onClickAct() {
		if(!main_ctr.guide_st){
			if(!move_st){
				//カメラとの中間座標
				var distance = Vector3.Distance(transform.position, Camera.main.transform.position);
				//クリックした座標(2D)
				var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
				//3D空間でクリックした位置
				Vector3 currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
				//天敵の方を向く
				//transform.LookAt(enemy.transform.position);

				// タップ位置とダンゴ虫の反対方向に移動する(加藤さん作成)
				rb.AddForce(this.GetJumpDirection(currentPosition, 5500));
				sound.audioSource.PlayOneShot(sound.sound2,0.05f);
			}else{
				//クリックするとダンゴムシが丸まって移動停止
				move_st=false;

				sound.audioSource.PlayOneShot(sound.sound1,0.1f);

				dango_def.SetActive(false);
				dango_maru.SetActive(true);
				Arrow_L.SetActive(false);
				Arrow_R.SetActive(false);

				//回転の制限を解除（Constraints制御）
				rb.constraints = RigidbodyConstraints.None ;

				//球形コライダをON
				col1.enabled = false;
				col2.enabled = true;

				Invoke("restart", 2);//2秒後にリスタートメソッド実行
			}
		}
			//Debug.Log("タッチ");
	}

	void restart() {
		//ダンゴムシ丸まり後再始動
		move_st=true;
		
		dango_def.SetActive(true);
		dango_maru.SetActive(false);

		//ボックスコライダをON
		col1.enabled = true;
		col2.enabled = false;

		int f=Random.Range(0,2);
		if(!fall_st){
			if(f==0){
			Arrow_L.SetActive(true);
			Arrow_R.SetActive(false);
			roll = -90f;

			}else{
				Arrow_L.SetActive(false);
				Arrow_R.SetActive(true);
				roll = 90f;

			}
		}else{
			Arrow_L.SetActive(false);
			Arrow_R.SetActive(false);
		}

			//transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);

			//回転軸制限（X軸とZ軸は固定）
			rb.constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;
		}

	IEnumerator FuncCoroutine() {
		while(true){
			// Do anything
			
			//角で詰まった時の処理
			if(collision_cnt>=5){
				int f=Random.Range(0,2);
				if(f==0){
					Arrow_L.SetActive(true);
					Arrow_R.SetActive(false);
					roll = -90f;
				}else{
					Arrow_L.SetActive(false);
					Arrow_R.SetActive(true);
					roll = 90f;
				}
			}
			collision_cnt=0;

			//壁で詰まった時の処理
			if(move_st && transform.position.x+1>=pos_x && transform.position.x-1<=pos_x && transform.position.z+1>=pos_z && transform.position.z-1<=pos_z){
				transform.Rotate(0, 180, 0);
			}
			
			pos_x=transform.position.x;
			pos_z=transform.position.z;

			//指定間隔ごとに再処理(timeOut秒)
			yield return new WaitForSeconds(timeOut);
		}
	}
}
