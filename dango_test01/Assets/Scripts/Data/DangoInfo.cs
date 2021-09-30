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
		dango2.infoText = "あおいろダンゴムシの\n紹介テキスト";
		dango2.rank = 2;
		dango2.SIconPath = "Image/DangoIcon/aodango_S";
		dango2.MIconPath = "Image/DangoIcon/aodango_M";
		dango2.LIconPath = "Image/DangoIcon/aodango_L";
		this.dangoList.Add(dango2);

		Dango dango3 = new Dango();
		dango3.id = 2;
		dango3.name = "ちゃいろダンゴムシ";
		dango3.infoText = "ちゃいろダンゴムシの\n紹介テキスト";
		dango3.rank = 3;
		dango3.SIconPath = "Image/DangoIcon/akadango_S";
		dango3.MIconPath = "Image/DangoIcon/akadango_M";
		dango3.LIconPath = "Image/DangoIcon/akadango_L";
		this.dangoList.Add(dango3);

		Dango dango4 = new Dango();
		dango4.id = 3;
		dango4.name = "しろダンゴムシ";
		dango4.infoText = "しろダンゴムシの\n紹介テキスト";
		dango4.rank = 3;
		dango4.SIconPath = "Image/DangoIcon/sirodango_S";
		dango4.MIconPath = "Image/DangoIcon/sirodango_M";
		dango4.LIconPath = "Image/DangoIcon/sirodango_L";
		this.dangoList.Add(dango4);
	}
}