using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 画面タップエフェクト表示クラス
/// </summary>
public class TapEffect : MonoBehaviour
{
	/// <summary>
	/// タッチエフェクト用オブジェクト
	/// </summary>
	[SerializeField]
	private GameObject tapEffectPrefab;

	/// <summary>
	/// エフェクトを表示するカメラ
	/// </summary>
	[SerializeField]
	private Camera targetCamera;

	void Update()
	{
		//タッチエフェクト
		if (Input.GetMouseButtonDown(0))
		{
			//マウスカーソルの位置を取得。
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 1.0f;

			GameObject clone = Instantiate(this.tapEffectPrefab, this.targetCamera.ScreenToWorldPoint(mousePosition), Quaternion.identity);
		}
	}
}
