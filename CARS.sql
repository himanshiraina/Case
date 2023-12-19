--Creating Datbase SQL
CREATE database CARS
--Creating Tables
CREATE TABLE Incidents (
	IncidentID INT PRIMARY KEY,
	IncidentType VARCHAR(255),
	IncidentDate DATE,
	Location VARCHAR(50),
	Description VARCHAR(255),
	Status VARCHAR(50),
	VictimID INT,
	SuspectId INT,
	FOREIGN KEY(VictimID) REFERENCES Victims(VictimID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY(SuspectID) REFERENCES Suspects(SuspectID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Evidence (
    EvidenceID INT PRIMARY KEY,
    Description VARCHAR(255),
    LocationFound VARCHAR(255),
    IncidentID INT,
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Reports (
    ReportID INT PRIMARY KEY,
    IncidentID INT,
    ReportingOfficer INT,
    ReportDate DATE,
    ReportDetails VARCHAR(255),
    Status VARCHAR(50),
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (ReportingOfficer) REFERENCES Officers(OfficerID) ON UPDATE CASCADE ON DELETE CASCADE
);


CREATE TABLE Victims(
	VictimID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    Address VARCHAR(100),
    PhoneNumber VARCHAR(20)
);
	

CREATE TABLE Suspects (
    SuspectID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    ContactInformation VARCHAR(100)
);


CREATE TABLE LawEnforcementAgencies (
    AgencyID INT PRIMARY KEY,
    AgencyName VARCHAR(100),
    Jurisdiction VARCHAR(100),
    ContactInformation VARCHAR(100)
);


CREATE TABLE Officers (
    OfficerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    BadgeNumber VARCHAR(20),
    Rank VARCHAR(50),
    ContactInformation VARCHAR(100),
    AgencyID INT,
    FOREIGN KEY (AgencyID) REFERENCES LawEnforcementAgencies(AgencyID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Cases (
    CaseID INT PRIMARY KEY,
    CaseDescription VARCHAR(50),
	RelatedIncidents INT,
	CaseStatus VARCHAR(50)
)


select * from Incidents;
select * from Cases;
select * from suspects;
select * from victims;
select * from officers;
select * from reports;
select * from LawEnforcementAgencies;

DELETE FROM Suspects
where SuspectID='206';


--Inserting Values

INSERT INTO Incidents (IncidentID, IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES
(2, 'Robbery', '2023-01-15', geography::Point(40.7128, -74.0060, 4326), 'Armed robbery at a convenience store', 'Under Investigation', 106, 206);



INSERT INTO Victims (VictimID, FirstName, LastName, DateOfBirth, Gender, Address, PhoneNumber)
VALUES 
    (106, 'himzi', 'raina', '2001-10-16', 'Female', 'jammu', '6005947423');
	select * from victims;

		select * from suspects;
			select * from incidents;
			select * from reports;



INSERT INTO LawEnforcementAgencies (AgencyID, AgencyName, Jurisdiction, ContactInformation)
VALUES 
    (301, 'City Police Department', 'City A', '123-456-7890'),
    (302, 'County Sheriff Office', 'County B', '987-654-3210'),
    (303, 'State Bureau of Investigation', 'State C', '555-123-4567'),
    (304, 'Federal Bureau of Investigation', 'Federal', '800-555-5555'),
    (305, 'Drug Enforcement Administration', 'National', '888-999-0000');


INSERT INTO Officers (OfficerID, FirstName, LastName, BadgeNumber, Rank, ContactInformation, AgencyID)
VALUES 
    (401, 'Michael', 'Anderson', '1234', 'Detective', 'michael@example.com', 301),
    (402, 'Emily', 'Clark', '5678', 'Sergeant', 'emily@example.com', 302),
    (403, 'Jacob', 'Young', '9876', 'Lieutenant', 'jacob@example.com', 303),
    (404, 'Olivia', 'Brown', '5432', 'Captain', 'olivia@example.com', 304),
    (405, 'William', 'Garcia', '2468', 'Officer', 'william@example.com', 305);

INSERT INTO Evidence (EvidenceID, Description, LocationFound, IncidentID)
VALUES 
    (501, 'Fingerprint on the glass', 'Main Street', 1),
    (502, 'Weapon found near the scene', 'Downtown', 2),
    (503, 'Security footage from the parking lot', 'Parking Lot C', 3),
    (504, 'Bloodstained clothing', 'Bar area', 4),
    (505, 'Footprints at the crime scene', 'Residential area', 5);

INSERT INTO Reports (ReportID, IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES 
    (601, 1, 401, '2023-01-20', 'Detailed report on the robbery incident.', 'Finalized'),
    (602, 2, 402, '2023-02-25', 'Preliminary report on the homicide case.', 'Draft'),
    (603, 3, 403, '2023-03-15', 'Initial report on the theft investigation.', 'Draft'),
    (604, 4, 404, '2023-04-10', 'Report on the assault incident at the bar.', 'Finalized'),
    (605, 5, 405, '2023-05-15', 'Detailed report on the burglary case.', 'Finalized');



SELECT * FROM Evidence 
SELECT * FROM Incidents 
SELECT * FROM Reports 
SELECT * FROM LawEnforcementAgencies 
SELECT * FROM Officers 
SELECT * FROM Suspects 
SELECT * FROM Victims 
SELECT * FROM Cases 





--Create a new incident
select * from Incidents
select * from Victims
select * from Suspects
INSERT INTO Victims (VictimID, FirstName, LastName, DateOfBirth, Gender, Address, PhoneNumber)
VALUES(106,'Smith', 'Jones', '1990-12-05', 'Male', '789 Elm St, Townsville', '555-1230')
INSERT INTO Suspects (SuspectID, FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES(206, 'Charlie', 'Williams', '1990-06-15', 'Male', 'cwilliams@gmail.com')
INSERT INTO Incidents (IncidentID,IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES(6,'Assault', '2023-11-15', geography::Point(35.6895, 139.6917, 4326), 'Physical assault in a public area', 'Under Investigation', 106, 206)



---Update the status of an incident
UPDATE Incidents SET Status='Closed' WHERE IncidentID=1


--Get a list of incidents within a date range
SELECT * FROM Incidents WHERE IncidentDate BETWEEN '2023-03-01' AND '2023-07-01' 

--Search for incidents based on various criteria
SELECT * FROM Incidents 
SELECT * FROM Incidents WHERE IncidentType = 'Robbery' AND Status = 'Closed'


--Generate incident reports
SELECT * FROM Reports
SELECT * FROM Reports WHERE Status = 'Finalized'


--Create a new case and associate it with incidents
-- Create Cases table
CREATE TABLE Cases (
    CaseID INT PRIMARY KEY,
    CaseType VARCHAR(255),
    CaseDescription VARCHAR(500),
)
DROP TABLE Cases
INSERT INTO Cases (CaseID, CaseType, CaseDescription)
VALUES
(1, 'Robbery Case', 'Series of robberies in the city'),
(2, 'Assault Case', 'Assault incidents in the downtown area'),
(3, 'Fraud Case', 'Financial fraud cases involving multiple victims')
SELECT * FROM Cases 
-- Create CaseIncidents table to associate incidents with cases
CREATE TABLE CaseIncidents (
    CaseID INT,
    IncidentID INT,
    PRIMARY KEY (CaseID, IncidentID),
    FOREIGN KEY (CaseID) REFERENCES Cases(CaseID),
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
)

INSERT INTO CaseIncidents (CaseID, IncidentID)
VALUES
(1, 1), 
(1, 3),  
(1, 2),
(2, 4),  
(2, 5)
SELECT * FROM CaseIncidents;
--Get details of a specific case
SELECT * FROM Cases WHERE CaseID = 1


--Update case details
UPDATE Cases SET CaseDescription = 'Assaults in downtown area' WHERE CaseID = 1


--Get a list of all cases
SELECT * FROM Cases