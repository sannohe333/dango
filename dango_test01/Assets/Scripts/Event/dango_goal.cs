using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dango_goal : MonoBehaviour
{
    //外部スクリプト参照
    private Score  Score;
    public GameObject root ;

    // Start is called before the first frame update
    void Start()
    {
        //自らの親オブジェクト
        root = transform.root.gameObject ;

        Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();
        //Debug.Log(transform.root.gameObject);

    }

    void clear_obj()
    {
        //FindObjectOfType<Score>().AddPoint(1);
        Score.AddPoint(1);
        Destroy(root);
    }

    void dead_obj()
    {
        Score.deleteCnt();
        Destroy(root);
    }
}
