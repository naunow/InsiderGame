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
        /// <summary>
        /// デフォルトワードリストの取得
        /// </summary>
        /// <returns></returns>
        static public List<Word> GetDefaultWordData()
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

        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="obj">シリアライズしたいオブジェクト</param>
        /// <returns></returns>
        static public string Silialize(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}
