﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Reports
    {
        

        public int ReportID { get; set; }
        public int IncidentID { get; set; }
        public int ReportingOfficer { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string Status { get; set; }



        public Reports() { }
        public Reports(int reportID, int incidentID, int reportingOfficer, DateTime reportDate, string reportDetails, string status)
        {
            ReportID = reportID;
            IncidentID = incidentID;
            ReportingOfficer = reportingOfficer;
            ReportDate = reportDate;
            ReportDetails = reportDetails;
            Status = status;
        }


    }
}
