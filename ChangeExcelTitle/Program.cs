using System;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace ChangeExcelTitle
{
    /// <summary>
    /// 実行プログラム
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// エクセル調書タイトル変換
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //続行確認
            Console.WriteLine("以下のフォルダのExcel調書を変換します。よろしいですか？");
            Console.WriteLine("フォルダ名＝" + Environment.CurrentDirectory);
            Console.WriteLine();
            Console.WriteLine("※注意！！Excelはすべて閉じてください！！");
            Console.Write("y=続行、n=終了：");

            //yかnが入力されるまで繰り返し
            while (true)
            {

                //入力文字
                string yn = Console.ReadLine();

                if (yn == "y")
                {

                    //yなら続行
                    break;
                }
                else if (yn == "n")
                {
                    //nならリターン
                    Console.Write("終了します。何かキーを押してください。：");
                    Console.ReadLine();
                    return;
                }
            }

            //フォルダ内のエクセルファイル取得
            string[] fileList = Directory.GetFiles(Environment.CurrentDirectory, "*.xlsx");

            //何もなかったら終了
            if(fileList.Length == 0)
            {
                Console.WriteLine("Excelファイルが無いので終了します。何かキーを押してください。");
                Console.ReadLine();
                return;
            }

            //bkフォルダ取得
            string bkFolder = Path.Combine(Environment.CurrentDirectory, "bk");

            if(!Directory.Exists(bkFolder))
            {
                //bkフォルダが無ければ作る
                Console.WriteLine("bkフォルダを作成します。");
                Console.WriteLine();
                Directory.CreateDirectory(bkFolder);
            }

            int cnt = 0;

            //ファイル繰り返し
            foreach (string filepath in fileList)
            {

                //ファイル名のみ
                string filename = Path.GetFileName(filepath);

                //ファイル開く
                using (ExcelPackage package = new ExcelPackage(filepath))
                {

                    //施設諸元のシートを取得
                    ExcelWorksheet sh = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "点検表（施設諸元）");

                    //無ければ点検調書ではない
                    if(sh == null)
                    {
                        Console.WriteLine("「{0}」は点検表ではないので飛ばします。", filename);
                        Console.WriteLine();
                        continue;
                    }

                    //タイトルA1セルを取得
                    string title = sh.Cells["A1"].Value?.ToString();

                    //点検表（施設諸元）で無ければ点検調書ではない
                    if (title != "点検表（施設諸元）")
                    {
                        Console.WriteLine("「{0}」は点検表ではないので飛ばします。", filename);
                        Console.WriteLine();
                        continue;
                    }

                    //種別取得
                    string type = sh.Cells["B2"].Value?.ToString();

                    //種別が無ければ飛ばす
                    if (string.IsNullOrEmpty(type))
                    {
                        Console.WriteLine("「{0}」は種別が未入力なので飛ばします。", filename);
                        Console.WriteLine();
                        continue;
                    }

                    //この時点でバックアップ
                    //点検調書出なければｂｋしない
                    File.Copy(filepath, Path.Combine(bkFolder, DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename));

                    //道路照明施設なら点検表（道路照明）
                    if (type == "道路照明施設")
                    {
                        title = string.Format("点検表（{0}）", "道路照明");
                    }
                    else if(type == "カーブミラー")
                    {
                        //カーブミラーなら
                        title = "その他（カーブミラー）";
                    }
                    else
                    {
                        //それ以外
                        title = string.Format("点検表（{0}）", type);
                    }

                    //タイトル変換
                    sh.Cells["A1"].Value = title;
                    //保存
                    package.Save();

                    //変換したよ
                    Console.WriteLine("{0}を変換しました。タイトル={1}", filename, title);
                    Console.WriteLine();
                    cnt++;

                }
            }

            //サマリ表示して終了
            Console.WriteLine("{0}件の点検調書を変換しました。", cnt);
            Console.WriteLine();
            Console.Write("キーを押すと終了します。：");
            Console.ReadLine();


        }
    }
}
