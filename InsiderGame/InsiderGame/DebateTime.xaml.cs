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
    public partial class DebateTime : ContentPage
    {
        private GameSet _gameSet;
        public DebateTime(GameSet gameset)
        {
            _gameSet = gameset;
            InitializeComponent();
        }
    }
}