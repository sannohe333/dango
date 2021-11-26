using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangoInfo 
{
	public class Dango{
		/// <summary>
		/// キャラid
		/// </summary>
		public int id;
		/// <summary>
		/// キャラ名
		/// </summary>
		public string name;
		/// <summary>
		/// キャラ情報テキスト
		/// </summary>
		public string infoText;
		/// <summary>
		/// キャラランク
		/// </summary>
		public int rank;
		/// <summary>
		/// Sアイコン画像パス
		/// </summary>
		public string SIconPath;
		/// <summary>
		/// Mアイコン画像パス
		/// </summary>
		public string MIconPath;
		/// <summary>
		/// Lアイコン画像パス
		/// </summary>
		public string LIconPath;
	}

	/// <summary>
	/// ダンゴムシ情報リスト
	/// </summary>	
	public List<Dango> dangoList = new List<Dango>();

	/// <summary>
	/// ダンゴムシ情報の生成
	/// infoをnewした後、とりあえずこれを回すと、
	/// dangoListにダンゴムシ情報が入る
	/// </summary>
	public void SetDangoList(){
		
		Dango dango1 = new Dango();
		dango1.id = 0;
		dango1.name = "ノーマルダンゴムシ";
		dango1.infoText = "ノーマルダンゴムシの\n紹介テキスト";
		dango1.rank = 1;
		dango1.SIconPath = "Image/DangoIcon/normal_S";
		dango1.MIconPath = "Image/DangoIcon/normal_M";
		dango1.LIconPath = "Image/DangoIcon/normal_L";
		this.dangoList.Add(dango1);

		Dango dango2 = new Dango();
		dango2.id = 1;
		dango2.name = "あおいろダンゴムシ";
		dango2.infoText = "かっこいい\nあおいダンゴムシ\nでも、じつは\n病気なんだって・・・！";
		dango2.rank = 2;
		dango2.SIconPath = "Image/DangoIcon/aodango_S";
		dango2.MIconPath = "Image/DangoIcon/aodango_M";
		dango2.LIconPath = "Image/DangoIcon/aodango_L";
		this.dangoList.Add(dango2);

		Dango dango3 = new Dango();
		dango3.id = 2;
		dango3.name = "アルビノ";
		dango3.infoText = "アルビノの\n紹介テキスト";
		dango3.rank = 4;
		dango3.SIconPath = "Image/DangoIcon/sirodango_S";
		dango3.MIconPath = "Image/DangoIcon/sirodango_M";
		dango3.LIconPath = "Image/DangoIcon/sirodango_L";
		this.dangoList.Add(dango3);

		Dango dango4 = new Dango();
		dango4.id = 3;
		dango4.name = "ちゃいろダンゴムシ";
		dango4.infoText = "ちゃいろダンゴムシの\n紹介テキスト";
		dango4.rank = 3;
		dango4.SIconPath = "Image/DangoIcon/akadango_S";
		dango4.MIconPath = "Image/DangoIcon/akadango_M";
		dango4.LIconPath = "Image/DangoIcon/akadango_L";
		this.dangoList.Add(dango4);

		Dango dango5 = new Dango();
		dango5.id = 4;
		dango5.name = "トゲ付きダンゴムシ";
		dango5.infoText = "トゲ付きダンゴムシの\n紹介テキスト";
		dango5.rank = 4;
		dango5.SIconPath = "Image/DangoIcon/togedango_S";
		dango5.MIconPath = "Image/DangoIcon/togedango_M";
		dango5.LIconPath = "Image/DangoIcon/togedango_L";
		this.dangoList.Add(dango5);

		Dango dango6 = new Dango();
		dango6.id = 5;
		dango6.name = "トゲ付きダンゴムシ";
		dango6.infoText = "トゲ付きダンゴムシの\n紹介テキスト";
		dango6.rank = 4;
		dango6.SIconPath = "Image/DangoIcon/dangoThamb5_S";
		dango6.MIconPath = "Image/DangoIcon/dangoThamb5_M";
		dango6.LIconPath = "Image/DangoIcon/dangoThamb5_L";
		this.dangoList.Add(dango6);

		Dango dango7 = new Dango();
		dango7.id = 6;
		dango7.name = "トゲ付きダンゴムシ";
		dango7.infoText = "トゲ付きダンゴムシの\n紹介テキスト";
		dango7.rank = 4;
		dango7.SIconPath = "Image/DangoIcon/dangoThamb6_S";
		dango7.MIconPath = "Image/DangoIcon/dangoThamb6_M";
		dango7.LIconPath = "Image/DangoIcon/dangoThamb6_L";
		this.dangoList.Add(dango7);

		Dango dango8 = new Dango();
		dango8.id = 7;
		dango8.name = "アルビノ部分白化1";
		dango8.infoText = "部分白化ダンゴムシ1の\n紹介テキスト";
		dango8.rank = 4;
		dango8.SIconPath = "Image/DangoIcon/dangoThamb7_S";
		dango8.MIconPath = "Image/DangoIcon/dangoThamb7_M";
		dango8.LIconPath = "Image/DangoIcon/dangoThamb7_L";
		this.dangoList.Add(dango8);

		Dango dango9 = new Dango();
		dango9.id = 8;
		dango9.name = "アルビノ部分白化2";
		dango9.infoText = "部分白化ダンゴムシ2の\n紹介テキスト";
		dango9.rank = 4;
		dango9.SIconPath = "Image/DangoIcon/dangoThamb8_S";
		dango9.MIconPath = "Image/DangoIcon/dangoThamb8_M";
		dango9.LIconPath = "Image/DangoIcon/dangoThamb8_L";
		this.dangoList.Add(dango9);

		Dango dango10 = new Dango();
		dango10.id = 9;
		dango10.name = "ダンゴムシ";
		dango10.infoText = "ダンゴムシの\n紹介テキスト";
		dango10.rank = 4;
		dango10.SIconPath = "Image/DangoIcon/dangoThamb9_S";
		dango10.MIconPath = "Image/DangoIcon/dangoThamb9_M";
		dango10.LIconPath = "Image/DangoIcon/dangoThamb9_L";
		this.dangoList.Add(dango10);

		Dango dango11 = new Dango();
		dango11.id = 10;
		dango11.name = "レモンブルー";
		dango11.infoText = "レモンブルーの\n紹介テキスト";
		dango11.rank = 4;
		dango11.SIconPath = "Image/DangoIcon/dangoThamb10_S";
		dango11.MIconPath = "Image/DangoIcon/dangoThamb10_M";
		dango11.LIconPath = "Image/DangoIcon/dangoThamb10_L";
		this.dangoList.Add(dango11);

		Dango dango12 = new Dango();
		dango12.id = 11;
		dango12.name = "アンバーダッキー";
		dango12.infoText = "アンバーダッキーの\n紹介テキスト";
		dango12.rank = 4;
		dango12.SIconPath = "Image/DangoIcon/dangoThamb11_S";
		dango12.MIconPath = "Image/DangoIcon/dangoThamb11_M";
		dango12.LIconPath = "Image/DangoIcon/dangoThamb11_L";
		this.dangoList.Add(dango12);

		Dango dango13 = new Dango();
		dango13.id = 12;
		dango13.name = "ラバーダッキー";
		dango13.infoText = "ラバーダッキー\n紹介テキスト\nアヒルのおもちゃに似てる";
		dango13.rank = 4;
		dango13.SIconPath = "Image/DangoIcon/dangoThamb12_S";
		dango13.MIconPath = "Image/DangoIcon/dangoThamb12_M";
		dango13.LIconPath = "Image/DangoIcon/dangoThamb12_L";
		this.dangoList.Add(dango13);

		Dango dango14 = new Dango();
		dango14.id = 13;
		dango14.name = "トゲ付きダンゴムシ";
		dango14.infoText = "トゲ付きダンゴムシの\n紹介テキスト";
		dango14.rank = 4;
		dango14.SIconPath = "Image/DangoIcon/togedango_S";
		dango14.MIconPath = "Image/DangoIcon/togedango_M";
		dango14.LIconPath = "Image/DangoIcon/togedango_L";
		this.dangoList.Add(dango14);

		Dango dango15 = new Dango();
		dango15.id = 14;
		dango15.name = "トゲ付きダンゴムシ";
		dango15.infoText = "トゲ付きダンゴムシの\n紹介テキスト";
		dango15.rank = 4;
		dango15.SIconPath = "Image/DangoIcon/togedango_S";
		dango15.MIconPath = "Image/DangoIcon/togedango_M";
		dango15.LIconPath = "Image/DangoIcon/togedango_L";
		this.dangoList.Add(dango15);
	}
}