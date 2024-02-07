using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MODELS
{
    public class Reports
    {
        private int reportId;
        private int incidentId;
        private int reportingOfficer;
        private DateTime reportDate;
        private string reportDetails;
        private string status;

        public Reports() { }

        public Reports(int reportId, int incidentId, int reportingOfficer, DateTime reportDate, string reportDetails, string status)
        {
            ReportID = reportId;
            IncidentID = incidentId;
            ReportingOfficer = reportingOfficer;
            ReportDate = reportDate;
            ReportDetails = reportDetails;
            Status = status;
        }

        public int ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }
        public int IncidentId
        {
            get { return incidentId; }
            set { incidentId = value; }
        }

        public int ReportID { get; }
        public int IncidentID { get; }

        public int ReportingOfficer
        {
            get { return reportingOfficer; }
            set { reportingOfficer = value; }
        }
        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
        }

    

        public string ReportDetails
        {
            get { return reportDetails; }
            set { reportDetails = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
