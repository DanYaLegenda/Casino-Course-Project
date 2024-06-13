using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CasinoSimulation.Command.Menu;
using CasinoSimulation.Command.Registration;


namespace CasinoSimulation.ViewModel
{
    class RegisterViewModel : ViewModelBase
    {
        public ICommand Menu { get; }
        public ICommand SignUp { get; }
        public ICommand Register { get; }
        public ICommand Validation { get; }


        User _user;


        public RegisterViewModel(Navigation nav, User user)
        {
            Menu = new MenuCommand(nav, user);

            Register = new ThisRegisterCommand(nav, user);

            SignUp = new UserPageCommand(nav, user);

            _user = user;
        }

    }
}
