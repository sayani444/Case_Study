using CARS.EXCEPTION;
using CARS.MODELS;
using CARS.Utils;
using Microsoft.Data.SqlClient;
using System.Data.Common;
//using System;
//using System.Collections.Generic;

namespace CARS.REPOSITORY
{
    public class IncidentRepository : IIncidentRepository
    {
        string databaseConnectionString = DbConnUtils.GetConnectionString();
        SqlCommand command = null;
        private object _incidentRepository;
        private int a;

        public IncidentRepository()
        {
            command = new SqlCommand();
        }
        // 1 Create Incident
        public int CreateIncident(Incident incident)
        {
            int rowsAffected = 0; 

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Incidents (IncidentId, IncidentType, IncidentDate, Latitude, Longitude, Description, Status, VictimId, SuspectId) VALUES (@IncidentId, @IncidentType, @IncidentDate, @Latitude, @Longitude, @Description, @Status, @VictimId, @SuspectId)";

                        command.Parameters.AddWithValue("@IncidentId", incident.IncidentId);
                        command.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                        command.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                        command.Parameters.AddWithValue("@Latitude", incident.Latitude);
                        command.Parameters.AddWithValue("@Longitude", incident.Longitude);
                        command.Parameters.AddWithValue("@Description", incident.Description);
                        command.Parameters.AddWithValue("@Status", incident.Status);
                        command.Parameters.AddWithValue("@VictimId", incident.VictimId);
                        command.Parameters.AddWithValue("@SuspectId", incident.SuspectId);

                        rowsAffected = command.ExecuteNonQuery(); 

                        if (rowsAffected == 0)
                        {
                            throw new Exception("No rows were affected. Incident creation failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while creating the incident: {ex.Message}");
            }

            return rowsAffected;
        }
        // 2 Update Incident
        public void UpdateIncident(int incidentId, string status)
        {
            if (incidentId <= 0)
            {
                throw new ArgumentException("Invalid incident ID. The incident ID must be greater than zero.");
            }

            int rowsAffected = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DbConnUtils.GetConnectionString()))
                {
                    sqlConnection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandText = "UPDATE Incidents SET Status = @newstatus WHERE IncidentID = @incidentId";

                        command.Parameters.AddWithValue("@newstatus", status);
                        command.Parameters.AddWithValue("@incidentId", incidentId);

                        rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Incident Successfully Updated");
                        }
                        else
                        {
                            Console.WriteLine("Error. Not Updated Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


       // 3 Search Incident Type
        public List<Incident> SearchIncidentType(string incidentType)
        {
            List<Incident> searchResults = new List<Incident>();

            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(databaseConnectionString))
                {
                    sqlconnection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentType = @incidentType", sqlconnection))
                    {
                        command.Parameters.AddWithValue("@incidentType", incidentType);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Incident incident = new Incident
                                {
                                    IncidentId = (int)reader["IncidentId"],
                                    IncidentType = reader["IncidentType"].ToString(),
                                    IncidentDate = (DateTime)reader["IncidentDate"],
                                    Latitude = (decimal)reader["Latitude"],
                                    Longitude = (decimal)reader["Longitude"],
                                    Description = reader["Description"].ToString(),
                                    Status = reader["Status"].ToString(),
                                    VictimId = (int)reader["VictimId"],
                                    SuspectId = (int)reader["SuspectId"]
                                };

                                searchResults.Add(incident);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return searchResults;
        }



        // 4 List Incident date

        public List<Incident> ListIncidentDate(DateTime startDate, DateTime endDate)
        {
            List<Incident> incidentList = new List<Incident>();

            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(databaseConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @startDate AND @endDate";
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    sqlconnection.Open();
                    command.Connection = sqlconnection;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Incident incident = new Incident();
                        incident.IncidentId = (int)reader["incidentId"];
                       

                        incidentList.Add(incident);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return incidentList;
        }







        // 5 Create Case 
        public void CreateCase(int caseId,int incidentId,string description)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(databaseConnectionString))
                {
                    sqlconnection.Open();

                    command.CommandText = "INSERT INTO Cases VALUES(@caseId,@incidentId,@description)";
                    command.Connection = sqlconnection;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@caseId", caseId);
                    command.Parameters.AddWithValue("@incidentId", incidentId);
                    command.Parameters.AddWithValue("@description", description);

                    int addCaseStatus = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        // 6 Get Case Details
        public Case GetCaseDetails(int caseId)
        {

            Case caseDetails = new Case();
            try
            {

                using (SqlConnection sqlconnection = new SqlConnection(databaseConnectionString))
                {
                    sqlconnection.Open();
                    command.Connection = sqlconnection;
                    command.Parameters.Clear();
                    command.CommandText = "SELECT * FROM Cases WHERE CaseId = @caseId";


                    command.Parameters.AddWithValue("@caseId", caseId);



                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {


                        caseDetails.CaseId = (int)reader["CaseId"];
                        caseDetails.Description = reader["Description"].ToString();
                        


                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return caseDetails;

        }
        // 7 Generate Incident Report
        public Reports GenerateIncidentReport(int incidentId)
        {
            Reports incidentReports = new Reports();

            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(databaseConnectionString))
                {
                    sqlconnection.Open();
                    command.Connection = sqlconnection;
                    command.CommandText = "SELECT * FROM Reports WHERE IncidentId = @incidentId";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@incidentId", incidentId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        incidentReports.ReportId = (int)reader["ReportId"];
                        incidentReports.IncidentId = (int)reader["IncidentId"];
                        incidentReports.ReportingOfficer = (int)reader["ReportingOfficer"];
                        incidentReports.ReportDate = (DateTime)reader["ReportDate"];
                        incidentReports.ReportDetails = reader["ReportDetails"].ToString();
                        incidentReports.Status = reader["Status"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return incidentReports;
        }
      // 8 Exception GetIncidentByID
        public Incident GetIncidentById(int incidentId)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(databaseConnectionString))
                {
                    sqlconnection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentId = @incidentId", sqlconnection))
                    {
                        command.Parameters.AddWithValue("@incidentId", incidentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                Incident foundIncident = new Incident
                                {
                                    IncidentId = (int)reader["IncidentId"],
                                    IncidentType = reader["IncidentType"].ToString(),
                                    IncidentDate = (DateTime)reader["IncidentDate"],
                                 
                                };

                                return foundIncident;
                            }
                            else
                            {
                               
                                throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            
            return null;
        }

        public bool UpdateCaseDetails(Case updatedCase)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE Cases SET Description = @Description WHERE CaseId = @CaseId", connection))
                    {
                        command.Parameters.AddWithValue("@CaseId", updatedCase.CaseId);
                        command.Parameters.AddWithValue("@Description", updatedCase.Description);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating case details: {ex.Message}");
            }

            return success;
        }

        public List<Case> GetAllCases()
        {
            List<Case> cases = new List<Case>();

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Cases", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Case caseItem = new Case
                                {
                                    CaseId = Convert.ToInt32(reader["CaseId"]),
                                    IncidentId = Convert.ToInt32(reader["IncidentId"]),
                                    Description = reader["Description"].ToString()
                                };

                                cases.Add(caseItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving cases: {ex.Message}");
            }

            return cases;
        }










    }
}
