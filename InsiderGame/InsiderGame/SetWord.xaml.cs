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
        //private List<Player> _setRolePlayers;

        public SetWord(GameSet gameSet)
        {
            InitializeComponent();

            _gameSet.playerList = gameSet.playerList;

            var masterName = _gameSet.playerList.Where(x => x.Role == "Master").Select(x=>x.Name).FirstOrDefault();
            this.masterJapaneseLabel.Text = $"マスターは {masterName} です！";
            this.masterEnglishLabel.Text = $"Master is {masterName} !";
        }

        /// <summary>
        /// マスターがお題の設定をする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseWord(object sender, EventArgs e)
        {
            // TODO:実際にはDBから情報を持ってきてランダムで表示させる
            this.JapaneseWord.Text = "りんご";
            this.EnglishWord.Text = "Apple";
        }

        /// <summary>
        /// 役職の確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CheckRole(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Role(_gameSet), this);
            await Navigation.PopAsync();

            //await Navigation.PushAsync(new Role(_gameSet));
        }
    }
}