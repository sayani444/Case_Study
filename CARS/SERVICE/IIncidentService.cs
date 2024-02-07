using CARS.MODELS;
using System;
using System.Collections.Generic;

namespace CARS.SERVICE
{
    internal interface IIncidentService
    {
        void CreateIncident();
        void UpdateIncident();
        Reports GenerateIncidentReport();
        Case GetCaseDetails(int caseId);

        List<Incident> SearchIncidentType(string incidentType);
        List<Incident> ListIncidentDate(DateTime startDate, DateTime endDate);

        void CreateCase(int caseIdInput,int incidentIdInput,string descriptionInput);
        // Exception
        void GetIncidentById(int incidentId);
        bool UpdateCaseDetails(Case updatedCase);
        List<Case> GetAllCases();

    }
}
