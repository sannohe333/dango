using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class Title : MonoBehaviour
{

    void Awake()
    {
         /** 既にシーンが読み込まれているかどうか */

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
           
            if (SceneController.AlreadyLoadScene("Title"))
            {
                SceneManager.UnloadSceneAsync("Title");
            }
            
            SceneManager.LoadScene("StageSelect", LoadSceneMode.Additive);
        }
    }
}
