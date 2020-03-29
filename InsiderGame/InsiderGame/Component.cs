using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsiderGame
{
    public class Component
    {
        const string RED = "EE0000";
        const string BLACK = "000000";

        /// <summary>
        /// デフォルトボタン
        /// </summary>
        /// <param name="japaneseText">日本語ボタンテキスト</param>
        /// <param name="englishText">英語ボタンテキスト</param>
        /// <param name="backGroundColor">ボタン背景色</param>
        /// <param name="textColor">ボタンテキスト色</param>
        /// <param name="width">ボタン幅</param>
        /// <returns></returns>
        private static Button Button(string japaneseText, string englishText, Color backGroundColor, Color textColor, double width)
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine(japaneseText);
            stringbuilder.Append(englishText);

            var text = stringbuilder.ToString();

            Button button = new Button()
            {
                Text = text,
                IsEnabled = true,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                CornerRadius = 10,
                BackgroundColor = backGroundColor,
                TextColor = textColor,
                WidthRequest = width,
            };

            return button;
        }

        #region 幅広のボタン
        /// <summary>
        /// 幅広のボタン(黒)
        /// </summary>
        /// <param name="japaneseText">日本語ボタンテキスト</param>
        /// <param name="englishText">英語ボタンテキスト</param>
        /// <returns></returns>
        public static Button WideBlackButton(string japaneseText, string englishText)
        {
            return Component.Button(japaneseText, englishText, Color.Black, Color.White, 246);
        }

        /// <summary>
        /// 幅広のボタン(白)
        /// </summary>
        /// <param name="japaneseText">日本語ボタンテキスト</param>
        /// <param name="englishText">英語ボタンテキスト</param>
        /// <returns></returns>
        public static Button WideWhiteButton(string japaneseText, string englishText)
        {
            return Component.Button(japaneseText, englishText, Color.White, Color.Black, 246);
        }
        #endregion

        #region 下付きボタン
        /// <summary>
        /// 下付きボタン(黒)
        /// </summary>
        /// <param name="japaneseText">日本語ボタンテキスト</param>
        /// <param name="englishText">英語ボタンテキスト</param>
        /// <returns></returns>
        public static Button BottomBlackButton(string japaneseText, string englishText)
        {
            var bottomButton = Component.WideBlackButton(japaneseText, englishText);
            bottomButton.Margin = new Thickness(0, 0, 0, 80);
            return bottomButton;
        }

        /// <summary>
        /// 下付きボタン(白)
        /// </summary>
        /// <param name="japaneseText">日本語ボタンテキスト</param>
        /// <param name="englishText">英語ボタンテキスト</param>
        /// <returns></returns>
        public static Button BottomWhiteButton(string japaneseText, string englishText)
        {
            var bottomButton = Component.WideWhiteButton(japaneseText, englishText);
            bottomButton.Margin = new Thickness(0, 0, 0, 80);
            return bottomButton;
        }
        #endregion

        /// <summary>
        /// TOPタイトルラベル
        /// </summary>
        /// <param name="title">タイトルテキスト</param>
        /// <returns></returns>
        public static Label Title(string title)
        {
            Label titleLabel = new Label()
            {
                Text = title,
                FontSize = 40,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };

            return titleLabel;
        }

        /// <summary>
        /// 画像表示
        /// </summary>
        /// <param name="imageSource">画像の格納場所(相対パス)</param>
        /// <param name="height"></param>
        /// <param name="marginLeft"></param>
        /// <param name="marginTop"></param>
        /// <param name="marginRight"></param>
        /// <param name="marginBottom"></param>
        /// <returns></returns>
        public static Image Image(string imageSource, double height, double marginLeft = 0, double marginTop = 0, double marginRight = 0, double marginBottom = 0)
        {
            Image image = new Image()
            {
                HeightRequest = height,
                Margin = new Thickness(marginLeft, marginTop, marginRight, marginBottom),
                Source = ImageSource.FromResource(imageSource),
            };

            return image;
        }

        /// <summary>
        /// 背景色赤のStackLayout
        /// </summary>
        /// <returns></returns>
        public static StackLayout RedStackLayout()
        {
            StackLayout stacklayout = new StackLayout()
            {
                BackgroundColor = Color.FromHex(RED),
            };

            return stacklayout;
        }

        /// <summary>
        /// 背景色黒のStackLayout
        /// </summary>
        /// <returns></returns>
        public static StackLayout BlackStackLayout()
        {
            StackLayout stacklayout = new StackLayout()
            {
                BackgroundColor = Color.FromHex(BLACK),
            };

            return stacklayout;
        }
    }
}
