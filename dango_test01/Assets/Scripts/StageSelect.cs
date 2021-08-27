using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class StageSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // クラス名.Instance.関数
        //GameManager.Instance.Test ();
        //Debug.Log ("tes="+GameManager.Instance.tes);
    }

    void Awake()
    {
         /** 既にシーンが読み込まれているかどうか */
        /*public static bool AlreadyLoadScene(string name)
        {
            return SceneManager.GetAllScenes()
                .Any(scene => scene.name == name);
        }*/
        if (!SceneController.AlreadyLoadScene("Common"))
        {
           SceneManager.LoadScene("Common", LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            /** 既にシーンが読み込まれているかどうか */
           
            if (SceneController.AlreadyLoadScene("StageSelect"))
            {
                SceneManager.UnloadSceneAsync("StageSelect");
            }
            
            SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        }
    }
}
