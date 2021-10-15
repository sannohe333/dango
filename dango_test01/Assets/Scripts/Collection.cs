using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct PrevDangoModel
{
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

public class Collection : MonoBehaviour
{
	DangoInfo dangoInfo = new DangoInfo();

	/// <summary>
	/// ダンゴ3dプレハブ配列
	/// </summary>
	[SerializeField]
	private PrevDangoModel[] dangoModels;

	/// <summary>
	/// コレクション詳細ダイアログ
	/// </summary>
	[SerializeField]
	private CollectionDetailDialog detailDialog;

	/// <summary>
	/// 一覧に表示するアイコン画像
	/// </summary>
	[SerializeField]
	private GameObject dangoIconPanel;

	/// <summary>
	/// 一覧に表示するアイコン画像の親
	/// </summary>
	[SerializeField]
	private GameObject dangoIconPanelParent;

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

		// ダンゴムシ情報を回して、シーンに一覧アイコンを表示する
		for (var i = 0; this.dangoInfo.dangoList.Count > i; ++i)
		{
			// プレハブをシーンに生成
			var iconPanel = Instantiate<GameObject>(this.dangoIconPanel);
			iconPanel.transform.SetParent(this.dangoIconPanelParent.transform, false);

			// アイコン画像設定
			CollectionListIcon icon = iconPanel.GetComponent<CollectionListIcon>();
			icon.SetData(this.dangoInfo.dangoList[i], (DangoInfo.Dango dango) =>
			{
				//　ダンゴ詳細ダイアログ設定
				this.ShowDetailDialog(dango);
			});
		}
	}

	public void Update(){
		// 詳細ダイアログのモデルを回転(詳細ダイアログがアクティブの時だけ実行)
		if(this.detailDialog.gameObject.activeSelf){
			this.detailDialog.RotateModel();
		}
	}

	/// <summary>
	/// アタッチされたビヘイビアを破棄すると、ゲームまたはシーンがOnDestroyを受け取ります。
	/// </summary>
	public void OnDestroy(){
		/*　メモ：userData.jsonにセーブするコード。
		UserDataInfo userData = new UserDataInfo();
		userData.clearStage = GameManager.Instance.clear_stage_st;
		userData.collectDangoIdList = GameManager.Instance.collectDangoIdList;
		userData.SaveUserData(userData);
		*/
	}

	/// <summary>
	/// ダンゴ詳細ダイアログ表示（アイコンクリック時のコールバック処理）
	/// </summary>
	/// <param name="dango"></param>
	private void ShowDetailDialog(DangoInfo.Dango dango){
		PrevDangoModel model = this.GetModelData(dango.id);
		// ダイアログの表示設定
		this.detailDialog.SetData(dango, model);
	}

	/// <summary>
	/// 該当ダンゴのモデルを取り出し
	/// </summary>
	/// <param name="dangoId">id</param>
	private PrevDangoModel GetModelData(int dangoId)
	{
		PrevDangoModel resModel;
		resModel.id = 0;
		resModel.marumariModel = null;
		resModel.defoltModel = null;

		foreach (PrevDangoModel model in this.dangoModels)
		{
			if (model.id != dangoId) continue;
			resModel = model;
			break;
		}

		return resModel;
	}
}
