using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public interface IIncidentAnalysis
    {

        Incidents SearchIncidentsByIncidentID(int incidentId);
        void CreateIncident(Incidents incident, Victims vic, Suspects sic, Reports res, LawEnforcementAgencies la, Officers off);
        void UpdateIncidentStatus(int incidentId, string newStatus);
        List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
    }
}
