using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsiderGame
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string WordInJapanese { get; set; }

        public string WordInEnglish { get; set; }
    }
}
