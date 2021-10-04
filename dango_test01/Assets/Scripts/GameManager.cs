using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    /// <summary>
    /// コレクトしたダンゴキャラのIDを代入。
    /// ※このIDはDangoInfoクラスで設定されているDangoInfo.Dango.idの値を見ている
    /// （とりあえずテスト用で初期値入れてる）
    /// </summary>
	public List<int> collectDangoIdList = new List<int>{0,2};

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