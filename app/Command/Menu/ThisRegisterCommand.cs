using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Command.Menu
{
    class ThisRegisterCommand : NavigationCommand
    {
        public ThisRegisterCommand(Navigation navigation, User user) : base(navigation, user) { }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new ThisRegisterViewModel(_navigation, _user);
        }
    }
}
