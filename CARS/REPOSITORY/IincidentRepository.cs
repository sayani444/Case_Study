using CARS.MODELS;
using System;
using System.Collections.Generic;

namespace CARS.REPOSITORY
{
    public interface IIncidentRepository
    {
        int CreateIncident(Incident incident);
        void UpdateIncident(int incidentId, string status);
       

        List<Incident> ListIncidentDate(DateTime startDate, DateTime endDate);

       

        Reports GenerateIncidentReport(int incidentId);
       
        Case GetCaseDetails(int caseId);
        List<Incident> SearchIncidentType(string incidentType);
        void CreateCase(int caseId, int incidentId, string description);
        // Exception
        Incident GetIncidentById(int incidentId);
        bool UpdateCaseDetails(Case updatedCase);
        List<Case> GetAllCases();
    }
}
