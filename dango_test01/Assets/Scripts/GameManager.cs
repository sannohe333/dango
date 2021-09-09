using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    //プレイするステージ
    [HideInInspector]
    public int stage_st;

    //クリアーしたステージ
    [HideInInspector]
    public int clear_stage_st;

    //初オープンステージ
    [HideInInspector]
    public bool first_open;

    public bool debug_mode;

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