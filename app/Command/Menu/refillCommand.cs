using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Command.Menu
{ 
    class refillCommand : NavigationCommand
    {
        public refillCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {

            _navigation.CurrentViewModel = new refillViewModel(_navigation, _user);
        }
    }
}
