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

            var topImage = Component.Image("InsiderGame.Assets.blackInsiderImage.png", 200, marginTop: 120);
            var titleLabel = Component.Title("INSIDER");

            var setWordButton = Component.WideBlackButton("単語を登録する", "Set new Words");
            setWordButton.Margin = new Thickness(60, 0);
            setWordButton.Clicked += SetWordButton_Clicked;

            var playButton = Component.WideBlackButton("プレイ", "Play");
            playButton.Margin = new Thickness(60, 36, 60, 80);
            playButton.Clicked += PlayButton_Clicked;

            var stackLayout = Component.RedStackLayout();

            stackLayout.Children.Add(topImage);
            stackLayout.Children.Add(titleLabel);
            stackLayout.Children.Add(setWordButton);
            stackLayout.Children.Add(playButton);
            Content = stackLayout;
        }

        /// <summary>
        /// プレイボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PlayButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Setting());
        }

        /// <summary>
        /// 単語登録ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetWordButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WordList());
        }
    }
}
