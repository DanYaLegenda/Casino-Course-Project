using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    class ThisRegisterViewModel : ViewModelBase
    {
        public ICommand Menu { get; }
        public ICommand SignUp { get; }
        public ICommand Register { get; }
        public ICommand Validation { get; }


        User _user;


        public ThisRegisterViewModel(Navigation nav, User user)
        {
            Menu = new MenuCommand(nav, user);

            Register = new ThisRegisterCommand(nav, user);

            SignUp = new UserPageCommand(nav, user);

            _user = user;
        }

    }
}
