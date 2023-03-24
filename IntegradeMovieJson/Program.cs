using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntegradeMovieJson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //続行確認
            Console.WriteLine("以下のフォルダのJsonファイルのRootDirを書き換えます。よろしいですか？");
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

            string outPath = Path.Combine(Environment.CurrentDirectory, "out");

            Directory.CreateDirectory(outPath);

            //ファイル繰り返し
            foreach (string filepath in fileList)
            {

                WorkModel work = LoadWorkModel(filepath);

                if(work == null)
                {
                    continue;
                }
                work.RootDir = Environment.CurrentDirectory;
                string putFile = Path.Combine(outPath, Path.GetFileName(filepath));

                SaveModel(work, putFile);


            }

            Console.WriteLine("出力完了　合計：" + fileList.Length.ToString() + "件");
            Console.WriteLine();
            Console.Write("キーを押すと終了します。：");
            Console.ReadLine();
        }

        public static WorkModel LoadWorkModel(string file)
        {

            string load = "";
            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("UTF-8")))
            {
                load = sr.ReadToEnd();
            }

            WorkModel model = new WorkModel();
            try
            {
                model = JsonConvert.DeserializeObject<WorkModel>(load);
            }
            catch
            {
                Console.WriteLine("読込失敗 "+file);
                return null;
            }

            return model;
        }

        public static void SaveModel(WorkModel model, string file)
        {



            try
            {


                string json = JsonConvert.SerializeObject(model, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(file, false, Encoding.GetEncoding("UTF-8")))
                {
                    sw.Write(json);
                }

                Console.WriteLine("出力OK " + file);
            }
            catch
            {
                Console.WriteLine("読込失敗 " + file);

            }
        }
    }
}
