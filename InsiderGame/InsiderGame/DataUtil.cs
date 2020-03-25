using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (string.IsNullOrEmpty(fullPath))
            {
                fullPath = FULL_PATH;
            }

            // Jsonファイルのデシリアライズ
            var words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText(fullPath));

            return words;
        }

        static public string Silialize(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}
