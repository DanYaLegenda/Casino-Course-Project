using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
     class refillViewModel : ViewModelBase
    {
        public ICommand Menu { get; }


        User _user;


        public refillViewModel(Navigation nav, User user)
        {
            Menu = new MenuCommand(nav, user);


            _user = user;
        }
    }
}
