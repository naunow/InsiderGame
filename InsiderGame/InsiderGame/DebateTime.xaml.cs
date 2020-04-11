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
    public partial class DebateTime : ContentPage
    {
        private GameSet _gameSet;
        private Timer _timer;
        private Word _word;

        public DebateTime(GameSet gameset, Timer timer, Word word)
        {
            InitializeComponent();

            _gameSet = gameset;
            _timer = timer;
            _word = word;

            _timer.TimeSpan = (new TimeSpan(0, 5, 0) - _timer.TimeSpan);
            this.Seconds.Text = (Convert.ToInt32(_timer.Seconds) - 1).ToString("00");
            this.Minutes.Text = _timer.Minutes;

            SetUp();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // ナビゲーションバーの色変更
            var mdPage = Application.Current.MainPage as NavigationPage;
            mdPage.BarBackgroundColor = Color.FromHex("EE0000");

            // お題の表示
            wordInJapanese.Text = _word.WordInJapanese;
            wordInEnglish.Text = _word.WordInEnglish;
        }

        private void SetUp()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                _timer.TimeSpan = (_timer.TimeSpan - new TimeSpan(0, 0, 1));

                countDown.BindingContext = _timer;
                this.Seconds.Text = _timer.Seconds;
                this.Minutes.Text = _timer.Minutes;

                return _timer.TimeSpan != TimeSpan.Zero;
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Result(_gameSet), this);
            await Navigation.PopAsync(false);
        }
    }
}