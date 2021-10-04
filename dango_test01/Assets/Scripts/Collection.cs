using UnityEngine;
using UnityEngine.SceneManagement;

public class Collection : MonoBehaviour
{
	DangoInfo dangoInfo = new DangoInfo();

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
		for (var i = 0; dangoInfo.dangoList.Count > i; ++i)
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

	/// <summary>
	/// ダンゴ詳細ダイアログ表示（アイコンクリック時のコールバック処理）
	/// </summary>
	/// <param name="dango"></param>
	private void ShowDetailDialog(DangoInfo.Dango dango){
		// ダイアログの表示設定
		this.detailDialog.SetData(dango.name,dango.infoText,dango.LIconPath,dango.rank);
	}
}
