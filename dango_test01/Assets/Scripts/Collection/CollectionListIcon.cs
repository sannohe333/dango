using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CollectionListIcon : MonoBehaviour
{
	/// <summary>
	/// アイコン画像オブジェクト
	/// </summary>
	[SerializeField]
	private CollectionListIconImg iconImg;
	/// <summary>
	/// アイコンをクリック出来なくするためのマスク
	/// </summary>
	[SerializeField]
	private GameObject mask;

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	/// <param name="SIconPath">sアイコン画像のパス</param>
	/// <param name="action">詳細ダイアログ表示用処理</param>
	public void SetData( DangoInfo.Dango dango, Action<DangoInfo.Dango> showDialog)
	{
		// まだコレクトしていない場合はマスク表示（マスク表示されてるときは画像クリックできない）
		var isActive = GameManager.Instance.collectDangoIdList.Contains(dango.id);
		this.mask.SetActive(!isActive);

		// アイコン画像の表示・クリック設定
		this.iconImg.SetData(dango, (DangoInfo.Dango dango) => { showDialog(dango); });
	}
}
