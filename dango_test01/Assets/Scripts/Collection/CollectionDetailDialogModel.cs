using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CollectionDetailDialogModel : MonoBehaviour,IPointerClickHandler
{
	private Action clickSelf;
	/// <summary>
	/// モデルの設定
	/// </summary>
	/// <param name="clickModel"></param>
	public void SetData(Action clickModel)
	{
		this.clickSelf = clickModel;
	}
	/// <summary>
	/// クリックイベント
	/// </summary>
	/// <param name="pointerData"></param>
	public void OnPointerClick(PointerEventData pointerData)
	{
		this.clickSelf();
	}
}
