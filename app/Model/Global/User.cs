using System;
using System.Collections.Generic;

namespace CasinoSimulation.Model.Global
{
    /// <summary>
    /// holds global user data used between all games
    /// (Requirement 2.2)
    /// </summary>
    public class User
    {
        public long Bankroll { get; set; }

        
        public stakes UserStakes
        {
            get
            {
                return _userStakes;
            }
            set
            {
                _userStakes = value;
                MinBet = ChipDenominations[(int)UserStakes];
                MaxBet = MinBet * 100;
            }
        }
         
        public String Login;
        public string Phone;
        public string Password;
        public string Email;
        public string BirthDate;
        public bool isAutorize;
        public int Role;
        public int Id;
        public string RefCode;

        public int NumDecks { get; set; }
        public int[] ChipDenominations { get; }
        public int MinBet { get; set; }
        public int MaxBet { get; set; }
        private const long STARTING_CASH = 5000;
        private stakes _userStakes;

        public User()
        {
            NumDecks = 6;
            ChipDenominations = new int[] { 10000, 5000, 2000, 1000, 500, 250, 100, 25, 10, 5, 1 };
            UserStakes = (stakes)6;
        }

        public User(string login, string password, string phone, string email, string birthDate, string refCode = "") : this()
        {
            Login = login;
            Phone = phone;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            isAutorize = true;
            RefCode = refCode;
        }

        public User(int id, string login, string password, string phone, string email, string birthDate, string refCode = "") 
            : this(login, password, phone, email, birthDate)
        {
            Id = id;
        }
            //Player receives initial chips to take into the casino
            //(Requirement 3.1)
            public void CashIn()
        {
            Bankroll = STARTING_CASH;
        }
        //Shared function to build chipstack visual data
        public IList<Chip> BuildChips(long cash)
        {
            IList<Chip> chips = new List<Chip>();
            foreach (int i in ChipDenominations)
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
