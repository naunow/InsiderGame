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
    public partial class SetWord : ContentPage
    {
        private List<Player> setRolePlayers;

        public SetWord(List<Player> setRolePlayers)
        {
            InitializeComponent();

            this.setRolePlayers = setRolePlayers;
        }

        private void ChooseWord(object sender, EventArgs e)
        {
            FlexLayout flexLayout = new FlexLayout
            {
                
            };
        }
    }
}