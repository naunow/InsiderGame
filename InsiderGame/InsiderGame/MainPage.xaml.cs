using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsiderGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //InsiderImage.Source = ImageSource.FromResource("InsiderGame.Assets.blackInsiderImage.png");

            Label label = new Label()
            {
                Text = "INSIDER",
                FontSize = 40,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };

            //Button button = new Button()
            //{
            //    Text = "Set new words",
            //    BackgroundColor = Color.Black,
            //    TextColor = Color.White,
            //    IsEnabled = true,
            //    VerticalOptions = LayoutOptions.End,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    CornerRadius = 10,
            //    WidthRequest = 246,
            //    Margin = new Thickness(60,0),
            //};

            var button = Component.BlackButton("Set new Words", 60, 0, 60, 0);
            button.Clicked += SetWordButton_Clicked;

            //Button button2 = new Button()
            //{
            //    Text = "Play",
            //    BackgroundColor = Color.Black,
            //    TextColor = Color.White,
            //    IsEnabled = true,
            //    VerticalOptions = LayoutOptions.End,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    CornerRadius = 10,
            //    WidthRequest = 246,
            //    Margin = new Thickness(60, 36, 60, 80),
            //};
            //button2.Clicked += PlayButton_Clicked;

            var button2 = Component.BlackButton("Play2", marginTop: 36);
            button2.Clicked += PlayButton_Clicked;

            Image image = new Image()
            {
                HeightRequest = 200,
                Margin = new Thickness(0, 120, 0, 0),
                Source = ImageSource.FromResource("InsiderGame.Assets.blackInsiderImage.png"),
            };

            StackLayout stackLayout = new StackLayout()
            {
                BackgroundColor = Color.FromHex("EE0000"),
            };

            stackLayout.Children.Add(image);
            stackLayout.Children.Add(label);
            stackLayout.Children.Add(button);
            stackLayout.Children.Add(button2);
            Content = stackLayout;
        }

        private async void PlayButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Setting());
        }

        private void SetWordButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WordList());
        }
    }
}
