using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CollectionListIcon : MonoBehaviour,IPointerClickHandler
{
	/// <summary>
	/// クリックイベント
	/// </summary>
	/// <param name="pointerData"></param>
	public void OnPointerClick(PointerEventData pointerData){
		Debug.Log(gameObject.name + " がクリックされた!");
	}

	/// <summary>
	/// アイコン画像オブジェクト
	/// </summary>
	[SerializeField]
	private Image iconImg;

	/// <summary>
	/// 表示する内容をセットする
	/// </summary>
	public void SetData(string imgPath)
	{
		// 画像設定（例："Images/enemy/enemy000"）
		Sprite imgSprite = Resources.Load<Sprite>(imgPath);

		this.iconImg.sprite = imgSprite;
		//Debug.Log("アイコン設定"+imgSprite);
	}
}
