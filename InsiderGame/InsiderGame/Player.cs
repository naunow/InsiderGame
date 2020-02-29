
namespace InsiderGame
{
    public class Player
    {
        /// <summary> プレイヤーID </summary>
        public int Id { get; set; }

        /// <summary> プレイヤー名 </summary>
        public string Name { get; set; }

        /// <summary> 役職 </summary>
        public string Role { get; set; }

        /// <summary> Roleクラスで、役職のチェックがされたかどうかを保持するフラグ </summary>
        public bool IsCheckedRole { get; set; }
    }
}