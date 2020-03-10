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
    public partial class Result : ContentPage
    {
        private readonly GameSet _gameset;

        const string INSIDER = "Insider";

        public Result(GameSet gameSet)
        {
            InitializeComponent();
            _gameset = gameSet;

            SetUp();
        }

        private void SetUp()
        {
            var insider = _gameset.playerList.Single(x => x.Role == INSIDER);

            insiderName.Text = insider.Name;
            insiderImage.Source = ImageSource.FromResource("InsiderGame.Assets.whiteInsiderImage.png");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}