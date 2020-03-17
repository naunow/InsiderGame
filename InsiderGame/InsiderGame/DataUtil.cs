using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        static public List<Word> GetDefaultWordData(string FULL_PATH)
        {
            var words = new List<Word>();
            var jsonData = File.ReadAllText(FULL_PATH, System.Text.Encoding.GetEncoding(50220));
            
                // 変数 jsonData にファイルの内容を代入 
                //var jsonData = sr.ReadToEnd();

                // デシリアライズして words にセット              
                words = JsonConvert.DeserializeObject<List<Word>>(jsonData);           

            return words;
        }

        static public string Silialize()
        {
            List<Word> words = new List<Word>()
            {
                new Word()
                {
                    Id = 0,
                    WordInEnglish = "Peach",
                    WordInJapanese = "もも",
                },
                new Word()
                {
                    Id = 0,
                    WordInEnglish = "Apple",
                    WordInJapanese = "りんご",
                },
            };

            var json = JsonConvert.SerializeObject(words);

            return json;
        }
    }
}
