using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class Cases
    {
        public int CaseID { get; set; }
        public string CaseDescription { get; set; }
        public int RelatedIncidents { get; set; }
        public string CaseStatus { get; set; }


        public Cases() { }

        public Cases(int caseID, string caseDescription, int relatedIncidents, string caseStatus)
        {
            CaseID = caseID;
            CaseDescription = caseDescription;
            RelatedIncidents = relatedIncidents;
            CaseStatus = caseStatus;
        }
    }
}
