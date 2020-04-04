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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // ナビゲーションバーの色変更
            var mdPage = Application.Current.MainPage as NavigationPage;
            mdPage.BarBackgroundColor = Color.FromHex("EE0000");
        }

        private void SetUp()
        {
            var insider = _gameset.playerList.Single(x => x.Role == INSIDER);

            insiderName.Text = insider.Name;
            insiderImage.Source = ImageSource.FromResource("InsiderGame.Assets.blackInsiderImage.png");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
    }
}