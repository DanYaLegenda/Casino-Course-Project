using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Command.Menu
{
    class RegisterCommand : NavigationCommand
    {
        public RegisterCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {

            _navigation.CurrentViewModel = new RegisterViewModel(_navigation, _user);
        }
    }
}
