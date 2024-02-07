using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MODELS
{
    public class LawEnforcementManagement
    {
        private int agencyId;
        private string agencyName;
        private string jurisdiction;
        private string contactInformation;

        public LawEnforcementManagement() { }

        public LawEnforcementManagement(int agencyId, string agencyName, string jurisdiction, string contactInformation)
        {
            AgencyId = agencyId;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            ContactInformation = contactInformation;
        }


        public int AgencyId
        {
            get { return agencyId; }
            set { agencyId = value; }
        }
        public string AgencyName
        {
            get { return agencyName; }
            set { agencyName = value; }
        }
        public string Jurisdiction
        {
            get { return jurisdiction; }
            set { jurisdiction = value; }
        }
        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }

    }
}
