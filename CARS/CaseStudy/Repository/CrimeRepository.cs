using CARS.Utility;
using System.Data.SqlClient;


namespace CARS.Repository
{
    public class CrimeRepository : ICrimeRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        public CrimeRepository()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-MK5JT9DU;Database=CARS;Trusted_Connection=True");
            connectionString = DBConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

    }
}
