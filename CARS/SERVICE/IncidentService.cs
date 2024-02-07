using CARS.EXCEPTION;
using CARS.MODELS;
using CARS.REPOSITORY;
using CARS.SERVICE;
using CARS.Utils;
using System;
using System.Collections.Generic;

internal class IncidentService : IIncidentService
{
    readonly IIncidentRepository _incidentRepository;
    private object _incidentService;
    private int addCaseStatus;

    public IncidentService(IIncidentRepository incidentRepository)
    {
        _incidentRepository = incidentRepository;
    }
    // Get Case details 
    public void GetCaseDetails()
    {
        try
        {
            Console.WriteLine("Enter CaseId:");
            int caseId = int.Parse(Console.ReadLine());

       
            Case caseDetails = _incidentRepository.GetCaseDetails(caseId);

            if (caseDetails != null)
            {
                Console.WriteLine("Case Details:");
                Console.WriteLine($"CaseId: {caseDetails.CaseId}");
                Console.WriteLine($"Description: {caseDetails.Description}");
                
            }
            else
            {
                Console.WriteLine("Case not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    // Create Incident
    public void CreateIncident()
    {
        try
        {
            string databaseConnection = DbConnUtils.GetConnectionString();
            Console.WriteLine("Enter IncidentId");
            int incidentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter IncidentType");
            string incidentType = Console.ReadLine();
            Console.WriteLine("Enter date yyyy-mm-date");
            DateTime incidentDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude:");
            decimal latitude = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude:");
            decimal longitude = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Status:");
            string status = Console.ReadLine();
            Console.WriteLine("Enter VictimId:");
            int victimId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter SuspectId:");
            int suspectId = int.Parse(Console.ReadLine());

            
            Incident newIncident = new Incident
            {
                IncidentId = incidentId,
                IncidentType = incidentType,
                IncidentDate = incidentDate,
                Latitude = latitude,
                Longitude = longitude,
                Description = description,
                Status = status,
                VictimId = victimId,
                SuspectId = suspectId
            };

            
            _incidentRepository.CreateIncident(newIncident);

        
            Console.WriteLine("Incident created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    // Update Incident

    public void UpdateIncident()
    {
        
        try
        {
            string databaseConnection = DbConnUtils.GetConnectionString();

            Console.WriteLine("Enter IncidentId:");
            int incidentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new status:");
            string newStatus = Console.ReadLine();


            _incidentRepository.UpdateIncident(incidentId, newStatus);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        
    }


    // Generate incident Reports

    public Reports GenerateIncidentReport()
    {
        Reports incidentReports = new Reports();

        try
        {
            Console.WriteLine("Enter IncidentId:");
            int incidentId = int.Parse(Console.ReadLine());

        
            incidentReports = _incidentRepository.GenerateIncidentReport(incidentId);

            if (incidentReports != null)
            {
                Console.WriteLine("Incident Report Details:");
                Console.WriteLine($"ReportId: {incidentReports.ReportId}");
                Console.WriteLine($"IncidentId: {incidentReports.IncidentId}");
                Console.WriteLine($"Reporting Officer: {incidentReports.ReportingOfficer}");
                Console.WriteLine($"Report Date: {incidentReports.ReportDate}");
                Console.WriteLine($"Report Details: {incidentReports.ReportDetails}");
                Console.WriteLine($"Status: {incidentReports.Status}");
                
            }
            else
            {
                Console.WriteLine("Incident report not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return incidentReports;
    }

   

    //  Search Incident Type

    public List<Incident> SearchIncidentType(string incidentType)
    {
        try
        {
           
            List<Incident> searchResults = _incidentRepository.SearchIncidentType(incidentType);

            if (searchResults.Count > 0)
            {
                Console.WriteLine($"Incidents of type '{incidentType}':");
                foreach (var incident in searchResults)
                {
                    Console.WriteLine($"IncidentID: {incident.IncidentId}, IncidentType: {incident.IncidentType}, IncidentDate: {incident.IncidentDate}");
                   
                }
            }
            else
            {
                Console.WriteLine($"No incidents found for type '{incidentType}'.");
            }

            return searchResults;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<Incident>(); 
        }
    }
    //  List Incident Date
    public List<Incident> ListIncidentDate(DateTime startDate, DateTime endDate)
    {
        List<Incident> incidentList = new List<Incident>();

        try
        {
            
            incidentList = _incidentRepository.ListIncidentDate(startDate, endDate);

            if (incidentList.Count > 0)
            {
                Console.WriteLine($"Incidents between {startDate} and {endDate}:");
                foreach (var incident in incidentList)
                {
                    Console.WriteLine($"IncidentID: {incident.IncidentId}, IncidentType: {incident.IncidentType}, IncidentDate: {incident.IncidentDate}");
                 
                }
            }
            else
            {
                Console.WriteLine($"No incidents found between {startDate} and {endDate}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return incidentList;
    }
     // Get Case Details
    public Case GetCaseDetails(int caseId)
    {
        try
        {
            
            Case caseDetails = _incidentRepository.GetCaseDetails(caseId);

            if (caseDetails != null)
            {
                Console.WriteLine($"Case details found - ID: {caseDetails.CaseId}, Description: {caseDetails.Description}");
            }
            else
            {
                Console.WriteLine($"Case with ID {caseId} not found.");
            }

            return caseDetails;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null; 
        }
    }

     // Void Craete Case
    public void CreateCase(int caseId, int incidentId, string description)
    {
        try
        {
            
            _incidentRepository.CreateCase(caseId, incidentId, description);

            
            Console.WriteLine("Case created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    // exception Get Incident By Id
    public void GetIncidentById(int incidentId)
    {
        try
        {
            Incident foundIncident = _incidentRepository.GetIncidentById(incidentId);

            if (foundIncident != null)
            {
                Console.WriteLine($"Incident found - ID: {foundIncident.IncidentId}, Type: {foundIncident.IncidentType}, Date: {foundIncident.IncidentDate}");
            }
            else
            {
              
                throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found.");
            }
        }
        catch (IncidentNumberNotFoundException ex)
        {
            Console.WriteLine($"IncidentNumberNotFoundException: {ex.Message}");
           
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
          
        }
    }
    // Updated CaseDetails
    public bool UpdateCaseDetails(Case updatedCase)
    {
        try
        {
            Console.WriteLine("Updating case details...");
            Console.WriteLine($"Enter new description for Case ID {updatedCase.CaseId}:");
            string newDescription = Console.ReadLine();

            updatedCase.Description = newDescription;

            bool success = _incidentRepository.UpdateCaseDetails(updatedCase);

            if (success)
            {
                Console.WriteLine("Case details updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update case details.");
            }

            return success;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while updating case details: {ex.Message}");
            return false;
        }
    }
    // Get ALL Cases Details
    public List<Case> GetAllCases()
    {
        try
        {
            return _incidentRepository.GetAllCases();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving cases: {ex.Message}");
            return new List<Case>(); 
        }
    }


}
