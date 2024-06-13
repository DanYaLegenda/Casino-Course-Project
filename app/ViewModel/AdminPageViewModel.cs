using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    class AdminPageViewModel : ViewModelBase
    {
        public ICommand Menu { get; }


        User _user;


        public AdminPageViewModel(Navigation nav, User user)
        {
            Menu = new MenuCommand(nav, user);


            _user = user;
        }

    }
}
