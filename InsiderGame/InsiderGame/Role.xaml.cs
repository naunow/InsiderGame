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
    public partial class Role : ContentPage
    {
        private readonly GameSet _gameSet;
        private Player _player;
        private Word _word;

        const string MASTER = "Master";
        const string COMMON = "Common";

        public Role(GameSet gameSet, Word word)
        {
            _gameSet = gameSet;
            _word = word;

            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // ナビゲーションバーの色変更
            var mdPage = Application.Current.MainPage as NavigationPage;
            mdPage.BarBackgroundColor = Color.Black;

            wordInJapanese.Text = _word.WordInJapanese;
            wordInEnglish.Text = _word.WordInEnglish;

            // 初期表示時は非表示に設定
            this.roleFlexLayout.IsVisible = false;
            this.nextPlayerButton.IsVisible = false;

            // 今回表示するプレイヤー情報
            _player = _gameSet.playerList.Where(x => !x.IsCheckedRole).First();
            // 表示済みのプレイヤーとしてチェックをつける
            _gameSet.playerList.Where(x => x.Id == _player.Id).First().IsCheckedRole = true;

            var playerName = _player.Name;

            this.masterJapaneseLabel.Text = $"{playerName}の役職は……";
            this.masterEnglishLabel.Text = $"{playerName}'S ROLE IS ...";
            this.roleLabel.Text = _player.Role;

            if (_player.Role == COMMON)
            {
                roleName.Source = "resource://InsiderGame.Assets.whitequ.svg";
                wordInEnglish.IsVisible = false;
                wordInJapanese.IsVisible = false;
            }
            else
            {
                roleName.Source = "resource://InsiderGame.Assets.whiteInsiderImage.svg";
                wordInEnglish.IsVisible = true;
                wordInJapanese.IsVisible = true;
            }
        }

        // =====================================================
        // イベントハンドラ
        // =====================================================

        /// <summary>
        /// 役職をチェックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckRole(object sender, EventArgs e)
        {
            // 『役職を見る』ボタンを消す
            this.checkRoleButton.IsVisible = false;
            // 役職パネルを出す
            this.roleFlexLayout.IsVisible = true;
            // 『次のプレイヤーへ』ボタンを出す
            this.nextPlayerButton.IsVisible = true;
        }

        /// <summary>
        /// 次のプレイヤーボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NextPlayer(object sender, EventArgs e)
        {
            if (_gameSet.playerList.Any(x=>!x.IsCheckedRole))
            {
                // まだプレイヤーが残っていたら役職ページへ
                Navigation.InsertPageBefore(new Role(_gameSet, _word), this);
            }
            else
            {
                // 全てのプレイヤーが表示されていたらゲームプレイへ
                Navigation.InsertPageBefore(new Discussion(_gameSet, _word), this);
            }
            await Navigation.PopAsync(false);

        }
    }
}