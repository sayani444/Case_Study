using System;

namespace CARS.EXCEPTION
{
    internal class IncidentNumberNotFoundException : ApplicationException
    {

        public IncidentNumberNotFoundException() 
        { 
        }
        public IncidentNumberNotFoundException(string message) : base(message)
        {

        }
    }
}
