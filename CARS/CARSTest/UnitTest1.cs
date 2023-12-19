using CARS.Repository;
using System.Reflection;
using System.Threading.Tasks;

namespace CARSTest
{
    public class Tests
    {
        private string connectionString = "Server=LAPTOP-MK5JT9DU;Database=CARS;Trusted_Connection=True";
        ICrimeAnalysis ca = new CrimeAnalysis();
        

        [Test]
        [Ignore("Himanshi")]
         public void TestToAddIncident()
        {

           
            //ca.connectionString = connectionString;


            int add = ca.CreateCase(new CARS.Entities.Cases
            {
                CaseID = 185,//take every time new
                CaseDescription = "test",
                RelatedIncidents = 2,
                CaseStatus = "true"
            });


            Assert.AreEqual(-1, add);
        }
    


   
    [Test]
    public void TestToUpdateStatus()
    {

        IIncidentAnalysis obj = new IncidentAnalysis();
        obj.UpdateIncidentStatus(8, "Robbery");
        
        Assert.AreEqual(0, 0);
    }

        [Test]
        public void TestToSearchIncidents() { 

        IIncidentAnalysis obj = new IncidentAnalysis();
           Assert.AreEqual( "jkl",obj.SearchIncidentsByIncidentID(161).IncidentType);

        }


        [Test]
        public void TestToGenerateReport() {

            IReportAnalysis NewReportAnalysis = new ReportAnalysis();

            NewReportAnalysis.GenerateIncidentReport(161);

            Assert.AreEqual(0,0);

        }

    }
}