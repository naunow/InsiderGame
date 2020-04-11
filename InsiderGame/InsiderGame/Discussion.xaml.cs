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
    public partial class Discussion : ContentPage
    {
        private GameSet _gameSet;
        private Word _word;
        private Timer _timer;
        private bool isStoppedTimer = true;

        public Discussion(GameSet gameSet, Word word)
        {
            InitializeComponent();
            SetUp();
            _gameSet = gameSet;
            _word = word;
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
            Timer timer = new Timer();

            timer.TimeSpan = new TimeSpan(0, 5, 0);
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                timer.TimeSpan = (timer.TimeSpan - new TimeSpan(0, 0, 1));

                countDown.BindingContext = timer;
                this.Seconds.Text = timer.Seconds;
                this.Minutes.Text = timer.Minutes;
                _timer = timer;

                return timer.TimeSpan != TimeSpan.Zero && isStoppedTimer;
            });
        }       

        private async void Button_Clicked(object sender, EventArgs e)
        {
            isStoppedTimer = false;
            Navigation.InsertPageBefore(new DebateTime(_gameSet, _timer, _word), this);
            await Navigation.PopAsync(false);
        }
    }
}