
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;



namespace IntegradeMovieJson
{


	/// <summary>
	/// ワークモデル
	/// {フォルダ名}.jsonで保存される情報
	/// </summary>
	public class WorkModel
	{
		public bool WorkState { get; set; } = false;
		public string RootDir { get; set; }
		public string MovieFile { get; set; }
		public string KmlFile { get; set; }
		public string PairsFile { get; set; }
		public Color RectColor { get; set; } = Color.Red;
		public float RectThickness { get; set; } = 4.5f;
		public float PlaySpeed { get; set; } = 0.5f;
		public int RadarRange { get; set; } = 8;
		public SettingModel Setting { set; get; } = new SettingModel();
		public List<string> SignItems { get; set; } = new List<string>();
		public string SignStartNo { get; set; } = "00000010";
		public Version Version { get; set; }
		public DateTime WorkUpdateDate { get; set; }


		/// <summary>
		/// Movファイルのフルパスを返す
		/// </summary>
		/// <returns></returns>
		public string GetMovFileFullPath()
        {
			return Path.Combine(RootDir, MovieFile);
		}


		/// <summary>
		/// Kmlファイルのフルパスを返す
		/// </summary>
		/// <returns></returns>
		public string GetKmlFileFullPath()
        {
			return Path.Combine(RootDir, KmlFile);
		}


		/// <summary>
		/// Pairsファイルのフルパスを返す
		/// </summary>
		/// <returns></returns>
		public string GetPairsFileFullPath()
        {
			if (PairsFile == null)
			{
				PairsFile = Path.Combine(RootDir, $"{Path.GetFileName(RootDir)}.json");
			}

			return Path.Combine(RootDir, PairsFile);
		}


		/// <summary>
		/// MovFilePathで各関係フィールド値を更新
		/// </summary>
		/// <param name="movFilePath"></param>
		public void SetMovFileInfo(string movFilePath)
        {
			RootDir = Directory.GetParent(movFilePath).ToString();
			MovieFile = Path.GetFileName(movFilePath);

			if (MovieFile.StartsWith("済_"))
            {
				WorkState = true;
			}
		}


		/// <summary>
		/// 保持Movファイル名からKMLファイル名を生成して存在チェックして
		/// あればKMLファイル名を保持する。
		/// </summary>
		/// <returns></returns>
		public bool SetKmlFileName()
        {
			// Movファイル名からkmlファイル名を作成
			var kmlFileName = $"{Path.GetFileNameWithoutExtension(MovieFile)}{".kml"}";

			// ファイルがあれば、kmlファイル名をWorkにセット
			if (File.Exists(Path.Combine(RootDir, kmlFileName)))
            {
				KmlFile = kmlFileName;
				return true;
            }

			return false;
        }


	}
}
