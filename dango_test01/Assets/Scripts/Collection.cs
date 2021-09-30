using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using UnityEngine.EventSystems;


public class Collection : MonoBehaviour
{
	DangoInfo dangoInfo = new DangoInfo();

	/// <summary>
	/// コレクション詳細ダイアログ
	/// </summary>
	[SerializeField]
	private CollectionDetailDialog detailDialog;

	/// <summary>
	/// アイコン一覧の親オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject listIconsParent;

	void Awake()
	{
			/** 既にシーンが読み込まれているかどうか */
			if (!SceneController.AlreadyLoadScene("Common"))
			{
				SceneManager.LoadScene("Common", LoadSceneMode.Additive);
			}
	}

	// Start is called before the first frame update
	void Start()
	{
		// ダンゴムシ情報作成
		this.dangoInfo.SetDangoList();

		// TODO：とりあえず、アイコン一覧プレハブの数分ループしてるけど、DangoListの数でループした方がいい気もする
		// アイコン一覧の表示設定
		CollectionListIcon[] icons = this.listIconsParent.GetComponentsInChildren<CollectionListIcon>();
		for (var i = 0 ; i < icons.Length; ++i){
			// 登録ダンゴムシ情報の数を超えたらループ終了
			if (this.dangoInfo.dangoList.Count <= i) break;

			// TODO：まだ取得してないダンゴムシの場合の処理

			// アイコン画像設定
			icons[i].SetData(this.dangoInfo.dangoList[i].SIconPath);
		}
	}


	// Update is called once per frame
	void Update()
	{
			if(Input.GetMouseButtonDown(0))
			{
					
			}
	}
}
