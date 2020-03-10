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
        private Timer _timer;
        private bool isStoppedTimer = true;

        public Discussion(GameSet gameSet)
        {
            InitializeComponent();
            SetUp();

            _gameSet = gameSet;
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
            Navigation.InsertPageBefore(new DebateTime(_gameSet, _timer), this);
            await Navigation.PopAsync();
        }
    }
}