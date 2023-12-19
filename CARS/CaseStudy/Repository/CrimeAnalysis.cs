using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public class CrimeAnalysis : ICrimeAnalysis                                                                       
    {
        //private static List<Cases> casesList = new List<Cases>();
        private const string connectionString = "Server=LAPTOP-MK5JT9DU;Database=CARS;Trusted_Connection=True";

        public int CreateCase(Cases c)
        {

            string insertQuery = "INSERT INTO Cases (CaseID, CaseDescription, RelatedIncidents, CaseStatus) VALUES (@caseid, @casedesc, @relinc ,@CaseStatus)";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@caseid", c.CaseID);
                    command.Parameters.AddWithValue("@casedesc", c.CaseDescription);
                    command.Parameters.AddWithValue("@relinc", c.RelatedIncidents);
                    command.Parameters.AddWithValue("@CaseStatus", c.CaseStatus);
                    
                    connection.Open();
                    object result = command.ExecuteScalar();

                    int lastInsertedId = 0;
                    if (result != null && int.TryParse(result.ToString(), out lastInsertedId))
                    {
                        return lastInsertedId;
                    }
                    else
                    {
                        return -1; 
                    }
                }
            }
        }


        public Cases GetCaseDetails(int caseId)
        {
            Cases targetCase = null;
            string selectQuery = "SELECT * FROM Cases WHERE CaseID = @CaseId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CaseId", caseId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            targetCase = new Cases
                            {
                                CaseID = (int)reader["CaseID"],
                                CaseDescription = reader["CaseDescription"].ToString(),
                                RelatedIncidents = (int)reader["RelatedIncidents"],
                                CaseStatus = reader["CaseStatus"].ToString()
                            };
                            //Console.WriteLine(targetCase.CaseID);
                        }
                    }
                    connection.Close();
                }
            }

            return targetCase;
        }





        public void UpdateCaseDetails(string newStatus, int caseid)
        {

            string updateQuery = "UPDATE Cases SET CaseStatus = @NewStatus WHERE CaseID = @CaseId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@CaseId", caseid);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {

                        Console.WriteLine("\n Updated successfully ...");

                    }


                    else
                    {
                        // You can throw an exception or handle this scenario based on your requirements
                    }
                   }
                
            }
        }


        public List<Cases> GetAllCases()
        {
            List<Cases> casesList = new List<Cases>();
            string selectQuery = "SELECT * FROM Cases";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cases caseItem = new Cases
                            {
                                CaseID = (int)reader["CaseID"],
                                CaseDescription = reader["CaseDescription"].ToString(),
                                RelatedIncidents = (int)reader["RelatedIncidents"],
                                CaseStatus = reader["CaseStatus"].ToString()
                            };
                            // Add 'caseItem' to the list
                            casesList.Add(caseItem);
                        }
                    }
                    connection.Close();
                }
            }

            Console.WriteLine("All the cases are retrieved successfully.");
            return casesList;
        }

    }
}
