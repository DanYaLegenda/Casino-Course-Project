using CasinoSimulation.Command.Registration;
using CasinoSimulation.Model.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CasinoSimulation.Command.Menu;

namespace CasinoSimulation.ViewModel
{
    class UserPageViewModel : ViewModelBase
    {
        public ICommand Menu { get; }


        User _user;

        public string UserLogin
        { 
            get => _user.Login;
            set => OnPropertyChanged("UserLogin");
        }

        public string UserId
        {
            get => _user.Id.ToString();
            set => OnPropertyChanged("UserId");
        }

        public string UserBalance
        {
            get => _user.Bankroll.ToString() + "$";
            set => OnPropertyChanged("UserBalance");
        }

        

        public UserPageViewModel(Navigation nav, User user)
        {
            Menu = new MenuCommand(nav, user);
            
            _user = user;
            _user.isAutorize = true;
        }



    }
}
