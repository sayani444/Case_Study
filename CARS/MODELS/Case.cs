using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MODELS
{
    public class Case
    {
        private int caseId;
        private int incidentId;
        private string description;

        public Case() { }

        public Case(int caseId,  int incidentId, string description)
        {
            CaseId = caseId;
            IncidentId = incidentId;
            Description = description;
        }

        public int CaseId
        {
            get { return caseId; }
            set { caseId = value; }
        }
       
        public int IncidentId
        {
            get { return incidentId; }
            set { incidentId = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
