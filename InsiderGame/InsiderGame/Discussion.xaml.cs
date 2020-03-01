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

        public Discussion(GameSet gameSet)
        {
            InitializeComponent();
            SetUp();

            _gameSet = gameSet;
        }

        private void SetUp()
        {
            Timer timer = new Timer();
            //DiscussionTimer.BindingContext = timer;
            //countDown.BindingContext = timer;
            timer.TimeSpan = new TimeSpan(0, 5, 0);
            var i = 0;
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                i += 1;
                var interval = (timer.TimeSpan - new TimeSpan(0, 0, i));
                timer.Minutes = interval.Minutes.ToString();
                timer.Seconds = interval.Seconds.ToString("00");
                timer.Time = $"{timer.Minutes}:{timer.Seconds}";
                //DiscussionTimer.SetBinding(Label.TextProperty, "Minutes");
                //DiscussionTimer.SetBinding(Label.TextProperty, "Seconds");
                countDown.BindingContext = timer;

                return interval != TimeSpan.Zero;
            });
        }

        public class Timer
        {
            public TimeSpan TimeSpan { get; set; }

            public string Time { get; set; }

            public string Minutes { get; set; }
            public string Seconds { get; set; }

        }
    }
}