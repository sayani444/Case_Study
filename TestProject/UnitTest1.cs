using NUnit.Framework;
using System;
using CARS.REPOSITORY;
using CARS.MODELS;
using System.Net.NetworkInformation;

namespace TestProject
{
    public class Tests
    {
        private IncidentRepository _incidentRepository;

        [SetUp]
        public void Setup()
        {
            _incidentRepository = new IncidentRepository();
        }

        [Test]
        public void CreateIncident()
        {
            // Arrange
            var incident = new Incident
            {
                IncidentId = 9,
                IncidentType = "TestType",
                IncidentDate = DateTime.Now,
                Latitude = 0.0M,
                Longitude = 0.0M,
                Description = "Test Description",
                Status = "Open",
                VictimId = 1,
                SuspectId = 2
            };

            
            
            int a = _incidentRepository.CreateIncident(incident);
            Assert.IsTrue(a > 0);

        }

        [Test]
        public void UpdateIncidentStatus_EffectivelyUpdatesStatus()
        {
            int incidentId = 1;
            string newStatus = "NewStatus";

            // Act
            _incidentRepository.UpdateIncident(incidentId, newStatus);
            

           

        }

        [Test]
        public void UpdateIncidentStatus_InvalidStatusUpdateHandledAppropriately()
        {
            // Arrange
            int incidentId = -1; 
            string newStatus = "NewStatus";
            Assert.Throws<ArgumentException>(() => _incidentRepository.UpdateIncident(incidentId, newStatus));
        } 
    }
}
