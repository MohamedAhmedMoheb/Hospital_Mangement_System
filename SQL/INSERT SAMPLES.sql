INSERT INTO Patient (P_NAME, Age, P_NUM) VALUES
('Ahmed Hassan', 28, '01012345678'),
('Sara Mohamed', 35, '01098765432'),
('Ali Mahmoud', 42, NULL),
('Mona Adel', 24, '01122334455');

INSERT INTO Department (D_NAME, Location) VALUES
('Cardiology', 'Building A - Floor 1'),
('Neurology', 'Building A - Floor 2'),
('Dentistry', 'Building B - Floor 1'),
('Pediatrics', 'Building B - Floor 2');

INSERT INTO Doctor (DOC_NAME, Specialty, DD_ID) VALUES
('Dr. Khaled Ali', 'Cardiologist', 1),
('Dr. Sara Nabil', 'Neurologist', 2),
('Dr. Ahmed Samy', 'Dentist', 3),
('Dr. Nour Hassan', 'Pediatrician', 4);

INSERT INTO Appointment (Date, Time, DA_ID, PA_ID) VALUES
('2026-04-10', '09:30', 1, 1),
('2026-04-11', '11:00', 2, 2),
('2026-04-12', '13:15', 3, 3),
('2026-04-13', '10:45', 4, 4);

INSERT INTO Prescription (AP_ID, Medication) VALUES
(1, 'Aspirin 75mg'),
(2, 'Paracetamol 500mg'),
(3, 'Ibuprofen 400mg'),
(4, 'Vitamin D3');