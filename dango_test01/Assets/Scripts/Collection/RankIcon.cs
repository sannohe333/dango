using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankIcon : MonoBehaviour
{
	[SerializeField]
	private GameObject activeImage;

	[SerializeField]
	private GameObject desableImage;

	/// <summary>
	/// アイコン画像
	/// 引数がtrueならactive画像を表示し、desable画像を非表示。falseなら逆。
	/// </summary>
	/// <param name="isActive">bool値 </param>
	public void SetActive(bool isActive = false){
		this.activeImage.SetActive(isActive);
		this.desableImage.SetActive(!isActive);
	}
}
