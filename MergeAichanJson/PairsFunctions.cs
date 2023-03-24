using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace MergeAichanJson
{
	class PairsFunctions
	{
	

		public static PairsModel LoadPairsModel(string file, out bool cancel)
		{
			//string dateStr = DateTime.Now.ToString(Define.PairsBackUpDate);
			//string bkFile = Path.Combine(
			//	Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
			//	Define.LOG_DIR,
			//	$"{Path.GetFileNameWithoutExtension(file)}_{dateStr}.json");

			//File.Copy(file, bkFile);
            //Log.Info($"BackUp PairsModel {bkFile}");

            //Log.Info($"Load PairsModel {file}");

			cancel = false;

            string load = "";
			using (StreamReader sr = new StreamReader(file, encoding: Encoding.UTF8))
			{
				load = sr.ReadToEnd();
			}

			PairsModel model = new PairsModel();
			try
			{
				model = JsonConvert.DeserializeObject<PairsModel>(load);
			}
			catch
			{
				//Log.Error(Define.LoadPairsNG);
				Console.WriteLine("ファイル読込失敗："+file);
				return null;
			}

//			MigrationOffset(model);

			//foreach (SignItem a in model.Items)
			//{
			//	foreach (DirectionItem b in a.DirectionList)
			//	{
			//		foreach (SignBoard.Sign c in b.SignBoard.sign)
			//		{
			//			string[] split = c.SignNo.Split('-');
			//			if(split.Length == 2)
			//			{
			//				if(split[0].EndsWith("F") ||
   //                             split[0].EndsWith("S") ||
			//					split[0].EndsWith("R"))
			//				{

   //                         }
			//				else
			//				{
			//					string s = string.Empty;
			//					switch (c.SignDirection)
			//					{
			//						case "正面": s = "F"; break;
   //                                 case "背面": s = "R"; break;
   //                                 case "側面": s = "S"; break;
   //                                 default:
			//							break;
			//					}

			//					if (a.Rename.Selected)
			//					{
			//						c.SignNo = a.Rename.Rename + s + "-" + split[1];
			//					}
			//					else
			//					{
			//						c.SignNo = split[0] + s + "-" + split[1];
			//					}
   //                         }

   //                     }

			//		}
			//	}
			//}

			//jsonの操作モードと、メニュー選択の操作モードが異なる場合
			//if(MainMenu.Mode != model.BusinessMode)
			//{

			//	//問い合わせ
   //             if (MsgBoxUtil.ConfirmOfYes("選択した動画は、以前に異なる操作モードで開かれました。\r\nJSONファイルを今回選択した操作モードに変換しますか？"))
			//	{

			//		//バックアップ取得
   //                 FileInfo fileInfo = new FileInfo(file);
			//		string bkName = Path.Combine(fileInfo.Directory.FullName, $"{Path.GetFileNameWithoutExtension(file)}_{dateStr}.json");
			//		File.Copy(file, bkName, true);
   //                 Log.Info($"BackUp PairsModel {bkName}");

			//		//種別を変換する
   //                 foreach (SignItem item in model.Items)
			//		{
			//			var a = CategoryDefine.ConvertCategory(model.BusinessMode, MainMenu.Mode, item.Category);
			//			string no = item.No;
			//			item.No = a.Item2 + no.Substring(1 ,no.Length - 1);
			//			item.Category = a.Item1;
			//		}

			//		MessageBox.Show("変換が完了しました。");
			//	}
			//	else
			//	{
			//		//キャンセル
			//		cancel = true;
			//	}


			//}


			return model;
		}




		/// <summary>
		/// Offset情報が存在しない場合にOffset初期値セット
		/// </summary>
		/// <param name="model"></param>
		//private void MigrationOffset(PairsModel model)
  //      {
		//	foreach (var item in model.Items)
		//	{
		//		if (item.Offset == null)
		//			item.Offset = new OffsetItem();

		//		if (item.OrgTarget == null)
		//			item.OrgTarget = new LatLng();

		//		if (item.TimeTarget.Lat != 0 && item.OrgTarget.Lat == 0)
		//			item.OrgTarget = item.TimeTarget;
		//	}
		//}



		///// <summary>
		///// 更新時刻をNowで更新してPairsModel保存 {フォルダ名}.json
		///// </summary>
		///// <param name="model"></param>
		///// <param name="file"></param>
		//public void SavePairsModel(PairsModel model, string file)
		//{
		//	Log.Info($"Save PairsModel {file}");

		//	try
		//	{
		//		model.PairsUpdateDate = DateTime.Now;

		//		string json = JsonConvert.SerializeObject(model, Formatting.Indented);
		//		using (StreamWriter sw = new StreamWriter(file, false, Define.UTF))
		//		{
		//			sw.Write(json);
		//		}

		//		//Log.Info($"{Define.SavePairsOK}");
		//	}
		//	catch (Exception e)
		//	{
		//		Log.Error($"{Define.SavePairsNG} {e.ToString()}");
		//		UtilFunctions.ErrMsg(Define.SavePairsNG);
		//	}
		//}


		//public SignItem CheckTimeTarget(List<SignItem> items)
		//{
		//	var item = items.Where(x => x.TimeTarget.Lat == 0 || x.TimeTarget.Lng == 0);

		//	if (item == null)
		//		return null;

		//	if (item.Count() == 0)
		//		return null;

		//	Log.Warning($"{item.ToList()[0].No} の位置情報が未登録です。");
		//	return item.ToList()[0];
		//}
		//public bool CheckPairsCsv(string file)
		//{
		//	if (string.IsNullOrEmpty(file))
		//	{
		//		UtilFunctions.ErrMsg("選択が正しくありません。");
		//		return false;
		//	}

		//	if (!File.Exists(file))
		//	{
		//		UtilFunctions.ErrMsg("選択したファイルが存在しません。");
		//		return false;
		//	}

		//	string frames = Path.Combine(Directory.GetParent(file).ToString(), Define.FramesDirName);

		//	if (!Directory.Exists(frames))
		//	{
		//		UtilFunctions.ErrMsg($"{frames} フォルダが存在しません。");
		//		return false;
		//	}

		//	List<string> jpegFiles = Directory.EnumerateFiles(frames, Define.JpegFileExt, SearchOption.TopDirectoryOnly).ToList();
		//	if (jpegFiles.Count == 0)
		//	{
		//		UtilFunctions.ErrMsg($"{frames} フォルダに画像ファイルが存在しません。");
		//		return false;
		//	}

		//	return true;
		//}

		//public List<SignItem> LoadPairsCsv(string file)
		//{
		//	try
		//	{
		//		List<SignItem> res = new List<SignItem>();
		//		using (var sr = new StreamReader(file, Define.JIS))
		//		{
		//			int count = 0;
		//			while (!sr.EndOfStream)
		//			{
		//				string line = sr.ReadLine();

		//				if (line.StartsWith("no"))
		//				{
		//					continue;
		//				}

		//				string[] strs = line.Split(',');

		//				if (6 <= strs.Length)
		//				{
		//					var newItem = new SignItem
		//					{
		//						Index = count,
		//						CurrentFrame = 0,
		//						No = strs[0],
		//						Category = CategoryDefine.GetCategoryIndex(strs[2]),
		//						TimeTarget = new LatLng
		//						{
		//							Lat = double.Parse(strs[4]),
		//							Lng = double.Parse(strs[3]),
		//							Time = DateTime.Parse(strs[1]),
		//						},

		//						// NOTE: ImageFileNameがLot/Labelで食い違うので削除
		//						ImageFileName = strs[5],
		//					};

		//					if (strs.Length == 7)
		//					{
		//						// 帯状（終点）のとき
		//						newItem.LongItem = new LongItemModel
		//						{
		//							// NOTE: IDにしたから無理
		//							//SrcNo = strs[6],
		//							//DstNo = strs[0]
		//						};
		//					}

		//					res.Add(newItem);

		//					count++;
		//				}
		//				else
		//				{
		//					Debug.WriteLine("> length error");
		//				}
		//			}
		//		}

		//		return res;
		//	}
		//	catch (Exception e)
		//	{
		//		//Log.Error(e.ToString());
		//		return null;
		//	}
		//}

		//public void ShowFrames(PictureBox pb, string csv, string img)
		//{
		//	string file = Path.Combine(
		//			Directory.GetParent(csv).ToString(),
		//			Define.FramesDirName,
		//			img);

		//	Mat mat = new Mat(file);
		//	var dispSize = new OpenCvSharp.Size(pb.Width, pb.Height);
		//	var dispImg = mat.Resize(dispSize);

		//	if (pb.Image != null)
		//		pb.Image.Dispose();

		//	pb.Image = BitmapConverter.ToBitmap(dispImg);
		//	dispImg.Dispose();
		//	mat.Dispose();
		//}

		//public List<SignItem> RemoveItems(List<SignItem> items, SignItem remove, ref SignItem src)
  //      {
		//	if (remove.Category == 7 || remove.Category == 107)
  //          {
		//		// 帯状（起点）

		//		// 終点を探す
		//		var dst = items.Where(x => (x.Category == 8 || x.Category == 108) && x.LongItem.SrcID.Equals(remove.ItemID)).FirstOrDefault();

		//		// 終点を除去
		//		if (dst != null)
		//			items.Remove(dst);
  //          }

		//	else if (remove.Category == 8 || remove.Category == 108)
  //          {
		//		// 帯状（終点）

		//		// 起点を探して返す
		//		src = items.Where(x => (x.Category == 7 || x.Category == 107) && x.ItemID.Equals(remove.LongItem.SrcID)).FirstOrDefault();
		//	}

		//	// 対象を除去
		//	items.Remove(remove);

		//	return items;
  //      }



		///// <summary>
		///// フロント解析時のデータをリア解析に変換する
		///// </summary>
		///// <param name="pairsJson"></param>
		///// <param name="currentVersion"></param>
		//public void DirectionConvert(string pairsJson, DirectFlg direct, Version currentVersion)
		//{
  //          Log.Info($"DirectionConvert to {DirectionItem.GetDirectionTypeString(direct)}: {pairsJson}");

  //          // jsonの場所を取得
  //          string parent = Directory.GetParent(pairsJson).ToString();

		//	// 読込
		//	bool cancel;
  //          var pairsModel = LoadPairsModel(pairsJson, out cancel);

		//	try
		//	{
		//		// バージョンが古いかもしれないので
		//		if (pairsModel.Version != currentVersion)
		//		{
		//			pairsModel = PairsVersionFunctions.AjustVersion(pairsModel, currentVersion);

		//			pairsModel.Version = currentVersion;
		//		}
		//	}
		//	catch (Exception e)
		//	{
		//		Log.Error($"DirectionConvert バージョン更新エラー: {e.Message}");
		//		return;
		//	}


		//	// DirectionListがフロントだけか確認
		//	bool directionListError = false;
		//	try
		//	{
		//		foreach (var item in pairsModel.Items)
		//		{
		//			// 個数で判断
		//			if (item.DirectionList.Count != 1)
		//			{
  //                      // "F"の文字チェックは割愛

  //                      Log.Warning($"{item.No}のDirectinListの数が1つではありません({item.DirectionList.Count})");
		//				directionListError = true;
		//			}
		//		}
		//	}
		//	catch (Exception e)
		//	{
  //              Log.Error($"DirectionConvert DirectionListエラー: {e.Message}");
  //              return;
  //          }

		//	if (directionListError) return;


		//	// 変換する向きの動画ファイルの存在確認
		//	List<string> rearMovs = MovieFunctions.GetMovFileList(parent);
		//	if (rearMovs.Count == 0)
		//	{
  //              Log.Error($"DirectionConvert 動画ファイルなし: {parent}");
  //              return;
		//	}


		//	// 登録されている動画ファイルが存在するか確認
		//	foreach (var item in pairsModel.Items)
		//	{
		//		var exists = rearMovs.Where(x => x.Contains(item.SourceFile)).FirstOrDefault();

		//		if (exists == null)
  //                  Log.Warning($"DirectionConvert[{item.No}]: 同一動画ファイル名なし {item.SourceFile}");
		//	}


		//	// パスを変更しておく
		//	pairsModel.PairsRoot = parent;

		//	Log.Info($"Start Convert");

  //          // リアに変換するときはアノテーションを左右対称に変更
  //          foreach (var item in pairsModel.Items)
		//	{
  //              if (direct == DirectFlg.Side)
  //              {
  //                  // TODO: TimePlayとTimeTargetの時刻を同じにする
  //                  // TODO: ファイルが変わってしまうことがあり得る

  //              }

  //              if (direct == DirectFlg.Rear)
  //              {
		//			try
		//			{
		//				Log.Info($"------------------------");
  //                      Log.Info($"DirectionConvert[{item.No}]: TimePlay.Time   {item.TimePlay.Time.ToString(Define.DateTimeFormat)}");
  //                      Log.Info($"DirectionConvert[{item.No}]: TimeTarget.Time {item.TimeTarget.Time.ToString(Define.DateTimeFormat)}");

  //                      // 全景と附属物の時刻に差があるとき
  //                      if (item.TimePlay.Time != item.TimeTarget.Time)
		//				{
  //                          Log.Info($"DirectionConvert[{item.No}]: not same time");

  //                          // 附属物の位置と全景の位置の時間差を取得（ミリ秒は切り捨て）
  //                          TimeSpan diff = item.TimeTarget.Time - item.TimePlay.Time;

  //                          // TimePlayに入れる時刻を求めておく
  //                          DateTime tmpDateTime = item.TimeTarget.Time + diff;

		//					// 動画を探す
  //                          string newMov = SearchMovs(rearMovs, tmpDateTime);
		//					if (newMov != string.Empty)
		//					{
  //                              Log.Warning($"DirectionConvert[{item.No}]: TimeTargetとTimePlayの差分で動画を発見");

  //                              // 他の動画の時間内に収まるときはSourceFileも更新
  //                              item.SourceFile = Path.GetFileName(newMov);
  //                              Log.Info($"DirectionConvert[{item.No}]: SourceFile {item.SourceFile}");

		//						if (item.SourceFile != item.DirectionList[0].SourceFile)
		//						{
		//							item.DirectionList[0].SourceFile = item.SourceFile;
  //                                  Log.Info($"DirectionConvert[{item.No}]: item.DirectionList[0].SourceFile {item.DirectionList[0].SourceFile}");
  //                              }

  //                              // TimePlayを変える
  //                              item.TimePlay.Time = tmpDateTime;
  //                              Log.Info($"DirectionConvert[{item.No}]: TimePlay.Time   {item.TimePlay.Time.ToString(Define.DateTimeFormat)}");

		//						// マージしたときにTimePlayはフロントに置き換わるので
		//						// TimePlay.Lat/Lngは変更せずにいとく
  //                          }
		//					else
		//					{
  //                              // どの動画にも収まらないときは元のTimePlayで探す
  //                              // TimeTargetだと収まらない可能性あり？のためTimePlayにしておく

  //                              Log.Warning($"DirectionConvert[{item.No}]: 該当動画ファイルなし");
  //                              Log.Warning($"DirectionConvert[{item.No}]: TimePlayで動画を探索");

  //                              newMov = SearchMovs(rearMovs, item.TimePlay.Time);
		//						if (newMov != string.Empty)
		//						{
  //                                  Log.Warning($"DirectionConvert[{item.No}]: TimePlayで動画を発見");

  //                                  // 他の動画の時間内に収まるときはSourceFileも更新
  //                                  item.SourceFile = Path.GetFileName(newMov);
		//							Log.Info($"DirectionConvert[{item.No}]: SourceFile {item.SourceFile}");
		//							Log.Info($"DirectionConvert[{item.No}]: TimePlay.Time   {item.TimePlay.Time.ToString(Define.DateTimeFormat)}");

  //                                  if (item.SourceFile != item.DirectionList[0].SourceFile)
  //                                  {
  //                                      item.DirectionList[0].SourceFile = item.SourceFile;
  //                                      Log.Info($"DirectionConvert[{item.No}]: item.DirectionList[0].SourceFile {item.DirectionList[0].SourceFile}");
  //                                  }

		//							// TimeTargetとTimePlayの差分で発見できてないのでTimePlay.Timeは変えない
  //                              }
		//						else
		//						{
  //                                  // どうしようもない･･･
  //                                  // フロントのときのファイル名が入るリア動画を探すことにしてみる

		//							Log.Warning($"DirectionConvert[{item.No}]: 該当動画ファイルなし（TimePlay）");
  //                                  Log.Warning($"DirectionConvert[{item.No}]: item.SourceFile({item.SourceFile})で動画を探索");

  //                                  newMov = SearchMovs(rearMovs, MovieFunctions.GetStartDate(item.SourceFile));
		//							if (newMov != string.Empty)
		//							{
  //                                      Log.Warning($"DirectionConvert[{item.No}]: フロントのときのファイル名で動画を発見");

  //                                      // SourceFileを更新しておかないとRowEnterのときにnullで落ちる
  //                                      item.SourceFile = Path.GetFileName(newMov);
  //                                      Log.Info($"DirectionConvert[{item.No}]: SourceFile {item.SourceFile}");
  //                                      Log.Info($"DirectionConvert[{item.No}]: TimePlay.Time   {item.TimePlay.Time.ToString(Define.DateTimeFormat)}");

  //                                      if (item.SourceFile != item.DirectionList[0].SourceFile)
  //                                      {
  //                                          item.DirectionList[0].SourceFile = item.SourceFile;
  //                                          Log.Info($"DirectionConvert[{item.No}]: item.DirectionList[0].SourceFile {item.DirectionList[0].SourceFile}");
  //                                      }

  //                                      // 動画をちゃんと発見できてないのでTimePlay.Timeは変えない
  //                                  }
  //                                  else
		//							{
		//								// さすがにもう無理？？
		//							}
		//						}
  //                          }
  //                      }

  //                      // TimePlayとTimeTargetの時刻に差がないとき
		//				// ミニマップから位置を登録されると時刻が同じになる
		//				else
  //                      {
  //                          Log.Info($"DirectionConvert[{item.No}]: same time");

  //                          // TimeTargeに一番近いKMLの時間を取得
  //                          DateTime nearestTime = GetNearestKmlTime(parent, item);

		//					if (nearestTime != DateTime.MinValue)
		//					{
  //                              // TimeTargetの時刻を更新
  //                              item.TimeTarget.Time = nearestTime;
  //                              Log.Info($"DirectionConvert[{item.No}]: TimeTarget.Time {item.TimeTarget.Time.ToString(Define.DateTimeFormat)}");
  //                          }
  //                      }
  //                  }
		//			catch (Exception e)
		//			{
  //                      Log.Error($"DirectionConvert[{item.No}]: TimePlay変換エラー {e.Message}");
  //                  }


  //                  // 赤枠の位置を変える
  //                  try
		//			{
		//				Log.Info($"DirectionConvert[{item.No}]: " +
  //                          $"{item.Annotation.Rect.X}, {item.Annotation.Rect.Y}, " +
  //                          $"{item.Annotation.Rect.Size.Width}, {item.Annotation.Rect.Size.Height}");


		//				// 倍率から座標を戻す
		//				Point anoTopLeft = new Point
		//				{
		//					X = (int)(item.Annotation.Rect.Location.X * item.Annotation.Ratio),
		//					Y = (int)(item.Annotation.Rect.Location.Y * item.Annotation.Ratio),
		//				};

		//				Size anoSize = new Size
		//				{
		//					Width = (int)(item.Annotation.Rect.Size.Width * item.Annotation.Ratio),
		//					Height = (int)(item.Annotation.Rect.Size.Height * item.Annotation.Ratio),
		//				};

		//				Point anoTopRight = new Point
		//				{
		//					X = anoTopLeft.X + anoSize.Width,
		//					Y = anoTopLeft.Y
		//				};

		//				// 動画が 2560ｘ1440 である前提で反転
		//				Point axisymmetry = anoTopLeft;
		//				if (anoTopLeft.X < 1280 && anoTopRight.X < 1280)
		//				{
		//					axisymmetry.X = 1280 + (1280 - (anoTopLeft.X + anoSize.Width));
		//				}
		//				else if (anoTopLeft.X < 1280 && 1280 < anoTopRight.X)
		//				{
		//					axisymmetry.X = 1280 - ((anoTopLeft.X + anoSize.Width) - 1280);
		//				}
		//				else if (1280 < anoTopLeft.X && 1280 < anoTopRight.X)
		//				{
		//					axisymmetry.X = 1280 - (anoTopLeft.X - 1280) - anoSize.Width;
		//				}
		//				else
		//				{
		//					continue;
		//				}

		//				// 倍率を戻す
		//				item.Annotation.Rect = new Rectangle
		//				{
		//					X = (int)(axisymmetry.X / item.Annotation.Ratio),
		//					Y = item.Annotation.Rect.Location.Y,
		//					Size = item.Annotation.Rect.Size,
		//				};

  //                      Log.Info($"DirectionConvert[{item.No}]: " +
  //                          $"{item.Annotation.Rect.X}, {item.Annotation.Rect.Y}, " +
  //                          $"{item.Annotation.Rect.Size.Width}, {item.Annotation.Rect.Size.Height}");
  //                  }
		//			catch (Exception e)
		//			{
		//				Log.Error($"DirectionConvert[{item.No}]: 座標値エラー {e.Message}");
		//			}


		//			// DirectionListを更新
		//			try
		//			{
		//				// 念のためフロントか確認
		//				if (item.DirectionList[0].DirectionNo.Substring(9, 1) == "F")
		//				{
		//					// Parent
		//					Log.Info($"Parent: {item.DirectionList[0].Parent} ->");
  //                          item.DirectionList[0].Parent = parent;
  //                          Log.Info($"Parent: {item.DirectionList[0].Parent}");

  //                          // DirectionNo
  //                          Log.Info($"DirectionNo: {item.DirectionList[0].DirectionNo} ->");
  //                          item.DirectionList[0].DirectionNo = item.DirectionList[0].DirectionNo.Substring(0, 8) + "R";
  //                          Log.Info($"DirectionNo: {item.DirectionList[0].DirectionNo}");
  //                      }
		//			}
		//			catch (Exception e)
		//			{
  //                      Log.Error($"DirectionConvert[{item.No}]: DirectionListエラー {e.Message}");
  //                  }
		//		}
  //          }

  //          // 最後に保存する
  //          try
		//	{
		//		string parentName = Path.GetFileName(parent);
		//		string saveJson = Path.Combine(parent, $"{parentName}.json");
		//		SavePairsModel(pairsModel, saveJson);
		//	}
  //          catch (Exception e)
  //          {
  //              Log.Error($"DirectionConvert 保存エラー: {e.Message}");
		//		return;
  //          }


		//	// NOTE: 動画ファイル名.jsonも変換が必要か？
		//	// 一番最初に使うだけなので想定しないことにする

		//	System.Windows.Forms.MessageBox.Show("変換が完了しました");

  //          Log.Info($"DirectionConvert 変換が完了しました。");
  //          return;
  //      }


		///// <summary>
		///// 引数の動画リストから引数の時刻が該当する動画ファイルを返す
		///// </summary>
		///// <param name="movs"></param>
		///// <param name="tmpDateTime"></param>
		///// <returns></returns>
		//private string SearchMovs(List<string> movs, DateTime tmpDateTime)
		//{
		//	foreach (var mov in movs)
		//	{
		//		// 動画の開始・終了時刻
		//		DateTime startDate = MovieFunctions.GetStartDate(mov);
  //              DateTime endDate = MovieFunctions.GetEndDate(mov);
		//		Log.Info($"SearchMovs: {startDate} {endDate}");

		//		if (endDate == DateTime.MinValue)
		//			return string.Empty;

		//		if (startDate <= tmpDateTime && tmpDateTime <= endDate)
		//		{
		//			Log.Info($"SearchMovs: {tmpDateTime} OK");
		//			return mov;
		//		}
		//		else
		//		{
  //                  Log.Warning($"SearchMovs: {tmpDateTime} NG");
  //                  startDate = endDate;
		//		}
		//	}

  //          Log.Warning($"SearchMovs: {tmpDateTime} None");
  //          return string.Empty;
		//}


  //      public DateTime GetNearestKmlTime(string root, SignItem item)
  //      {
  //          // sourceFileに該当するKML、その前後のKMLを取得
  //          List<string> kmlFiles = SearchKmls(root, item.SourceFile);

  //          if (kmlFiles.Count == 0)
  //              Log.Warning($"DirectionConvert[{item.No}]: 該当KMLなし {item.SourceFile}");

  //          // TimeTargeに一番近いKMLの時間を取得
  //          DateTime nearestTime = SearchNearestKmlTime(kmlFiles, item.TimeTarget);

  //          if (nearestTime == DateTime.MinValue)
  //          {
  //              // 一番近いKMLの時刻が取得できないことは起きない
  //          }

  //          // TimeTargetの時刻を更新
  //          return nearestTime;
  //      }


  //      public DateTime GetNearestKmlTime(string root, SignItem item, LatLng tmpPoint)
  //      {
  //          // sourceFileに該当するKML、その前後のKMLを取得
  //          List<string> kmlFiles = SearchKmls(root, item.SourceFile);

  //          if (kmlFiles.Count == 0)
  //              Log.Warning($"DirectionConvert[{item.No}]: 該当KMLなし {item.SourceFile}");

  //          // TimeTargeに一番近いKMLの時間を取得
  //          DateTime nearestTime = SearchNearestKmlTime(kmlFiles, tmpPoint);

  //          if (nearestTime == DateTime.MinValue)
  //          {
  //              // 一番近いKMLの時刻が取得できないことは起きない
  //          }

  //          // TimeTargetの時刻を更新
  //          return nearestTime;
  //      }

  //      private List<string> SearchKmls(string root, string sourceFile)
  //      {
  //          // 返却用
  //          List<string> res = new List<string>();


  //          // ファイル名を取得
  //          string name = Path.GetFileNameWithoutExtension(sourceFile);

  //          // kmlファイルのリスト作成
  //          List<string> kmls = KmlFunctions.GetKmlFileList(root);
  //          if (kmls.Count == 0) return res;

  //          // 動画ファイルのインデックスを取得
  //          string kml = kmls.Where(x => x.Contains(name)).FirstOrDefault();
  //          if (kml == null) return res;

  //          // 該当のKMLを追加
  //          res.Add(kml);

  //          // KMLが1つしかなければ返却
  //          if (kmls.Count == 1) return res;

  //          // 該当のインデックスを取得
  //          int index = kmls.IndexOf(kml);

  //          if (index == 0)
  //          {
  //              // 後のKMLを追加
  //              res.Add(kmls[index + 1]);
  //          }
  //          else if (index == kmls.Count - 1)
  //          {
  //              // 前のKMLを追加
  //              res.Add(kmls[index - 1]);
  //          }
  //          else
  //          {
  //              // 前後のKMLを追加
  //              res.Add(kmls[index - 1]);
  //              res.Add(kmls[index + 1]);
  //          }

  //          // ソートして返却
  //          res = res.OrderBy(x => Regex.Replace(x, @"[^0-9]", "")).ToList();
  //          return res;
  //      }


  //      /// <summary>
  //      /// 一番近いKMLの時刻を返す
  //      /// </summary>
  //      /// <param name="kmlFiles"></param>
  //      /// <param name="tmpLatLng"></param>
  //      /// <returns></returns>
  //      private DateTime SearchNearestKmlTime(List<string> kmlFiles, LatLng tmpLatLng)
		//{
		//	KmlFunctions kmlfunc = new KmlFunctions();
		//	List<SearchKmlItem> items = new List<SearchKmlItem>();

		//	try
		//	{
		//		foreach (var file in kmlFiles)
		//		{
		//			// KML読込
		//			List<KmlModel> kmls = kmlfunc.GetAllKmls(file);

		//			foreach (var kml in kmls)
		//			{
		//				// 距離算出
		//				double[] vals = GisFunctions.vincentyInv(tmpLatLng, new LatLng(kml.Lat, kml.Lng));
		//				//Debug.WriteLine($"> {kml.When}: {vals[1]}");

		//				items.Add(new SearchKmlItem
		//				{
		//					Distance = vals[1],
		//					Time = kml.When,
		//				});
		//			}
		//		}
		//	}
		//	catch (Exception e)
		//	{
  //              Log.Error($"SearchNearestKmlTime エラー: {e.Message}");
  //              return DateTime.MinValue;
  //          }

		//	// 一番近いKMLを取得
		//	var min = items.OrderBy(x => x.Distance).FirstOrDefault();

		//	if (min == null) return DateTime.MinValue;

		//	Log.Info($"NearestKml[{items.IndexOf(min)}] {min.Time}");

		//	// 一番近いKMLの時刻を返す
		//	return min.Time;
		//}


		//public void MergeJsons(string file1, string file2, DirectFlg direct, Version currentVersion)
		//{
  //          Log.Info("MergeJsons Start");
  //          Log.Info($"src: {file1}");
  //          Log.Info($"add: {file2}");
  //          Log.Info($"direct: {direct}");

		//	// 読込
		//	bool cancel;
  //          var file1model = LoadPairsModel(file1, out cancel);
  //          var file2model = LoadPairsModel(file2, out cancel);

  //          try
  //          {
  //              if (file1model.Version != currentVersion)
  //              {
  //                  file1model = PairsVersionFunctions.AjustVersion(file1model, currentVersion);
  //                  file1model.Version = currentVersion;
  //              }
  //              if (file2model.Version != currentVersion)
  //              {
  //                  file2model = PairsVersionFunctions.AjustVersion(file2model, currentVersion);
  //                  file2model.Version = currentVersion;
  //              }
  //          }
  //          catch (Exception e)
  //          {
  //              Log.Error($"MergeJsons バージョン更新エラー: {e.Message}");
  //              return;
  //          }


		//	try
		//	{
  //              Log.Info("----------");

  //              foreach (var item in file2model.Items)
		//		{
		//			StringBuilder sb = new StringBuilder();

		//			// マージ先のファイルから同じ管理番号のアイテムを拾う
  //                  var src = file1model.Items.Where(x => x.No.Equals(item.No)).FirstOrDefault();
		//			if (src != null)
		//			{
		//				// DirectionListに追加する
		//				src.DirectionList.Add(item.DirectionList[0]);
  //                      Log.Info($"{src.No}: add {item.DirectionList[0].DirectionNo}");
  //                  }
  //              }
		//	}
		//	catch (Exception e)
		//	{
  //              Log.Error($"MergeJsons マージエラー: {e.Message}");
  //              return;
  //          }

  //          Log.Info("MergeJsons Done");
  //      }
	}

	public class SearchKmlItem
	{
		public double Distance { get; set; } = -1;
		public DateTime Time { get; set; } = new DateTime();
	}
}
