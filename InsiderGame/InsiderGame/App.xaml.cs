using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsiderGame
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = Color.FromHex("EE0000");
            //nav.Opacity = 0;
            nav.BarTextColor = Color.White;
            MainPage = nav;

        }

        public App(string DB_Path)
        {
            InitializeComponent();
            DB_PATH = DB_Path;

            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = Color.FromHex("EE0000");
            nav.BarTextColor = Color.White;
            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
