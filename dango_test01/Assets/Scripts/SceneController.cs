using UnityEngine.SceneManagement;

public static class SceneController
{
    /** 既にシーンが読み込まれているかどうか */
    public static bool AlreadyLoadScene(string name)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == name)
            {
                return true;
            }
        }
        return false;
    }
}