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
    public partial class SetWord : ContentPage
    {
        private GameSet _gameSet = new GameSet{ };
        private Word _word = new Word { };

        public SetWord(GameSet gameSet)
        {
            InitializeComponent();

            _gameSet.playerList = gameSet.playerList;

            var masterName = _gameSet.playerList.Where(x => x.Role == "Master").Select(x=>x.Name).FirstOrDefault();
            this.masterJapaneseLabel.Text = $"マスターは {masterName} です！";
            this.masterEnglishLabel.Text = $"MASTER IS {masterName} !";

            GetWord();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // ナビゲーションバーの色変更
            var mdPage = Application.Current.MainPage as NavigationPage;
            mdPage.BarBackgroundColor = Color.Black;
        }

        /// <summary>
        /// マスターがお題の設定をする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseWord(object sender, EventArgs e)
        {
            GetWord();
        }

        /// <summary>
        /// DBからお題をランダムで取得する
        /// </summary>
        private void GetWord()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            var words = conn.Table<Word>().ToList();
            var randomIndexNumber = new Random().Next(0, words.Count());

            this.JapaneseWord.Text = words[randomIndexNumber].WordInJapanese;
            this.EnglishWord.Text = words[randomIndexNumber].WordInEnglish;

            // 設定したお題を保存する
            _word.WordInEnglish = words[randomIndexNumber].WordInEnglish;
            _word.WordInJapanese = words[randomIndexNumber].WordInJapanese;
        }

        /// <summary>
        /// 役職の確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CheckRole(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Role(_gameSet, _word), this);
            await Navigation.PopAsync();
        }

        private void ChooseWord_Button(object sender, EventArgs e)
        {
            this.ChooseWordButton.IsVisible = false;
            this.WordPanel.IsVisible = true;
            this.ButtonsGrid.IsVisible = true;
        }
    }
}