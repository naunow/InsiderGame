using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsiderGame
{
    public class Component
    {
        public static Button BlackButton(string text, double marginLeft = 60, double marginTop = 0, double marginRight = 60, double marginBottom = 80, int width = 246)
        {
            Button blackButton = new Button()
            {
                Text = text,
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                IsEnabled = true,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                CornerRadius = 10,
                WidthRequest = width,
                Margin = new Thickness(marginLeft, marginTop, marginRight, marginBottom),

            };

            return blackButton;
        }
    }
}
