using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace InsiderGame.Tests
{
    public class DataUtilTests
    {
        string FULL_PATH;

        public DataUtilTests()
        {
            string fileName = "C://Users//nauno//source//repos//InsiderGame//InsiderGame//InsiderGame//Assets//initialWordData.json";
            //string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileLocation = string.Empty;
            FULL_PATH = Path.Combine(fileLocation, fileName);
        }

        [Fact(DisplayName = "Jsonから初期データ取得")]
        public void GetDefaultWordDataTest()
        {
            DataUtil.GetDefaultWordData(FULL_PATH);
        }

        [Fact]
        public void SerializeTest()
        {
            DataUtil.Silialize();
        }

    }
}
