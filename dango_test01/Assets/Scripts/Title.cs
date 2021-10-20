using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	UserDataInfo userDataInfo = new UserDataInfo();

	void Awake()
	{
		/** 既にシーンが読み込まれているかどうか */
		if (!SceneController.AlreadyLoadScene("Common"))
		{
		SceneManager.LoadScene("Common", LoadSceneMode.Additive);
		}
	}

	public void Start()
	{

	}
}