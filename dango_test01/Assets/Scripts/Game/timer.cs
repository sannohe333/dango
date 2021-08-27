using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]
	private int minute;
	[SerializeField]
	public float seconds;
	//　前のUpdateの時の秒数
	private float oldSeconds;
	//　タイマー表示用テキスト
	public Text timerText;

	public bool timerActive;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
		seconds = 0f;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text> ();

		timerActive=false;
    }

    // Update is called once per frame
    void Update()
    {
		if(timerActive){
				seconds += Time.deltaTime;
			if(seconds >= 60f) {
				minute++;
				seconds = seconds - 60;
			}
			//　値が変わった時だけテキストUIを更新
			if((int)seconds != (int)oldSeconds) {
				//timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString ("00");
				//timerText.text =seconds.ToString("F2");
			}
			oldSeconds = seconds;
			timerText.text =seconds.ToString("F1")+"sec";
		}
        
        
    }
}
