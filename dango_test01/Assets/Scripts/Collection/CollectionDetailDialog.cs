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
	/// ランク
	/// </summary>
	private int rank = 0;

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	public void SetData(string nameText,string infoText,string imgPath){
		//アイテム名テキスト
		this.itemName.text = nameText;
		//情報テキスト
		this.infoText.text = infoText;
		// 画像設定（例："Images/enemy/enemy000"）
		this.itemImg.sprite = Resources.Load<Sprite>(imgPath);

		// ダイアログを表示
		this.ActiveDialog();
	}

	/// <summary>
	/// ダイアログの開閉
	/// </summary>
	public void ActiveDialog()
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
