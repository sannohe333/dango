using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    public int tes;

    void Start()
    {
        tes=128;
    }

    public void Test(){
        
        //Debug.Log ("シングルトン！");
    }
}