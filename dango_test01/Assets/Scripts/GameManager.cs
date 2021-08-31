using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    //プレイするステージ
    public int stage_st;

    //クリアーしたステージ
    public int clear_stage_st;

    //初オープンステージ
    public bool first_open;

    void Start()
    {
        stage_st=0;
        clear_stage_st=0;
        first_open=false;
    }

    void Update()
    {
        //Debug.Log("stage_st="+stage_st+" : clear_stage_st="+clear_stage_st);
    }
}