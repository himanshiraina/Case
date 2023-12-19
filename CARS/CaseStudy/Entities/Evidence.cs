using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Evidence
    {
            int evidenceID;
            string description;
            string locationFound;
            int incidentID;
            public int EvidenceID { get { return evidenceID; } set { evidenceID = value; } }
            public string Description { get { return description; } set { description = value; } }
            public string LocationFound { get { return locationFound; } set { locationFound = value; } }
            public int IncidentID { get { return incidentID; } set { incidentID = value; } }
            public Evidence(int evidenceID, string description, string locationFound, int incidentID)
            {
                EvidenceID = evidenceID;
                Description = description;
                LocationFound = locationFound;
                IncidentID = incidentID;
            }
    }
}
