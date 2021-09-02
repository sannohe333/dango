using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class UnityMenu : MonoBehaviour
{
#if UNITY_EDITOR
	private static void Open(string name)
	{
		// シーンの変更があった場合にどうするか聞く
		if (UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
		{
			UnityEditor.SceneManagement.EditorSceneManager.OpenScene(name);
			UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Scenes/Common.unity", OpenSceneMode.Additive);
		}
	}

	[MenuItem("シーン選択/タイトル")]
	private static void OpenTitle()
	{
		Open("Assets/Scenes/Title.unity");
	}

	[MenuItem("シーン選択/ステージセレクト")]
	private static void OpenStageSelect()
	{
		Open("Assets/Scenes/StageSelect.unity");
	}

	[MenuItem("シーン選択/メインゲーム")]
	private static void OpenGame()
	{
		Open("Assets/Scenes/Game.unity");
	}

	[MenuItem("シーン選択/コレクション")]
	private static void OpenCollection()
	{
		Open("Assets/Scenes/Collection.unity");
	}

#endif
}
