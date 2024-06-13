using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Menu
{

    public class AdminPageCommand : NavigationCommand
    {
        public AdminPageCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new AdminPageViewModel(_navigation, _user);
        }
    }
}
