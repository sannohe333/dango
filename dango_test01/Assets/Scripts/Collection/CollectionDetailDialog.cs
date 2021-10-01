using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// コレクションシーンで表示される、詳細ダイアログ
/// </summary>
public class CollectionDetailDialog : MonoBehaviour
{
	/// <summary>
	/// コレクションアイテム名テキスト
	/// </summary>
	[SerializeField]
	private Text itemName;

	/// <summary>
	/// アイテム画像
	/// </summary>
	[SerializeField]
	private Image itemImg;

	/// <summary>
	/// アイテム情報テキスト
	/// </summary>
	[SerializeField]
	private Text infoText;

	/// <summary>
	/// ダイアログを閉じるボタン
	/// </summary>
	[SerializeField]
	private Button closeBtn;

	/// <summary>
	/// ランクアイコンが表示される親オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject rankIconParent;

	/// <summary>
	/// ランクアイコン配列
	/// </summary>
	private RankIcon[] rankIcons;

	/// <summary>
	/// ランク
	/// </summary>
	private int rank = 0;

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	public void SetData(string nameText,string infoText,string imgPath,int rankValue){
		//アイテム名テキスト
		this.itemName.text = nameText;
		//情報テキスト
		this.infoText.text = infoText;
		// 画像設定（例："Images/enemy/enemy000"）
		this.itemImg.sprite = Resources.Load<Sprite>(imgPath);
		this.rank = rankValue;

		// 閉じるボタンのイベント登録(前の登録分削除してから再登録)
		this.closeBtn.onClick.RemoveAllListeners();
		this.closeBtn.onClick.AddListener(this.ToggleActive);

		//ランクアイコンを配列に取得
		this.rankIcons = this.rankIconParent.GetComponentsInChildren<RankIcon>();
		this.SetRankIcon(this.rank);
		// ダイアログを表示
		this.ToggleActive();
	}

	/// <summary>
	/// ランクアイコンの表示設定
	/// </summary>
	/// <param name="rankValue">ランクをintで指定</param>
	private void SetRankIcon(int rankValue){
		
		for (int i = 0; this.rankIcons.Length > i; ++i)
		{
			bool isActive = rankValue > i;
			Debug.Log(i);
			this.rankIcons[i].SetActive(isActive);
		}
	}

	/// <summary>
	/// ダイアログの開閉
	/// </summary>
	public void ToggleActive()
	{
		// ダイアログが開いてたら閉じる
		if(this.gameObject.activeSelf){
			this.gameObject.SetActive(false);
		}
		// ダイアログがとじてたら開く
		else
		{
			this.gameObject.SetActive(true);
		}
	}
}
