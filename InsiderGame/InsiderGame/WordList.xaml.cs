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

            using (SQLite.SQLiteConnection db = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                db.DropTable<Word>();
                db.CreateTable<Word>();
                db.InsertAll(wordData);

                wordListView.ItemsSource = db.Table<Word>().ToList();
            }
        }

        /// <summary>
        /// ワード追加ボタン(+)を押下したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewWord());
        }
    }
}