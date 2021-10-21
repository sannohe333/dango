using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	/// <summary>
	/// プレイするステージ
	/// </summary>
	[HideInInspector]
	public int stage_st;

	/// <summary>
	/// クリアーしたステージ
	/// </summary>
	[HideInInspector]
	public int clear_stage_st;

	/// <summary>
	/// 初オープンステージ
	/// </summary>
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
		// UNITYエディタで実行
#if UNITY_EDITOR
		if(Instance.debug_mode){
			stage_st = 0;
			clear_stage_st = 0;
			first_open = false;
		}
		else
		{
			// シーン読み込んだらjsonのユーザーデータをロードする
			this.LoadUserData();
		}
		// UNITYエディタ以外で実行
#else
#endif
	}

	/// <summary>
	/// アタッチされたビヘイビアを破棄すると、ゲームまたはシーンがOnDestroyを受け取ります。
	/// </summary>
	public void OnDestroy()
	{
		this.SaveUserData();
	}

	/// <summary>
	/// 読み込み時、ユーザー情報を読み込む
	/// </summary>
	private void LoadUserData()
	{
		// ユーザー情報をjsonから受け取る
		UserDataInfo _userDataInfo = new UserDataInfo();
		UserDataInfo.User _user = new UserDataInfo.User();
		_user = _userDataInfo.LoadUserData();
		// 自身に受け取り
		Instance.clear_stage_st = _user.clearStage;
		Instance.collectDangoIdList = _user.collectDangoIdList;
	}

	/// <summary>
	/// シーン終了時、ユーザー情報を保存する
	/// </summary>	
	private void SaveUserData()
	{
		// userData.jsonにセーブするコード。
		UserDataInfo _userDataInfo = new UserDataInfo();
		UserDataInfo.User _user = new UserDataInfo.User();
		_user.clearStage = GameManager.Instance.clear_stage_st;
		_user.collectDangoIdList = GameManager.Instance.collectDangoIdList;
		_userDataInfo.SaveUserData(_user);
	}

}