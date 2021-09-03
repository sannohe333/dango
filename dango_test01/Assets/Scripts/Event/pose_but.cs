using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pose_but : MonoBehaviour
{
    //poseボタン
    public GameObject pose_menu;

    // Start is called before the first frame update
    void Start()
    {
        //pose_menu=GameObject.Find("Canvas/pose_panel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoseMenuOn()
    {
        pose_menu.SetActive(true);
        Time.timeScale = 0f;
    }
}
