using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsiderGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
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
