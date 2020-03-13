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
    public partial class NewWord : ContentPage
    {
        public NewWord()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Word>();

                var word = new Word()
                {
                    WordInEnglish = englishEntry.Text,
                    WordInJapanese = japaneseEntry.Text,
                };

                var numberOfRows = conn.Insert(word);
                if(numberOfRows > 0)
                {
                    DisplayAlert("Success", $"{japaneseEntry.Text}:{englishEntry.Text} が登録されました！", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "登録に失敗しました……", "OK");
                }
            }
        }
    }
}