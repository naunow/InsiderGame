using InsiderGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace InsiderGame.Tests
{
    public class SettingTests
    {
        [Theory(DisplayName ="プレイヤー作成")]
        [InlineData(4)]
        [InlineData(8)]
        public void CreatePlayersTest(int numberOfPlayers)
        {
            var players = Setting.CreatePlayers(numberOfPlayers);
            Assert.Equal(numberOfPlayers, players.Count);

            players.Select(x=>x.Role);
        }
    }
}