using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PrevDangoModel{
	/// <summary>
	/// ダンゴID
	/// </summary>
	public int id;
	/// <summary>
	/// 通常時のダンゴモデル
	/// </summary>	
	public GameObject defoltModel;
	/// <summary>
	/// 丸まり状態のモデル
	/// </summary>
	public GameObject marumariModel;
}

/// <summary>
/// コレクションシーンで表示される、詳細ダイアログ
/// </summary>
public class CollectionDetailDialog : MonoBehaviour
{
	/// <summary>
	/// ダンゴ3dプレハブ配列
	/// </summary>
	[SerializeField]
	private PrevDangoModel[] dangoModels;

	/// <summary>
	/// 現在のダンゴモデルデータ
	/// </summary>
	PrevDangoModel currentModel;

	/// <summary>
	/// ダンゴ3dプレハブが表示される親オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject normalModelParent;

	/// <summary>
	/// ダンゴ3dプレハブが表示される親オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject maruModelParent;


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
	public void SetData(int dangoId, string nameText,string infoText,string imgPath,int rankValue){
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

		this.currentModel = GetModelData(dangoId);

		//
		this.Set3DModel(dangoId);

		//ランクアイコンを配列に取得
		this.rankIcons = this.rankIconParent.GetComponentsInChildren<RankIcon>();
		this.SetRankIcon(this.rank);
		// ダイアログを表示
		this.ToggleActive();
		
	}

	/// <summary>
	/// 該当ダンゴのモデルを取り出し
	/// </summary>
	/// <param name="dangoId">id</param>
	private PrevDangoModel GetModelData(int dangoId){
		PrevDangoModel resModel = null;

		foreach (PrevDangoModel model in dangoModels){
			if(model.id != dangoId) continue;
			resModel = model;
		}

		return resModel;
	}

	/// <summary>
	/// 3Dモデルを設定する
	/// </summary>
	/// <param name="dangoId">id</param>
	private void Set3DModel(int dangoId){
		// 古いモデルオブジェクトをまず削除
		this.DeleteChildren(this.normalModelParent.transform);

		// プレハブをシーンに生成
		var model = Instantiate<GameObject>(this.currentModel.defoltModel);
		model.transform.SetParent(this.normalModelParent.transform, false);
	}

	/// <summary>
	/// 子要素を全削除
	/// </summary>
	/// <param name="parent">削除したい要素の親要素</param>
	private void DeleteChildren(Transform parent){
		foreach(Transform item in parent){
			GameObject.Destroy(item.gameObject);
		}
	}

	/// <summary>
	/// ランクアイコンの表示設定
	/// </summary>
	/// <param name="rankValue">ランクをintで指定</param>
	private void SetRankIcon(int rankValue){
		
		for (int i = 0; this.rankIcons.Length > i; ++i)
		{
			bool isActive = rankValue > i;
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
