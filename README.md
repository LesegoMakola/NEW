-- Q.3.1 Write an SQL statement to create the Patient table.
CREATE TABLE Patient (
    PatientID INT PRIMARY KEY,          -- Unique identifier for each patient (Primary Key)
    PatientName VARCHAR(50) NOT NULL,   -- Patient's first name
    PatientSurname VARCHAR(50) NOT NULL,-- Patient's last name
    DateOfBirth DATE NOT NULL           -- Patient's date of birth
);

-- Q.3.2 Write an SQL statement to create the Doctor table.
CREATE TABLE Doctor (
    DoctorID INT PRIMARY KEY,           -- Unique identifier for each doctor (Primary Key)
    DoctorName VARCHAR(50) NOT NULL,    -- Doctor's first name
    DoctorSurname VARCHAR(50) NOT NULL  -- Doctor's last name
);

-- Q.3.3 Write an SQL statement to create the Appointments table.
CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY,      -- Unique identifier for each appointment (Primary Key)
    PatientID INT NOT NULL,             -- References Patient table (Foreign Key)
    DoctorID INT NOT NULL,              -- References Doctor table (Foreign Key)
    AppointmentDate DATE NOT NULL,      -- Date of the appointment
    AppointmentTime TIME NOT NULL,      -- Time of the appointment
    AppointmentDuration INT NOT NULL,   -- Duration in minutes
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),  -- Enforce relationship with Patient table
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID)      -- Enforce relationship with Doctor table
);

-- Q.2.3.4 Write SQL statements to insert the following data into Patient table
INSERT INTO Patient (PatientID, PatientName, PatientSurname, DateOfBirth)
VALUES 
(1, 'Debbie', 'Theart', '1980-03-17'),  -- First patient record
(2, 'Thomas', 'Duncan', '1976-08-12');  -- Second patient record

-- Insert data into Doctor table (from your image)
INSERT INTO Doctor (DoctorID, DoctorName, DoctorSurname)
VALUES 
(1, 'Zirüe', 'Mukari'),
(2, 'Ravi', 'Muharaj');

-- Insert data into Appointments table (from your image, with duration added)
-- Note: Using the Doctor IDs 1 and 2 that match the Doctor table
INSERT INTO Appointments (AppointmentID, PatientID, DoctorID, AppointmentDate, AppointmentTime, AppointmentDuration)
VALUES 
(1, 2, 1, '2025-01-15', '09:00:00', 30),  -- Thomas Duncan with Zirüe Mukari
(2, 2, 2, '2025-01-18', '15:00:00', 30),  -- Thomas Duncan with Ravi Muharaj
(3, 1, 1, '2025-01-20', '10:00:00', 30),  -- Debbie Theart with Zirüe Mukari
(4, 2, 1, '2025-01-21', '11:00:00', 30);  -- Thomas Duncan with Zirüe Mukari

-- Q.3.5 Write an SQL statement to display all the appointments between 2025-01-16 and 2025-01-20 (inclusive)
SELECT 
    AppointmentID,
    PatientID,
    DoctorID,
    AppointmentDate,
    AppointmentTime,
    AppointmentDuration
FROM Appointments
WHERE AppointmentDate BETWEEN '2025-01-16' AND '2025-01-20'
ORDER BY AppointmentDate, AppointmentTime;

-- Q.3.6 Write an SQL statement to display the names and surnames of patients with the total number of appointments they have
SELECT 
    p.PatientName,
    p.PatientSurname,
    COUNT(a.AppointmentID) AS TotalAppointments
FROM Patient p
LEFT JOIN Appointments a ON p.PatientID = a.PatientID
GROUP BY p.PatientID, p.PatientName, p.PatientSurname
ORDER BY TotalAppointments DESC;

-- Q.3.7 Create a view that gets a list of all the patients who have appointments with the doctor with doctor ID 2
CREATE VIEW PatientsWithDoctor2 AS
SELECT DISTINCT
    p.PatientName,
    p.PatientSurname
FROM Patient p
INNER JOIN Appointments a ON p.PatientID = a.PatientID
WHERE a.DoctorID = 2
ORDER BY p.PatientSurname ASC;

-- To display the results from the view:
SELECT * FROM PatientsWithDoctor2;
