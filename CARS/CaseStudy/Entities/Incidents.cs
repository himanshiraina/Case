using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace CARS.Entities
{
    public class Incidents
    {
        public int IncidentID { get; set; }
        public string IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int VictimID { get; set; }
        public int SuspectId { get; set; }

        public Incidents() { }

        public Incidents(int incidentID, string incidentType, DateTime incidentDate, string location, string description, string status, int victimID, int suspectID)
        {
            IncidentID = incidentID;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Location = location;
            Description = description;
            Status = status;
            VictimID = victimID;
            SuspectId = suspectID;
        }
 

        public override string ToString()
        {
            return $"incidentID::{IncidentID}\t incidentType::{IncidentType}\t incidentDate::{IncidentDate}\t location::{Location}\t description::{Description}\t status::{Status}\t victimID::{VictimID}\t suspectID::{SuspectId}";

        }
    }
}
