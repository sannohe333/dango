using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	//プレイするステージ
	[HideInInspector]
	public int stage_st;

	//クリアーしたステージ
	[HideInInspector]
	public int clear_stage_st;

	//初オープンステージ
	[HideInInspector]
	public bool first_open;

	public bool debug_mode;

	/// <summary>
	/// コレクトしたダンゴキャラのIDを代入。
	/// ※このIDはDangoInfoクラスで設定されているDangoInfo.Dango.idの値を見ている
	/// （とりあえずテスト用で初期値入れてる）
	/// </summary>
	public List<int> collectDangoIdList = new List<int>{0,2};


	void Start()
	{
		// UNITYエディタ以外で実行
#if !UNITY_EDITOR
		stage_st=0;
		clear_stage_st=0;
		first_open=false;

		// UNITYエディタ以外で実行
# else
		// ユーザー情報をjsonから受け取る
		UserDataInfo _userDataInfo = new UserDataInfo();
		UserDataInfo.User _user = new UserDataInfo.User();
		_user = _userDataInfo.LoadUserData();
		GameManager.Instance.clear_stage_st = _user.clearStage;
		GameManager.Instance.collectDangoIdList = _user.collectDangoIdList;
#endif

	}

	void Update()
	{
		//Debug.Log("stage_st="+stage_st+" : clear_stage_st="+clear_stage_st);
	}

	/// <summary>
	/// アタッチされたビヘイビアを破棄すると、ゲームまたはシーンがOnDestroyを受け取ります。
	/// </summary>
	public void OnDestroy()
	{
		Debug.Log("デストロイ");
		// userData.jsonにセーブするコード。
		UserDataInfo _userDataInfo = new UserDataInfo();
		UserDataInfo.User _user = new UserDataInfo.User();
		_user.clearStage = GameManager.Instance.clear_stage_st;
		_user.collectDangoIdList = GameManager.Instance.collectDangoIdList;
		_userDataInfo.SaveUserData(_user);
	}

}