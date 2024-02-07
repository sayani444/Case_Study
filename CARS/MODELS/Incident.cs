using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MODELS
{
    public class Incident
    {
        private int incidentId;
        private string incidentType;
        private DateTime incidentDate;
        private decimal latitude;
        private decimal longitude;
        private string description;
        private string status;
        private int victimId;
        private int suspectId;
       

        public Incident() { }

        public Incident(int incidentId, string incidentType, DateTime incidentDate, decimal latitude, decimal longitude, string description, string status, int victimId, int suspectId)
        {
            IncidentId = incidentId;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = status;
            VictimId = victimId;
            SuspectId = suspectId;
          
        }

        public int IncidentId
        {
            get { return incidentId; }
            set { incidentId = value; }
        }
        public string IncidentType
        {
            get { return incidentType; }
            set { incidentType = value; }
        }
        public DateTime IncidentDate
        {
            get { return incidentDate; }
            set { incidentDate = value; }
        }
        public decimal Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public decimal Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public int VictimId
        {
            get { return victimId; }
            set { victimId = value; }
        }
        public int SuspectId
        {
            get { return suspectId; }
            set { suspectId = value; }
        }
       
    }
}
