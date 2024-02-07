﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MODELS
{
    public class Officers
    {
        private int officerId;
        private string firstName;
        private string lastName;
        private int badgeNumber;
        private int rank;
        private string contactInformation;
        private int agencyId;

        public Officers() { }
        public Officers(int officerId, string firstname, string lastname, int badgeNumber, int rank, string contactInformation, int agencyId)
        {
            OfficerID = officerId;
            FirstName = firstname;
            LastName = lastname;
            BadgeNumber = badgeNumber;
            Rank = rank;
            ContactInformation = contactInformation;
            AgencyID = agencyId;
        }

        public int OfficerID
        {
            get { return officerId; }
            set { officerId = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int BadgeNumber
        {
            get { return badgeNumber; }
            set { badgeNumber = value; }
        }
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }
        public int AgencyID
        {
            get { return agencyId; }
            set { agencyId = value; }
        }
    }
}
