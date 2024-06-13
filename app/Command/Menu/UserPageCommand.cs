using CasinoSimulation.Model.Global;
using CasinoSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoSimulation.Command.Menu
{
    public class UserPageCommand : NavigationCommand
    {
        public UserPageCommand(Navigation navigation, User user) : base(navigation, user) { }

        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new UserPageViewModel(_navigation, _user);
        }
    }
}
