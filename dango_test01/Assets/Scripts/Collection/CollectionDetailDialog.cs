using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

/// <summary>
/// コレクションシーンで表示される、詳細ダイアログ
/// </summary>
public class CollectionDetailDialog : MonoBehaviour
{
	/// <summary>
	/// 現在のダンゴモデルデータ
	/// </summary>
	PrevDangoModel currentModel;

	/// <summary>
	/// 全モデルの親オブジェクト
	/// </summary>
	[SerializeField]
	private Transform AllModelParent;

	/// <summary>
	/// ダンゴ3dプレハブが生成される親オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject normalModelParent;

	/// <summary>
	/// ダンゴ丸まり3dプレハブが生成される親オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject maruModelParent;

	/// <summary>
	/// モデルの投影画像
	/// </summary>
	[SerializeField]
	private CollectionDetailDialogModel ModelRawImage;

	/// <summary>
	/// コレクションアイテム名テキスト
	/// </summary>
	[SerializeField]
	private Text itemName;

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
	/// モデルの回転スピード
	/// </summary>
	[SerializeField]
	private Vector3 modelRotateSpeed = new Vector3(0.0f, 0.3f, 0.0f);

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	public void SetData(DangoInfo.Dango dangoinfo, PrevDangoModel model){
		// アイテム名テキスト
		this.itemName.text = dangoinfo.name;
		// 情報テキスト
		this.infoText.text = dangoinfo.infoText;
		// ランク値
		this.rank = dangoinfo.rank;

		// 閉じるボタンのイベント登録(前の登録分削除してから再登録)
		this.closeBtn.onClick.RemoveAllListeners();
		this.closeBtn.onClick.AddListener(this.ToggleActive);

		// 現在選択中のモデルデータ
		this.currentModel = model;

		// モデルデータを設定する
		this.Set3DModel(dangoinfo.id);

		// モデルを投影するrowimgの設定
		this.SetModelRawImage();

		//ランクアイコンを配列に取得
		this.rankIcons = this.rankIconParent.GetComponentsInChildren<RankIcon>();
		this.SetRankIcon(this.rank);

		// ダイアログを表示
		this.ToggleActive();
	}

	/// <summary>
	/// モデルを回転させる
	/// </summary>	
	public void RotateModel(){
		AllModelParent.Rotate(this.modelRotateSpeed, Space.Self);
	}

	/// <summary>
	/// 3dモデルを画像として投影しているRender Textureを持ったrawイメージの設定
	/// （クリックイベント渡してる）
	/// </summary>
	private void SetModelRawImage()
	{
		this.ModelRawImage.SetData(this.ClickModelToggle);
	}

	/// <summary>
	/// 3dモデルが投影されているrowimgをクリックしたときの処理
	/// </summary>	
	private async void ClickModel()
	{
		//　ノーマルモデルを非表示。丸まりモデルを表示
		this.normalModelParent.SetActive(false);
		this.maruModelParent.SetActive(true);

		//　x秒待機
		await Task.Delay(2000);

		//　ノーマルモデルを表示。丸まりモデルを非表示
		this.normalModelParent.SetActive(true);
		this.maruModelParent.SetActive(false);
	}

	/// <summary>
	/// ノーマルモデルがアクティブなら、ノーマルを非表示。丸まりを表示
	/// ノーマルモデルがディーセーブルなら、ノーマルを表示。丸まりを非表示
	/// </summary>
	private void ClickModelToggle(){
		bool isActive = this.normalModelParent.activeSelf;

		this.normalModelParent.SetActive(!isActive);
		this.maruModelParent.SetActive(isActive);

	}

	/// <summary>
	/// 3Dモデルを設定する
	/// </summary>
	/// <param name="dangoId">id</param>
	private void Set3DModel(int dangoId){
		// 古いモデルオブジェクトをまず削除
		this.DeleteChildren(this.normalModelParent.transform);
		this.DeleteChildren(this.maruModelParent.transform);

		// プレハブをシーンに生成
		var normalModelObj = Instantiate<GameObject>(this.currentModel.defoltModel);
		normalModelObj.transform.SetParent(this.normalModelParent.transform, false);
		this.normalModelParent.SetActive(true);//ダイアログを開いたときは表示しておく

		// 丸まりモデルプレハブをシーンに生成
		var maruModelObj = Instantiate<GameObject>(this.currentModel.marumariModel);
		maruModelObj.transform.SetParent(this.maruModelParent.transform, false);
		this.maruModelParent.SetActive(false);//ダイアログを開いたときは非表示にしておく
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
