using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Exceptions
{
    // Custom exception class for IncidentNumberNotFoundException
    public class IncidentNumberNotFoundException : Exception
    {
        public int IncidentNumber { get; }

        public IncidentNumberNotFoundException(int incidentNumber)
            : base($"Incident with number {incidentNumber} not found.")
        {
            IncidentNumber = incidentNumber;
        }
    }
}
