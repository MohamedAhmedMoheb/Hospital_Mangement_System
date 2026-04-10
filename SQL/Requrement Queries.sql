
--Filtering + Sorting

SELECT * FROM Patient
WHERE Age > 30
ORDER BY Age DESC;

SELECT * FROM Doctor
WHERE DD_ID = 1
ORDER BY DOC_NAME ASC;

--Aggregate
SELECT COUNT(*) AS TotalPatients FROM Patient;

SELECT AVG(Age) AS AverageAge FROM Patient;

SELECT MIN(Age) AS YoungestPatient FROM Patient;

--Join

SELECT 
    p.P_NAME AS PatientName,
    d.DOC_NAME AS DoctorName,
    a.Date,
    a.Time
FROM Appointment a
JOIN Patient p ON a.PA_ID = p.P_ID
JOIN Doctor d ON a.DA_ID = d.DOC_ID;

--Null Handling

SELECT * FROM Patient
WHERE P_NUM IS NULL;
