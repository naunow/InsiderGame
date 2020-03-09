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

        public DebateTime(GameSet gameset, Timer timer)
        {
            InitializeComponent();

            _gameSet = gameset;
            _timer = timer;

            SetUp();
        }

        private void SetUp()
        {
            var i = 0;
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                _timer.TimeSpan = (_timer.TimeSpan - new TimeSpan(0, 0, 1));
                //timer.Minutes = interval.Minutes.ToString();
                //timer.Seconds = interval.Seconds.ToString("00");
                //timer.Time = $"{timer.Minutes}:{timer.Seconds}";
                countDown.BindingContext = _timer;
                this.Seconds.Text = _timer.Seconds;
                this.Minutes.Text = _timer.Minutes;

                return _timer.TimeSpan != TimeSpan.Zero;
            });
        }

    }
}