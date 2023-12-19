using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public class ReportAnalysis : IReportAnalysis
    {
        private static List<Cases> casesList = new List<Cases>();

        private const string connectionString = "Server=LAPTOP-MK5JT9DU;Database=CARS;Trusted_Connection=True";
        public void GenerateIncidentReport(int incidentId)
        {
            string query = @"SELECT i.IncidentID, i.IncidentType, i.IncidentDate, i.Description, i.Status, 
                                 v.FirstName AS VictimFirstName, v.LastName AS VictimLastName, v.DateOfBirth AS VictimDOB, v.Gender AS VictimGender,
                                 v.Address AS VictimAddress, v.PhoneNumber AS VictimPhone
                          FROM Incidents i
                          INNER JOIN Victims v ON i.VictimID = v.VictimID
                          WHERE i.IncidentID = @IncidentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IncidentID", incidentId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"IncidentID: {reader["IncidentID"]}");
                            Console.WriteLine($"IncidentType: {reader["IncidentType"]}");
                            Console.WriteLine($"IncidentDate: {reader["IncidentDate"]}");
                            Console.WriteLine($"Description: {reader["Description"]}");
                            Console.WriteLine($"Status: {reader["Status"]}");

                            Console.WriteLine($"VictimName: {reader["VictimFirstName"]} {reader["VictimLastName"]}");
                            Console.WriteLine($"VictimDOB: {reader["VictimDOB"]}");
                            Console.WriteLine($"VictimGender: {reader["VictimGender"]}");
                            Console.WriteLine($"VictimAddress: {reader["VictimAddress"]}");
                            Console.WriteLine($"VictimPhone: {reader["VictimPhone"]}");
                        }
                    }
                }
            
        }
        }

        //public Reports GenerateIncidentReport(Cases targetCase, List<Cases> casesList)
        //{
        //    if (targetCase != null && casesList != null) // Assuming casesList is required for ReportID calculation
        //    {
        //        var report = new Reports(); // Assuming Reports class has a parameterless constructor or default values

        //        report.ReportID = casesList.Count + 1;
        //        report.IncidentID = targetCase.RelatedIncidents.Select(i => i.IncidentID).ToList();
        //        report.ReportingOfficer = 2;
        //        report.ReportDate = DateTime.Now;
        //        report.ReportDetails = $"Incident report for case {targetCase.CaseID}.";
        //        report.Status = "Draft";

        //        Console.WriteLine($"Incident report is generated successfully. Report ID: {report.ReportID}");
        //        return report;
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException("TargetCase or casesList is null.");
        //    }
        //}

        //public Reports GenerateIncidentReport(Cases targetCase)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
