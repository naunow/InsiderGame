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
            //var date = Convert.ToDateTime("2020/3/2");
            //var time = date - DateTime.Now;
            //Timer timer = new Timer()
            //{
            //    TimeSpan = time,
            //};
            Timer timer = new Timer();
            DiscussionTimer.BindingContext = timer;
            //timer.TimeSpan = TimeSpan.FromSeconds(10);
            var fiveMinutes = new TimeSpan(0, 5, 0);
            var i = 0;
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                i += 1;
                var interval = (fiveMinutes - new TimeSpan(0, 0, i));
                timer.Minutes = interval.Minutes.ToString();
                timer.Seconds = interval.Seconds.ToString("00");
                timer.Time = $"{timer.Minutes}:{timer.Seconds}";
                //timer.Seconds = (DateTime.Now.Second - fiveMinutes).ToString();
                DiscussionTimer.SetBinding(Label.TextProperty, "Time");
                return true;
            });
            //timer.Minutes = "6:00";

        }

        public class Timer
        {
            //public TimeSpan TimeSpan { get; set; }

            public string Time { get; set; }

            public string Minutes { get; set; }
            public string Seconds { get; set; }

        }
    }
}