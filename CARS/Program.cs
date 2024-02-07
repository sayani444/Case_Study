using CARS.REPOSITORY;
using CARS.MODELS;
using System;
using CARS.SERVICE;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IIncidentRepository incidentRepository = new IncidentRepository();
        IIncidentService incidentService = new IncidentService(incidentRepository);

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create Incident");
            Console.WriteLine("2. Update Incident");
            Console.WriteLine("3. Generate Incident Report");
            Console.WriteLine("4. Search Incidents by Type");
            Console.WriteLine("5. List Incidents by Date Range");
            Console.WriteLine("6. Exit");
            Console.WriteLine("7. Create Case");
            Console.WriteLine("8. Get Incident by ID");
            Console.WriteLine("9. Updated Case Details");
            Console.WriteLine("10. Get All Cases");
            Console.WriteLine("11. Get Case Details");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    incidentService.CreateIncident();
                    break;

                case "2":
                    incidentService.UpdateIncident();
                    break;

                case "3":
                    incidentService.GenerateIncidentReport();
                    break;

                case "4":
                    Console.WriteLine("Enter Incident Type:");
                    string incidentTypeInput = Console.ReadLine();
                    List<Incident> searchResults = incidentService.SearchIncidentType(incidentTypeInput);

                    foreach (var incident in searchResults)
                    {
                        Console.WriteLine($"IncidentID: {incident.IncidentId}, IncidentType: {incident.IncidentType}, IncidentDate: {incident.IncidentDate}");
                    }
                    break;

                case "5":
                    Console.WriteLine("Enter start date (yyyy-MM-dd):");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter end date (yyyy-MM-dd):");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());
                    List<Incident> incidentList = incidentService.ListIncidentDate(startDate, endDate);

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
                    break;

                case "6":
                    Environment.Exit(0);
                    break;

                case "7":
                    Console.WriteLine("Enter CaseId:");
                    int caseIdInput = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter IncidentId:");
                    int incidentIdInput = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Description:");
                    string descriptionInput = Console.ReadLine();

                  
                    incidentService.CreateCase(caseIdInput, incidentIdInput, descriptionInput);
                    break;

                case "8":
                    Console.WriteLine("Enter Incident ID:");
                    int IncidentNumber = int.Parse(Console.ReadLine());

                 
                    incidentService.GetIncidentById(IncidentNumber);
                    break;

                case "9":
                    
                    Console.WriteLine("Enter Case ID:");
                    int caseId = int.Parse(Console.ReadLine());
                    Case updatedCase = incidentRepository.GetCaseDetails(caseId);

                    
                    if (updatedCase != null)
                    {
                        
                        incidentService.UpdateCaseDetails(updatedCase);
                    }
                    else
                    {
                        Console.WriteLine($"Case with ID {caseId} does not exist.");
                    }
                    break;

                case "10":
                    List<Case> cases = incidentService.GetAllCases();
                    Console.WriteLine("All Cases:");
                    foreach (var caseItem in cases)
                    {
                        Console.WriteLine($"Case ID: {caseItem.CaseId}, Incident ID: {caseItem.IncidentId}, Description: {caseItem.Description}");
                    }
                    break;

                case "11":
                    Console.WriteLine("Enter Case ID:");
                    int caseInput = int.Parse(Console.ReadLine());
                    Case caseDetails = incidentService.GetCaseDetails(caseInput);
                    if (caseDetails != null)
                    {
                        Console.WriteLine($"Case ID: {caseDetails.CaseId}, Incident ID: {caseDetails.IncidentId}, Description: {caseDetails.Description}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
