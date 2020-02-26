﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsiderGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setting : ContentPage
    {
        const string MASTER = "Master";
        const string INSIDER = "Insider";
        const string COMMON = "Common";

        public Setting()
        {
            InitializeComponent();

            Button orangeButton = new Button
            {
                Text = "2"
            };

            orangeButton.Clicked += Button_Clicked;

            FlexLayout flexLayout = new FlexLayout();
            flexLayout.Children.Add(orangeButton);
            Content = flexLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int pressed = Convert.ToInt16(button.Text);

            var commonPlayers = CreatePlayers(pressed);
            var setRolePlayers = SetRole(commonPlayers);

            //Navigation.PushAsync(new SetWord(setRolePlayers));
            Application.Current.MainPage = new SetWord(setRolePlayers);
        }

        /// <summary>
        /// 役割を決定
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        internal List<Player> SetRole(List<Player> players)
        {
            var random = new Random();

            // プレイヤー人数の中からランダムで役職を決定
            var insider = random.Next(0, players.Count);
            var master = random.Next(0, players.Count);

            // 役職が重複した場合、マスターの役職を決定しなおす
            while (insider == master)
            {
                master = random.Next(0, players.Count);
            }

            players[insider].Role = INSIDER;
            players[master].Role = MASTER;

            return players;
        }

        /// <summary>
        /// プレイヤーを作成
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <returns></returns>
        internal static List<Player> CreatePlayers(int numberOfPlayers)
        {
            // 選択された人数分だけプレイヤーを作成
            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = new Player()
                {
                    Name = $"player_{i + 1}",   // 初期値は"player_1","player_2"
                    Role = COMMON,              // 初期値はCommon
                };

                players.Add(player);
            }

            return players;
        }
    }
}