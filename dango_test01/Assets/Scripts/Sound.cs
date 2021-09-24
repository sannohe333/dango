using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    //ダンゴムシクリック
    public AudioClip sound1;
    //ダンゴムシはじく
    public AudioClip sound2;
    //落下
    public AudioClip sound3;
    //ゴール
    public AudioClip sound4;
    //カエル捕食
    public AudioClip sound5;
    //カエルダメージ
    public AudioClip sound6;
    //カエル鳴き声
    public AudioClip sound7;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
