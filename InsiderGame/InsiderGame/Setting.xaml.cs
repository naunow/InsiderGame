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
    public partial class Setting : ContentPage
    {
        const string MASTER = "Master";
        const string INSIDER = "Insider";
        const string COMMON = "Common";

        public Setting()
        {
            InitializeComponent();

            var stackLayout = Component.RedStackLayout();

            var jpLabel = Component.BodyLabel("何人で遊びますか？");
            var enLabel = Component.BodyLabel("How many players?");

            var fourButton = Component.WideBlackButton("4");
            fourButton.Margin = new Thickness(50, 10);
            fourButton.Clicked += Button_Clicked;

            var fiveButton = Component.WideBlackButton("5");
            fiveButton.Margin = new Thickness(50, 10);
            fiveButton.Clicked += Button_Clicked;

            var sixButton = Component.WideBlackButton("6");
            sixButton.Margin = new Thickness(50, 10);
            sixButton.Clicked += Button_Clicked;

            var sevenButton = Component.WideBlackButton("7");
            sevenButton.Margin = new Thickness(50, 10);
            sevenButton.Clicked += Button_Clicked;

            var eightButton = Component.WideBlackButton("8");
            eightButton.Margin = new Thickness(50, 10, 50, 80);
            eightButton.Clicked += Button_Clicked;

            stackLayout.Children.Add(jpLabel);
            stackLayout.Children.Add(enLabel);
            stackLayout.Children.Add(fourButton);
            stackLayout.Children.Add(fiveButton);
            stackLayout.Children.Add(sixButton);
            stackLayout.Children.Add(sevenButton);
            stackLayout.Children.Add(eightButton);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int pressed = Convert.ToInt16(button.Text);

            var commonPlayers = CreatePlayers(pressed);

            var gameSet = new GameSet()
            {
                playerList = SetRole(commonPlayers),
            };

            await Navigation.PushAsync(new SetWord(gameSet));
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
            players[master].IsCheckedRole = true;   // マスターは最初に役職チェックをするのでtrueに設定

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
                var iPlusOne = i + 1;
                Player player = new Player()
                {
                    Id = iPlusOne,                  // 1から始まるように設定
                    Name = $"player_{iPlusOne}",    // 初期値は"player_1","player_2"
                    Role = COMMON,                  // 初期値はCommon
                    IsCheckedRole = false,
                };

                players.Add(player);
            }

            return players;
        }
    }
}