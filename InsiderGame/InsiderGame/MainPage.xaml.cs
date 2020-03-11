﻿using System;
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

            InsiderImage.Source = ImageSource.FromResource("InsiderGame.Assets.blackInsiderImage.png");

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
