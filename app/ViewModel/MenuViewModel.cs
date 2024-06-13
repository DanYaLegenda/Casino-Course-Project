using Azure.Identity;
using CasinoSimulation.Command.Menu;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Model.Global.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CasinoSimulation.ViewModel
{
    /// <summary>
    /// Opening screen
    /// отображает варианты получения фишек, входа в мини-игру или выхода из игры
    /// (Requirement 3.1)
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        public ICommand CashInCommand { get; }
        public ICommand BlackJackCommand { get; }
        public ICommand SlotsCommand { get; }
        public ICommand RouletteCommand { get; }
        public ICommand CashOutCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ProfileOpenCommand { get; }

        public IList<Chip> BankrollChipDisplay
        {
            get
            {
                return BuildChips(_user.Bankroll);
            }
        }



        public long BankrollDisplay
        {
            get => _user.Bankroll;
        }
        public string UserLogin
        {
            get => _user.Login;
        }
        public stakes UserStakes
        {
            get
            {
                return _user.UserStakes;
            }
            set
            {
                _user.UserStakes = value;
                OnPropertyChanged("Stakes");
            }
        }
        public IEnumerable<stakes> StakesValues
        {
            get => Enum.GetValues(typeof(stakes)).Cast<stakes>();
        }
        public bool CanNavigate
        {
            get => _user.Bankroll > 0;
        }

        public bool IsUser
        {
            get
            {
                if (_user.Role == 1)
                {
                    return false;
                } 
                else
                {
                    return true;
                }
            }
        }

        public bool OnUserChange
        {
            get => _user.isAutorize;
        }

        public bool OnUserChangeReverse
        {
            get => !_user.isAutorize;
        }

        private User _user;

        public MenuViewModel(Navigation nav, User user)
        {
            string login    = (string)Application.Current.Resources["Login"];
            string password = (string)Application.Current.Resources["Password"];

            _user = user;
            if (login != null && password != null)
            {
                DataBaseOperations dbo = new DataBaseOperations();
                User user2 = dbo.GetUser(login, password, true);
                _user = user2;

                Application.Current.Resources["Login"] = null;
                Application.Current.Resources["Password"] = null;
            }
            string value = (string)Application.Current.Resources["Value"];
            if (value != null)
            {
                _user.Bankroll += Convert.ToInt64(value);
                Application.Current.Resources["Value"] = null;
            }


            CashInCommand = new refillCommand(nav, _user);
            BlackJackCommand = new BlackJackCommand(nav, _user);
            SlotsCommand = new SlotsCommand(nav, _user);
            RouletteCommand = new RouletteCommand(nav, _user);
            RegisterCommand = new RegisterCommand(nav, _user);
            if (IsUser)
            {
                ProfileOpenCommand = new UserPageCommand(nav, _user);
            } 
            else
            {
                ProfileOpenCommand = new AdminPageCommand(nav, _user);
            }
            CashOutCommand = new CashOutCommand();
        }

        public void RefreshChipStack()
        {
            OnPropertyChanged("BankrollDisplay");
            OnPropertyChanged("BankrollChipDisplay");
            OnPropertyChanged("CanNavigate");
            OnPropertyChanged("OnUserChange");
            OnPropertyChanged("OnUserChangeReverse");

            OnPropertyChanged("UserLogin");
            OnPropertyChanged("IsUser");
        }
        private IList<Chip> BuildChips(long cash)
        {
            IList<Chip> chips = new List<Chip>();
            foreach (int i in _user.ChipDenominations)
            {

                while (cash >= i)
                {
                    chips.Add(new Chip(i));
                    cash -= i;
                }
            }
            return chips;
        }
    }
}
