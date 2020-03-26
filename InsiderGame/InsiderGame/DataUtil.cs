using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace InsiderGame
{
    public class DataUtil
    {
        static string FULL_PATH;
        public DataUtil()
        {
            string fileName = "InsiderGame/Assets/initialWordData.json";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            FULL_PATH = Path.Combine(fileLocation, fileName);
        }

        public List<Word> GetDefaultWordData(string fullPath = "")
        {
            var words = new List<Word>();

            // アセンブリからファイル名を指定して読み込む
            var assembly = typeof(DataUtil).GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("InsiderGame.Assets.initialWordData.json"))
            using (StreamReader reader = new StreamReader(stream))
            {
                // Jsonファイルのデシリアライズ
                words = JsonConvert.DeserializeObject<List<Word>>(reader.ReadToEnd());
            }

            return words;
        }

        static public string Silialize(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}
