using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MODELS
{
    public class Evidence
    {
        private int evidenceId;
        private string description;
        private string locationFound;
        private int incidentId;

        public Evidence() { }

        public Evidence(int evidenceId, string description, string locationFound, int incidentId)
        {
            EvidenceId = evidenceId;
            Description = description;
            LocationFound = locationFound;
            IncidentId = incidentId;
        }

        public int EvidenceId
        {
            get { return evidenceId; }
            set { evidenceId = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string LocationFound
        {
            get { return locationFound; }
            set { locationFound = value; }
        }
        public int IncidentId
        {
            get { return incidentId; }
            set { incidentId = value; }
        }

    }
}
