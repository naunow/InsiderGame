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
        private List<Player> _setRolePlayers;

        public SetWord(List<Player> setRolePlayers)
        {
            InitializeComponent();

            _setRolePlayers = setRolePlayers;

            var masterName = _setRolePlayers.Where(x => x.Role == "Master").Select(x=>x.Name).FirstOrDefault();
            this.masterJapaneseLabel.Text = $"マスターは {masterName} です！";
            this.masterEnglishLabel.Text = $"Master is {masterName} !";
        }

        private void ChooseWord(object sender, EventArgs e)
        {
            this.JapaneseWord.Text = "りんご";
            this.EnglishWord.Text = "Apple";


        }
    }
}