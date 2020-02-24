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
        public Setting()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int pressed = Convert.ToInt16(button.Text);

            var players = CreatePlayers(pressed);
            var setRolePlayers = SetRole(players);

        }

        /// <summary>
        /// 役割を決定
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        private List<Player> SetRole(List<Player> players)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// プレイヤーを作成
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <returns></returns>
        public static List<Player> CreatePlayers(int numberOfPlayers)
        {
            // 選択された人数分だけプレイヤーを作成
            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = new Player()
                {
                    Name = $"player_{i + 1}",   // 初期値は"player_1","player_2"
                    Role = "Common",            // 初期値はCommon
                };

                players.Add(player);
            }

            return players;
        }
    }
}