using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeAichanJson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //続行確認
            Console.WriteLine("以下のフォルダのJsonファイルをマージします。よろしいですか？");
            Console.WriteLine("フォルダ名＝" + Environment.CurrentDirectory);
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
            string[] fileList = Directory.GetFiles(Environment.CurrentDirectory, "*.json");


            //何もなかったら終了
            if (fileList.Length == 0)
            {
                Console.WriteLine("jsonファイルが無いので終了します。何かキーを押してください。");
                Console.ReadLine();
                return;
            }

            PairsModel masterModel = null;

            //ファイル繰り返し
            foreach (string filepath in fileList)
            {
                string name = Path.GetFileName(filepath);
                if(name == "mergeJson.json")
                {
                    Console.WriteLine(name + "はスキップします。");
                    continue;
                }

                Console.WriteLine(name+"を処理中・・・");
                bool cancel;
                PairsModel pairs = PairsFunctions.LoadPairsModel(filepath, out cancel);

                if(pairs == null)
                {
                    continue;
                }

                if (masterModel == null)
                {
                    masterModel = pairs;
                    continue;
                }
                else
                {

                    pairs.Items.ForEach(pair =>
                    {
                        var v = masterModel.Items.Find(mastar => mastar.No == pair.No);
                        if (v == null)
                        {
                            masterModel.Items.Add(pair);
                        }
                        else
                        {
                            Console.WriteLine("重複あり⇒ファイル名：" + name + "、番号：" + pair.No);
                        }
                    });
                }

            }



            string json = JsonConvert.SerializeObject(masterModel, Formatting.Indented);
            string saveJson = Path.Combine(Environment.CurrentDirectory, "mergeJson.json");
            using (StreamWriter sw = new StreamWriter(saveJson, false, Define.UTF))
            {
                sw.Write(json);
            }

            Console.WriteLine("マージ完了　合計："+masterModel.Items.Count.ToString()+"件");
            Console.WriteLine();
            Console.Write("キーを押すと終了します。：");
            Console.ReadLine();
        }
    }
}
