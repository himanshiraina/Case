using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public interface ICrimeAnalysis
    {
       public int CreateCase(Cases c);
        Cases GetCaseDetails(int caseId);
        void UpdateCaseDetails(string newStatus, int caseid);
        List<Cases> GetAllCases();
    }
}
