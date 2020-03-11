using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsiderGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordList : ContentPage
    {
        public WordList()
        {
            InitializeComponent();

            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.DropTable<Word>();
                conn.CreateTable<Word>();

                var words = new List<Word>()
                {
                    new Word(){WordInEnglish = "Orange", WordInJapanese = "みかん"},
                    new Word(){WordInEnglish = "Peach", WordInJapanese = "もも"},
                };

                conn.InsertAll(words);

                wordListView.ItemsSource = words;
            }

        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }
    }
}