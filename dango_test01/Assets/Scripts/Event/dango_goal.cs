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
        //root = transform.root.gameObject ;
        root = transform.parent.gameObject ;

        Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();
        //Debug.Log(transform.root.gameObject);

    }

    void clear_obj()
    {
        //FindObjectOfType<Score>().AddPoint(1);
        Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();
        Score.AddPoint(1);
        Destroy(root);
    }

    void dead_obj()
    {
        Score=GameObject.Find("Canvas/ScorePanel").gameObject.GetComponent<Score>();
        Score.deleteCnt();
        Destroy(root);
    }
}
