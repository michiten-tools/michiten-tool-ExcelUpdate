using System;
using System.Drawing;
using System.IO;
using System.Security.Policy;
using System.Text;

namespace MergeAichanJson
{
	public class Define
	{
		// Log
		public const string LOG_DIR = "Aiちゃん";
		public const string LOG_FILE = "Aiちゃん.log";

		// key
		public const string KEY_FILE = "KeyAi.dat";

		// sound
		public const string MP3_01 = "decision34.mp3";
		public const string MP3_02 = "decision35.mp3";

		public const string DIR_Resources = "Resources";

		// webview
#if DEBUG
		public static string WebViewRuntimePath = Path.Combine(
			$"{Environment.GetEnvironmentVariable("SystemDrive")}\\",
			"fec-lib", "Microsoft.WebView2.FixedVersionRuntime.101.0.1210.47.x64");
#else
		public static string WebViewRuntimePath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
			"fec", "Microsoft.WebView2.FixedVersionRuntime.101.0.1210.47.x64");
#endif

		// map
#if DEBUG
		public static string WebMapPath = Path.Combine(
			Directory.GetCurrentDirectory(),
			"web", "map.html");
		public static string RenameMapPath = Path.Combine(
			Directory.GetCurrentDirectory(),
			"rename", "map.html");
#else
		public static string WebMapPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
			"fec", "ai", "web", "map.html");
		public static string RenameMapPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
			"fec", "ai", "rename", "map.html");
#endif
		// form
		//public static readonly Size DefFormSize = new Size(1650, 766);
		//public static readonly Size DefPictureSize = new Size(800, 450);

		// dir
		public const string FramesDirName = "frames";
        public const string FramesMosaicAllDirName = "frames_mosaic_all";
        public const string FramesMosaicCheck = "frames_mosaic_check";
        public const string cutFramesDirName = "cut_frames";	//赤枠で囲った画像のみを抽出したframesファイルの格納フォルダ
		//public const string TempDirName = "temp";
		public const string signFramesDirName = "sign_frames";

		// Encoding
		public static readonly Encoding JIS = Encoding.GetEncoding("Shift_JIS");
		public static readonly Encoding UTF = Encoding.GetEncoding("UTF-8");

		// Extention
		public const string MovExt = ".MOV";
		public const string KmlExt = ".kml";
		public const string WorkExt = ".json";
		public const string PairsExt = ".json";
		public const string JpegExt = ".jpeg";
		public const string CsvExt = ".csv";

		public const string MovFileExt = "*.mov";
        public const string KmlFileExt = "*.kml";
        public const string NmeaFileExt = "*.NMEA";
		public const string NmeaFileExt_ = "_*.NMEA";
		public const string JpegFileExt = "*.jpeg";
		public const string TextFileExt = "*.txt";
		public const string JsonFileExt = "*.json";

		// string.Format
		public const string TimeSpanFormat = @"hh\:mm\:ss\.fff";
		public const string DateTimeFormat = "yyyy/MM/dd HH:mm:ss.fff";
		public const string DateTimeFormat2 = "yyyy/MM/dd\nHH:mm:ss.fff";
		public const string CurrentDateFormat = "yyyy/MM/dd HH:mm:ss.fff";
		public const string StartDateFormat = "yyMMddHHmmss";
		public const string KmlWriteWhenFormat = "yyyy-MM-ddTHH:mm:sszzz";
		public const string PairsTimeFormat = "yyyy-MM-ddTHH:mm:ss+09:00";
		public const string ListNoFormat = "00000000";
		public const string LatLngFormat = "#.00000000";
		public const string JpegFormat = "yyyyMMdd-HHmmssfff";
		public const string PairsBackUpDate = "yyyyMMdd-HHmmss";
		public const string MovLenghtFormat = "HH:mm:ss";

		// Map Vals
		public const int MapZoomInit = 18;
		public static readonly Color InitCircleColor = ColorTranslator.FromHtml("#ff00ff");

		// Rect Draw Vals
		public static readonly Color RectInitColor = ColorTranslator.FromHtml("#ff0000");
		public const int DashMargin = 2;
		public static readonly Point DashPoint = new Point { X = -1, Y = -1 };
		public static readonly Size DashSize = new Size { Width = 0, Height = 0 };

		// jpeg vals
		//public enum JpegMode { TEMP, PAIRS }

		// Road Type
		public enum RoadType { None, National, Metropolis, City }
		//public const string TYPE_UnName = "Unnamed";
		//public const string TYPE_CityJPN = "市区町村道、その他";
		//public static readonly string[] TYEP_ROAD = { "国道", "都道", "道道", "府道", "県道" };

		// SignItem ID Vals
		//public const string StartNoDefault = "000010";
		public const int StartNoInterval = 10;

		// SignItem ID Msg
		public const string StartNoError = "管理ID（開始番号）が適切ではありません。";

		// Duplication Vals
		public static readonly Point ThumnailOriginPoint = new Point { X = 3, Y = 3 };
		public const int ThumnailSpaceWidth = 326;
		public const int ThumnailSpaceHeight = 326;
		public const float LoupeRatio = 0.7f;

		// Duplication Msg
		public const string DuplicationInform = "付近に登録されている施設があります。確認しますか？\n確認する場合は「はい」、このまま登録する場合は「いいえ」を選択してください。";


		// SD Import Vals
		public const string DirNML = "NORMAL";
		public const string DirSYS = "SYSTEM";
		public const string DirNMEA = "NMEA";

		// SD Import Msg
		public const string SdRootSelectMsg = "SDカードのドライブ、もしくはSDカードと同じ構成があるフォルダを選択してください。";
		public const string SdWorkRootSelectMsg = "SDカード内データのコピー先のフォルダ（業務名など）を選択してください。";
		public const string SdCopiedWorkSelectMsg = "SDカード内データをコピーしたフォルダを選択してください。";

		public const string SdStripCopyMsg = "コピー中";
		public const string SdStripConvertMsg = "変換中";
		public const string SdStripWaitMsg = "待機中";


		// MOV Load Vals
		public enum FrameMode { None, Prev, Next }
		public static readonly int[] MovieAllowWidth = { 2560, 1920, 1280 };

		// MOV Load Msg
		public const string MovieExtensionError = ".mov/.MOVのみ対応しています。";
		public const string MovieSizeError = "動画のフレームサイズは 2560x1440 1920x1080 1280x720 のいずれかである必要があります。";


		// KML Convert Vals
		public const string NmeaGTRIP = "$GTRIP";
		public const string NmeaJKDSA = "$JKDSA";
		public const string NmeaGPRMC = "$GPRMC";
		public const string NmeaGNRMC = "$GNRMC";
		public const string NmeaGPGGA = "$GPGGA";

		// convert nmea msg
		public const string WarnGprmcLength = "GPRMCの長さがKENWOODと異なります。";

		// KML Load Vals
		public static readonly char[] KmlSeparator = { '<', '>', 'T', 'Z', ' ' };
		public const string KmlLineWhen = "when";
		public const string KmlLineCoord = "<coord>";
		public const string KmlLineCoordinates = "<coordinates>";
		public const string KmlLineDescription = "<description>";
		public const string KmlLineStyleUrl = "<styleUrl>";
		public const string KmlCoordinates = "coordinates";
		public const string KmlWriteWhenS = "<when xmlns=\"\">";
		public const string KmlWriteWhenE = "</when>";
		public const string KmlWriteCoordS = "<coord>";
		public const string KmlWriteCorrdE = "</coord>";
		public const string KmlNmeaLoaded = "nmeaLoaded";
		public const string KmlKmlSaved = "kmlSaved";

		// KML Load Msg
		public const string KmlNotFound = " が見つかりません。";
		public const string KmlNotExist = "KMLファイルが存在しません。";
		public const string KmlNullError = "kmlに位置情報がありません。";
		public const string KmlConvertFinish = "変換が完了しました。";


		// Work Vals
		public const string WorkFile = "work.json";
		public const string WorkFilter = "JSONファイル(*.json)|*.json";
		public const string WorkStateTag = "済_";

		// Work Msg
		public const string WorkTitle = "設定ファイル（JSON）を選択してくだい。";
		public const string WorkStateChange = "作業状態を変更します。よろしいですか？";


		// Load Work Msg
		public const string LoadWorkMsg = "表示中の内容が更新されますがよろしいですか？";
		public const string LoadWorkNG = "設定ファイルが破損しています。";
		public const string LoadWorkSelectError = "選択したファイルは作業ファイルではありません。";
		public const string LoadWorkMissLatLng = "前回終了時に位置情報が未登録の施設がありました。\n最初にこの施設の位置情報を登録してください。";


		// Save Work Msg
		public const string SaveWorkFileError = ".jsonのみ対応しています。";
		public const string SaveWorkOK = "WorkModelの保存に成功しました。";
		public const string SaveWorkNG = "WorkModelの保存に失敗しました。";


		// PairsFile Msg
		public const string LoadPairsOK = "PairsModelの読込に成功しました。";
		public const string LoadPairsNG = "PairsModelの読込に失敗しました。";
		public const string SavePairsOK = "PairsModelの保存に成功しました。";
		public const string SavePairsNG = "PairsModelの保存に失敗しました。";


		// Export Pairs Vals
		public const string PairsFileName = "pairs.csv";
		public const string PairsLabelFileName = "pairsLabel.csv";
		public const string PairsHeader = "no,time,category,lon,lat,imagefilename, longitemsrc";

        public const string PairsSignFileName = "pairsSign.csv";
        public const string PairsSignHeader = "signNo,signType,signName,SignDirection,parentSpecNo,parentDirectionNo,large,Hojo,filename";
        public const string PairsSignExist = "pairsSign.csv はすでに存在します。上書きしてよろしいですか？";

		//LongItemPairs
        public const string PairsLongitemFileName = "pairsLongItem.csv";
        public const string PairsLongitemHeader = "signNo,lat,lng,order";
        public const string PairsLongitemExist = "pairsLongItem.csv はすでに存在します。上書きしてよろしいですか？";

        // Export Msg
        public const string ExportImgEmpty = "の緯度経度が更新されていません。";
		public const string ExportFolder = "出力先のフォルダを指定してください。";
		public const string ExpoftInterruption = "出力を中断しました。";
		public const string PairsExist = "pairs.csv はすでに存在します。上書きしてよろしいですか？";
		public const string PairsLabelExist = "pairsLabel.csv はすでに存在します。上書きしてよろしいですか？";
		public const string ExportError = "出力に失敗しました。";
		public const string ExportFileIoError = "pairsファイルの出力に失敗しました。";
		public const string ExportFinish = "出力が完了しました。";

		// Export Frames Vals
		public static readonly Size FrameNullSize = new Size { Width = 0, Height = 0 };
		//public static Size FrameDefaultSize = new Size { Width = 2560, Height = 1440 };


		// DataGridView Vals
		public const string ListUpdateLatLng = "btLatLng";
		public const string ListCategory = "listCategory";
		public const string ListLabel = "listLabel";

		// DataGridView Add Msg
		public const string AddListFileError = "動画ファイルが読み込まれていません。";
		public const string AddListModeError = "矩形描画モードになっていません。";
		public const string AddListRectError = "矩形が描画されていません。";
		public const string AddListTypeError = "種別が選択されていません。";
		public const string AddListFilteredError = "フィルタ適用中は登録することは出来ません。";
		public const string AddListCategoryError = "帯状（終点）から登録することはできません。";
		public const string AddListStateError = "位置を入力するまでリストに追加することはできません。";
		public const string TimeTargetError = "リスト追加時よりも後の時刻である必要があります。";
		public const string KmlCountError = "kmlが読み込まれていません。";
		public const string KmlTimeNotFount = "kmlに該当の時刻が見つかりませんでした。";
		public const string MsgOffsetError = "オフセットが選択されていません。";
        public const string MsgListSelectedError = "リストが選択されていません。";

        // アノテーション更新時の確認Msg
        public static bool ReAnnotationFlag = true;
		public static string ReAnnotationMsg = "アノテーション位置を修正しますか？";


		/// <summary>
		/// 納品用ラベル情報のクリア確認Msg
		/// </summary>
		public static string RenameClearMsg = "納品用ラベルをクリアしますか？";


		// DataGridView Update Msg
		public const string UpdateLatLngConfirm = "すでに位置が入力されています。更新しますか？";

		// DataGridView Remove Msg
		public const string RemoveListConfirm = "選択した項目を削除してよろしいですか？";


		// TrimMovie Vals
		public const int FrameTimerInterval = 300;


		// Setting
		public const string MsgSettingOffsetError = "オフセットの値が正しくありません。";
		public const string MsgSettingOffsetValue = "オフセットの値は0以上である必要があります。";

		/// <summary>
		/// 解析距離結果出力ファイル名
		/// </summary>
		public const string AnalysisDistanceFileName = "AnalysisDistance.csv";

		/// <summary>
		/// 解析距離結果出力でのエラーメッセージ
		/// </summary>
		public const string AnalysisDistanceError =
			AnalysisDistanceFileName +
			"ファイルの出力に失敗しました。";

		/// <summary>
		/// ShikiちゃんでのAnnotationのキー
		/// </summary>
		public const int SignBoradAnnotationKey = -1;

        public enum BusinessMode { Michiten, Kenkei, Tetsuten }

        public const string MsgListUpdate = "表示中の内容が更新されますがよろしいですか？";
        public const string FilterExtCsv = "pairs.csv";
        public const string FilterCsv = "csvファイル(*.csv)|*.csv";
        public const string MsgOpenPairs = "pairsファイル（.csv）を選択してくだい。";
    }
}
