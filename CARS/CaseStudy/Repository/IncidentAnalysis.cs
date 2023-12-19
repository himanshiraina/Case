using CARS.Entities;
using CARS.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public class IncidentAnalysis : IIncidentAnalysis
    {
        private static List<Incidents> incidentsList = new List<Incidents>();

        private const string connectionString = "Server=LAPTOP-MK5JT9DU;Database=CARS;Trusted_Connection=True";

        public void CreateIncident(Incidents incident, Victims vic, Suspects sic, Reports res, LawEnforcementAgencies la, Officers off)

        {


            string insertQuery4 = "INSERT INTO LawEnforcementAgencies (AgencyID, AgencyName, Jurisdiction, ContactInformation) VALUES (@aaid, @agn, @jur, @cii)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery4, connection))
                {
                    command.Parameters.AddWithValue("@aaid", la.AgencyID);
                    command.Parameters.AddWithValue("@agn", la.AgencyName);
                    command.Parameters.AddWithValue("@jur", la.Jurisdiction);
                    command.Parameters.AddWithValue("@cii", la.ContactInformation);


                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();


                }
            }

            string insertQuery5 = "INSERT INTO Officers (OfficerID, FirstName, LastName, BadgeNumber, Rank, ContactInformation, AgencyID) VALUES (@ooid, @fi, @lm, @bn, @ra, @ciin, @aifg)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery5, connection))
                {
                    command.Parameters.AddWithValue("@ooid", off.OfficerID);
                    command.Parameters.AddWithValue("@fi", off.FirstName);
                    command.Parameters.AddWithValue("@lm", off.LastName);
                    command.Parameters.AddWithValue("@bn", off.BadgeNumber);
                    command.Parameters.AddWithValue("@ra", off.Rank);
                    command.Parameters.AddWithValue("@ciin", off.ContactInformation);
                    command.Parameters.AddWithValue("@aifg", la.AgencyID);


                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();


                }
            }

            string insertQuery = "INSERT INTO Victims (VictimID, FirstName, LastName, DateOfBirth ,Gender, Address, PhoneNumber) VALUES (@vid, @fn, @ln, @dob, @gen, @add, @phn)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@vid", vic.VictimID);
                    command.Parameters.AddWithValue("@fn", vic.FirstName);
                    command.Parameters.AddWithValue("@ln", vic.LastName);
                    command.Parameters.AddWithValue("@dob", vic.DateOfBirth);
                    command.Parameters.AddWithValue("@gen", vic.Gender);
                    command.Parameters.AddWithValue("@add", vic.Address);
                    command.Parameters.AddWithValue("@phn", vic.PhoneNumber);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    
                }
            }


            string insertQuery1 = "INSERT INTO Suspects (SuspectID, FirstName, LastName, DateOfBirth ,Gender, ContactInformation) VALUES (@sid, @fn1, @ln1, @dob1, @gen1, @phn1)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery1, connection))
                {
                    command.Parameters.AddWithValue("@sid", sic.SuspectID);
                    command.Parameters.AddWithValue("@fn1", sic.FirstName);
                    command.Parameters.AddWithValue("@ln1", sic.LastName);
                    command.Parameters.AddWithValue("@dob1", sic.DateOfBirth);
                    command.Parameters.AddWithValue("@gen1", sic.Gender);
                    command.Parameters.AddWithValue("@phn1", sic.ContactInformation);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    
                }
            }







            string insertQuery2 = "INSERT INTO Incidents (IncidentID, IncidentType, IncidentDate, Location ,Description, Status, VictimID, SuspectID) VALUES (@IncidentID, @IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimID, @SuspectID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery2, connection))
                {
                    command.Parameters.AddWithValue("@IncidentID", incident.IncidentID);
                    command.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    command.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                    command.Parameters.AddWithValue("@Location", incident.Location);
                    command.Parameters.AddWithValue("@Description", incident.Description);
                    command.Parameters.AddWithValue("@Status", incident.Status);
                    command.Parameters.AddWithValue("@VictimID", incident.VictimID);
                    command.Parameters.AddWithValue("@SuspectID", incident.SuspectId);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                   
                }
            }


 

           







            string insertQuery3 = "INSERT INTO Reports (ReportID, IncidentID, ReportingOfficer, ReportDate , ReportDetails, Status) VALUES (@rid, @inci, @roff, @redate, @rede, @sta)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery3, connection))
                {
                    command.Parameters.AddWithValue("@rid", res.ReportID);
                    command.Parameters.AddWithValue("@inci", incident.IncidentID);
                    command.Parameters.AddWithValue("@roff", off.OfficerID);
                    command.Parameters.AddWithValue("@redate", res.ReportDate);
                    command.Parameters.AddWithValue("@rede", res.ReportDetails);
                    command.Parameters.AddWithValue("@sta", res.Status);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                }
            }


        }


        public void UpdateIncidentStatus(int incidentId, string newStatus)
        {
            string updateQuery = "UPDATE Incidents SET Status = @NewStatus WHERE IncidentID = @IncidentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@IncidentID", incidentId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Incident {incidentId} status updated to {newStatus}.");
                    }
                    else
                    {
                        throw new IncidentNumberNotFoundException(incidentId);
                    }
                }
            }
        }




        public Incidents SearchIncidentsByIncidentID(int incidentId)
        {
            Incidents incident = null;
            string selectQuery = "SELECT * FROM Incidents WHERE IncidentID = @IncidentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@IncidentID", incidentId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            incident = new Incidents
                            {
                                IncidentID = (int)reader["IncidentID"],
                                IncidentType = reader["IncidentType"].ToString(),
                                IncidentDate = (DateTime)reader["IncidentDate"],
                                Description = reader["Description"].ToString(),
                                Status = reader["Status"].ToString(),
                                VictimID = (int)reader["VictimID"],
                                SuspectId = (int)reader["SuspectId"]
                            };
                        }
                    }
                    connection.Close();
                }
            }

            return incident;
        }


        public List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incidents> incidents = new List<Incidents>();
            string selectQuery = "SELECT * FROM Incidents WHERE IncidentDate >= @StartDate AND IncidentDate <= @EndDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Incidents incident = new Incidents
                            {
                                IncidentID = (int)reader["IncidentID"],
                                IncidentType = reader["IncidentType"].ToString(),
                                IncidentDate = (DateTime)reader["IncidentDate"],
                                Description = reader["Description"].ToString(),
                                Status = reader["Status"].ToString(),
                                VictimID = (int)reader["VictimID"],
                                SuspectId = (int)reader["SuspectId"]
                            };
                            incidents.Add(incident);
                        }
                    }
                    connection.Close();
                }
            }

            Console.WriteLine($"Incidents retrieved for the date range: {startDate} to {endDate}.");
            return incidents;
        }


    }
}
