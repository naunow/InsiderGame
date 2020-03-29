using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace InsiderGame.Tests
{
    public class DataUtilTests
    {
        [Fact(DisplayName = "Jsonから初期データ取得")]
        public void GetDefaultWordDataTest()
        {
            var words = DataUtil.GetDefaultWordData();

            List<Word> expectedWords = new List<Word>()
            {
                new Word()
                {
                    Id = 0,
                    WordInEnglish = "peach",
                    WordInJapanese = "もも",
                },
                new Word()
                {
                    Id = 0,
                    WordInEnglish = "apple",
                    WordInJapanese = "りんご",
                },
            };

            Assert.Equal(expectedWords[0].WordInEnglish, words[0].WordInEnglish);
            Assert.Equal(expectedWords[0].WordInJapanese, words[0].WordInJapanese);
            Assert.Equal(expectedWords[1].WordInEnglish, words[1].WordInEnglish);
            Assert.Equal(expectedWords[1].WordInJapanese, words[1].WordInJapanese);
        }

        [Fact(DisplayName ="シリアライズ")]
        public void SerializeTest()
        {
            List<Word> words = new List<Word>()
            {
                new Word()
                {
                    Id = 0,
                    WordInEnglish = "peach",
                    WordInJapanese = "もも",
                },
                new Word()
                {
                    Id = 0,
                    WordInEnglish = "apple",
                    WordInJapanese = "りんご",
                },
            };

            var json = DataUtil.Silialize(words);
            string expectedJson = "[{\"Id\":0,\"WordInJapanese\":\"もも\",\"WordInEnglish\":\"peach\"},{\"Id\":0,\"WordInJapanese\":\"りんご\",\"WordInEnglish\":\"apple\"}]";

            Assert.Equal(expectedJson, json);
        }

    }
}
