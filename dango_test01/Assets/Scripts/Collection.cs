using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using UnityEngine.EventSystems;


public class Collection : MonoBehaviour
{
    void Awake()
    {
         /** 既にシーンが読み込まれているかどうか */
        if (!SceneController.AlreadyLoadScene("Common"))
        {
           SceneManager.LoadScene("Common", LoadSceneMode.Additive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
