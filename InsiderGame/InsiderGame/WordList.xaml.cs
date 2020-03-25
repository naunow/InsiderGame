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

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var dataUtil = new DataUtil();
            var wordData = dataUtil.GetDefaultWordData();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.DropTable<Word>();
                conn.CreateTable<Word>();
                conn.InsertAll(wordData);

                wordListView.ItemsSource = conn.Table<Word>().ToList();
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewWord());
        }
    }
}