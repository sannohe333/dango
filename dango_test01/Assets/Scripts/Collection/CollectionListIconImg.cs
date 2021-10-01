using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CollectionListIconImg : MonoBehaviour,IPointerClickHandler
{
	DangoInfo.Dango dangoData;
	/// <summary>
	/// アイコンクリック時のダイアログ表示用コールバック処理
	/// </summary>
	private Action<DangoInfo.Dango> showDetailDiaog;

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	public void SetData( DangoInfo.Dango dango, Action<DangoInfo.Dango> showDialog)
	{
		this.dangoData = dango;
		this.showDetailDiaog = showDialog;

		// 画像設定（例："Images/enemy/enemy000"）
		Sprite imgSprite = Resources.Load<Sprite>(this.dangoData.SIconPath);
		Image iconImg = this.gameObject.GetComponent<Image>();
		iconImg.sprite = imgSprite;
		//Debug.Log("アイコン設定"+imgSprite);
	}

	/// <summary>
	/// クリックイベント
	/// </summary>
	/// <param name="pointerData"></param>
	public void OnPointerClick(PointerEventData pointerData)
	{
		this.showDetailDiaog(this.dangoData);
	}
}
