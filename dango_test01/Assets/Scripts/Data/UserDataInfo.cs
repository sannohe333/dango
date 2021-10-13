using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserDataInfo
{
	/// <summary>
	/// クリアしたステージ数
	/// </summary>
	public int clearStage;

	/// <summary>
	/// コレクトしたダンゴキャラのID配列。
	/// ※このIDはDangoInfoクラスで設定されているDangoInfo.Dango.idの値を見ている
	/// </summary>
	public List<int> collectDangoIdList;


	/// <summary>
	/// userData.jsonを取得する
	/// </summary>
	/// <returns>userData.jsonを代入したUserDataInfoを返す</returns>
	public UserDataInfo LoadUserData(){
		//初めに保存先を計算する　Application.dataPathで今開いているUnityプロジェクトのAssetsフォルダ直下を指定して、後ろに保存名を書く
		var dataPath = Application.dataPath + "/Resources/Json/userData.json";
		StreamReader reader = new StreamReader(dataPath); //受け取ったパスのファイルを読み込む
		string dataStr = reader.ReadToEnd();//ファイルの中身をすべて読み込む
		reader.Close();//ファイルを閉じる

		return JsonUtility.FromJson< UserDataInfo > (dataStr);//読み込んだJSONファイルをPlayerData型に変換して返す
	}

	/// <summary>
	/// ユーザーデータをuserData.jsonに保存する
	/// </summary>
	/// <param name="user">保存するuserData</param>	
	public void SaveUserData(UserDataInfo user)
	{
		//初めに保存先を計算する　Application.dataPathで今開いているUnityプロジェクトのAssetsフォルダ直下を指定して、後ろに保存名を書く
		string dataPath = Application.dataPath + "/Resources/Json/userData.json";

		// userのプレイデータをjsonテキストに変換
		UserDataInfo _user = new UserDataInfo();
		_user.clearStage = user.clearStage;
		_user.collectDangoIdList = user.collectDangoIdList;

		// jsonファイルを保存
		string jsonStr = JsonUtility.ToJson(_user);//受け取ったPlayerDataをJSONに変換
		StreamWriter writer = new StreamWriter(dataPath, false);//初めに指定したデータの保存先を開く
		writer.WriteLine(jsonStr);//JSONデータを書き込み
		writer.Flush();//バッファをクリアする
		writer.Close();//ファイルをクローズする
	}
}
