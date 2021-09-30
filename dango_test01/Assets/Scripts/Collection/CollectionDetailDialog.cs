using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コレクションシーンで表示される、詳細ダイアログ
/// </summary>
public class CollectionDetailDialog : MonoBehaviour
{
	/// <summary>
	/// コレクションアイテム名テキスト
	/// </summary>
	[SerializeField]
	private string itemName = "";

	/// <summary>
	/// アイテム画像
	/// </summary>
	[SerializeField]
	private Sprite itemImg;

	/// <summary>
	/// アイテム情報テキスト
	/// </summary>
	[SerializeField]
	private string infoText = "";

	/// <summary>
	/// ランク
	/// </summary>
	private int rank = 0;

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	public void SetData(string nameText,string infoText,string imgPath){
		//アイテム名テキスト
		this.itemName = nameText;
		//情報テキスト
		this.infoText = infoText;
		// 画像設定（例："Images/enemy/enemy000"）
		this.itemImg = Resources.Load<Sprite>(imgPath);
	}

}
