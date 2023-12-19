using CARS.Entities;
using System;
using CARS.Repository;
using System.Collections.Generic;
using System.Net;
using System.Reflection;


// Instantiate services(objects)
IIncidentAnalysis NewIncidentAnalysis = new IncidentAnalysis();
ICrimeAnalysis NewCrimeAnalysis = new CrimeAnalysis();
IReportAnalysis NewReportAnalysis = new ReportAnalysis();
Cases cases = new Cases();


//This is menu loop
string chrr = "y";
do
{
    Console.WriteLine("<<----------WELCOME TO CRIME ANALYSIS AND REPORTING SYSTEM---------->>\n");


    Console.WriteLine("1 for case analysis \n 2 for incident analysis \n 3 for report analysis \n");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        
                                        

        case 1:
            string crty = "y";
            do
            {

                Console.WriteLine("1. Create Case");
                Console.WriteLine("2. Get Case Details");
                Console.WriteLine("3 for Update_Case_Details");
                Console.WriteLine("4 for Get_all_cases");
                Console.WriteLine("5 for exit");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        Console.WriteLine("\nEnter the Case id\n");
                        int cid = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter the Case_Description\n");
                        string casedesc1 = Console.ReadLine();

                        Console.WriteLine("\nEnter the no of RelatedIncidents\n");
                        int rein = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter the case status\n");
                        string status = Console.ReadLine();

                        cases = new Cases()
                        {
                            CaseID = cid,
                            CaseDescription = casedesc1,
                            RelatedIncidents = rein,
                            CaseStatus = status
                        };

                        Console.WriteLine(NewCrimeAnalysis.CreateCase(cases));

                        break;

                    case "2":


                        Console.WriteLine("Enter the case id to get case deatils\n");
                        int caseIdToRetrieve = int.Parse(Console.ReadLine());

                        Cases retrievedCase = NewCrimeAnalysis.GetCaseDetails(caseIdToRetrieve);

                        if (retrievedCase != null)
                        {
                            Console.WriteLine("Case Details:");
                            Console.WriteLine($"Case ID: {retrievedCase.CaseID}");
                            Console.WriteLine($"Description: {retrievedCase.CaseDescription}");
                            Console.WriteLine($"Related Incidents: {retrievedCase.RelatedIncidents}");
                            Console.WriteLine($"Case Status: {retrievedCase.CaseStatus}");
                        }
                        else
                        {
                            Console.WriteLine("Case not found or error retrieving case details.");
                        }

                        Console.ReadLine();


                        break;

                    case "3":
                        Console.WriteLine("Enter the case id ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new case status");
                        string new_case_status = Console.ReadLine();

                        NewCrimeAnalysis.UpdateCaseDetails(new_case_status, id);


                        break;


                    case "4":

                        List<Cases> allCases = NewCrimeAnalysis.GetAllCases();

                        if (allCases.Count > 0)
                        {
                            Console.WriteLine("All Cases:");
                            foreach (var caseItem in allCases)
                            {
                                Console.WriteLine($"Case ID: {caseItem.CaseID}");
                                Console.WriteLine($"Description: {caseItem.CaseDescription}");
                                Console.WriteLine($"Related Incidents: {caseItem.RelatedIncidents}");
                                Console.WriteLine($"Case Status: {caseItem.CaseStatus}");
                                Console.WriteLine("--------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No cases found or error retrieving cases.");
                        }


                        break;

                    case "5":

                        crty = "n";
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;

                }
            } while (crty == "y");
            break;

        case 2:
            string mt1 = "y";
            do
            {

                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident");
                Console.WriteLine("3 Search Incident");
                Console.WriteLine("4 Get Incident by dates");
                Console.WriteLine("5 for exit");
                Console.Write("Please enter your choice: ");
                string choice1 = Console.ReadLine();
                switch (choice1)
                {
                    case "1":

                        Console.WriteLine("Enter the Victim Details ... ");

                        Victims vic = new Victims();

                        Console.WriteLine("Enter victim id: ");
                        int vid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter firstname: ");
                        string firstname = Console.ReadLine();

                        Console.WriteLine("Enter lastname: ");
                        string lastname = Console.ReadLine();

                        Console.WriteLine("Enter the DOB: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime incidentDate))
                        {
                            DateTime Date = incidentDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Using current date as incident date.");
                            DateTime IncidentDate = DateTime.Now;
                        }

                        Console.WriteLine("Enter Gender: ");
                        string gen = Console.ReadLine();

                        Console.WriteLine("Address: ");
                        string add = Console.ReadLine();

                        Console.WriteLine("Phone_Number: ");
                        string phn = Console.ReadLine();

                        vic = new Victims()
                        {
                            VictimID = vid,
                            FirstName = firstname,
                            LastName = lastname,
                            DateOfBirth = incidentDate,
                            Gender = gen,
                            Address = add,
                            PhoneNumber = phn
                        };


                        Console.WriteLine("Enter the Suspect Details ... ");

                        Suspects sic = new Suspects();

                        Console.WriteLine("Enter suspect id: ");
                        int sid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter firstname: ");
                        string firstname1 = Console.ReadLine();

                        Console.WriteLine("Enter lastname: ");
                        string lastname1 = Console.ReadLine();

                        Console.WriteLine("Enter the DOB: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime incidentDate1))
                        {
                            DateTime Date = incidentDate1;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Using current date as incident date.");
                            DateTime IncidentDate = DateTime.Now;
                        }

                        Console.WriteLine("Enter Gender: ");
                        string gen1 = Console.ReadLine();


                        Console.WriteLine("Phone_Number: ");
                        string phn1 = Console.ReadLine();

                        sic = new Suspects()
                        {
                            SuspectID = sid,
                            FirstName = firstname1,
                            LastName = lastname1,
                            DateOfBirth = incidentDate1,
                            Gender = gen1,
                            ContactInformation = phn1

                        };

                        Console.WriteLine("Enter Incident Details: .... ");

                        Incidents newIncident = new Incidents();


                        Console.WriteLine("Enter incident id");

                        newIncident.IncidentID = int.Parse(Console.ReadLine());

                        Console.Write("Incident Type: ");
                        newIncident.IncidentType = Console.ReadLine();

                        Console.Write("Incident Date (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime incidentDate2))
                        {
                            newIncident.IncidentDate = incidentDate2;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Using current date as incident date.");
                            newIncident.IncidentDate = DateTime.Now;
                        }

                        Console.Write("Latitude: ");
                        double latitude;
                        if (double.TryParse(Console.ReadLine(), out latitude))
                        {
                            Console.Write("Longitude: ");
                            double longitude;
                            if (double.TryParse(Console.ReadLine(), out longitude))
                            {
                                string location = $"POINT({longitude} {latitude})"; // Create geography object using WKT format
                                newIncident.Location = location;


                            }
                            else
                            {
                                Console.WriteLine("Invalid input for Longitude.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Latitude.");
                        }

                        Console.Write("Description: ");
                        newIncident.Description = Console.ReadLine();

                        Console.Write("Status: ");
                        newIncident.Status = Console.ReadLine();

                        Console.Write("Victim ID: ");
                        if (int.TryParse(Console.ReadLine(), out int victimID))
                        {
                            newIncident.VictimID = victimID;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Victim ID. Setting to default value (0).");
                            newIncident.VictimID = 0;
                        }

                        Console.Write("Suspect ID: ");
                        if (int.TryParse(Console.ReadLine(), out int suspectID))
                        {
                            newIncident.SuspectId = suspectID;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Suspect ID. Setting to default value (0).");
                            newIncident.SuspectId = 0;
                        }

                        Reports reports = new Reports();

                        Console.WriteLine("Enter report details ...");

                        Console.WriteLine("Enter report id: ");
                        int rid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter reporting_officer: ");
                        int ro = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter report_date (Date): ");
                        int dd = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter report_date (Month): ");
                        int mm = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter report_date (Year): ");
                        int yyyy = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the report_details: ");
                        string rde = Console.ReadLine();

                        Console.WriteLine("Enter the status: ");
                        string s = Console.ReadLine();

                        reports = new Reports()
                        {
                            ReportID = rid,
                            IncidentID = newIncident.IncidentID,
                            ReportingOfficer = ro,
                            ReportDate = new DateTime(yyyy, mm, dd),
                            ReportDetails = rde,
                            Status = s
                        };


                        Console.WriteLine("Enter Law_Enforcement_Agencies details ....");

                        LawEnforcementAgencies la = new LawEnforcementAgencies();

                        Console.WriteLine("Enter the agency_id: ");
                        int agid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the agency_name: ");
                        string n1 = Console.ReadLine();

                        Console.WriteLine("Ennter jurisdiction: ");
                        string j1 = Console.ReadLine();

                        Console.WriteLine("Enter Contact_information: ");
                        string c1 = Console.ReadLine();


                        la = new LawEnforcementAgencies()
                        {
                            AgencyID = agid,
                            AgencyName = n1,
                            Jurisdiction = j1,
                            ContactInformation = c1

                        };


                        Console.WriteLine("Enter officers details ...");

                        Officers oo = new Officers();

                        Console.WriteLine("Enter Officer_Id: ");
                        int oid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter firstname: ");
                        string firstname2 = Console.ReadLine();

                        Console.WriteLine("Enter lastname: ");
                        string lastname2 = Console.ReadLine();

                        Console.WriteLine("Enter badge_number: ");
                        string bn = Console.ReadLine();

                        Console.WriteLine("Enter rank: ");
                        string r = Console.ReadLine();

                        Console.WriteLine("Enter Contact_Information: ");
                        string ci = Console.ReadLine();


                        oo = new Officers()
                        {
                            OfficerID = oid,
                            FirstName = firstname2,
                            LastName = lastname2,
                            BadgeNumber = bn,
                            Rank = r,
                            ContactInformation = ci,
                            AgencyID = la.AgencyID

                        };

                        NewIncidentAnalysis.CreateIncident(newIncident, vic, sic, reports, la, oo);

                        break;

                    case "2":

                        Console.WriteLine("Enter the incident id");
                        int id11 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter new status");
                        string new_status = Console.ReadLine();

                        NewIncidentAnalysis.UpdateIncidentStatus(id11, new_status);

                        break;


                    case "3":
                        Console.Write("Enter Incident ID to search: ");
                        if (int.TryParse(Console.ReadLine(), out int incidentId))
                        {
                            Incidents foundIncident = NewIncidentAnalysis.SearchIncidentsByIncidentID(incidentId);
                            if (foundIncident != null)
                            {
                                Console.WriteLine($"Incident found:");
                                Console.WriteLine($"Incident ID: {foundIncident.IncidentID}");
                                Console.WriteLine($"Incident Type: {foundIncident.IncidentType}");
                                Console.WriteLine($"Incident Date: {foundIncident.IncidentDate}");
                                Console.WriteLine($"Description: {foundIncident.Description}");
                                Console.WriteLine($"Status: {foundIncident.Status}");
                                Console.WriteLine($"Victim ID: {foundIncident.VictimID}");
                                Console.WriteLine($"Suspect ID: {foundIncident.SuspectId}");
                            }
                            else
                            {
                                Console.WriteLine($"Incident with ID {incidentId} not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Incident ID.");
                        }


                        break;


                    case "4":

                        Console.WriteLine("Enter Start Date (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                        {
                            Console.WriteLine("Enter End Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                            {
                                List<Incidents> incidents = NewIncidentAnalysis.GetIncidentsInDateRange(startDate, endDate);
                                if (incidents.Count > 0)
                                {
                                    Console.WriteLine($"Incidents retrieved for the date range: {startDate} to {endDate}.");
                                    foreach (var incident in incidents)
                                    {
                                        Console.WriteLine($"Incident ID: {incident.IncidentID}");
                                        Console.WriteLine($"Incident Type: {incident.IncidentType}");
                                        Console.WriteLine($"Incident Date: {incident.IncidentDate}");
                                        Console.WriteLine($"Description: {incident.Description}");
                                        Console.WriteLine($"Status: {incident.Status}");
                                        Console.WriteLine($"Victim ID: {incident.VictimID}");
                                        Console.WriteLine($"Suspect ID: {incident.SuspectId}");
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No incidents found in the specified date range.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for End Date.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Start Date.");
                        }


                        break;

                    case "5":
                        mt1 = "n";
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;

                }
            } while (mt1 == "y");
            break;

        case 3:
            Console.WriteLine("Enter employee_id: ");
            int eeid = int.Parse(Console.ReadLine());

            NewReportAnalysis.GenerateIncidentReport(eeid);


            break;


    }
    Console.WriteLine("Do you want to continue: ");
    chrr = Console.ReadLine();
    Console.Clear();
} while (chrr == "y");


