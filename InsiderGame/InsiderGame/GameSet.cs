using System.Collections.Generic;

namespace InsiderGame
{
    public class GameSet
    {
        /// <summary>
        /// ゲームのお題のid
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// プレイヤーリスト
        /// </summary>
        public List<Player> playerList { get; set; }
    }
}
