INSERT INTO Vehicle (RegistrationNumber, VehicleType, Capacity, Status) VALUES
('ISL-1234', 'Bus', 40, 'active'),
('KHI-5678', 'Mini Bus', 20, 'active'),
('LHE-9012', 'Coach', 50, 'active'),
('RWP-3456', 'Van', 15, 'maintenance'),
('MUL-7890', 'Mini Bus', 20, 'active'),
('FSD-1122', 'Bus', 40, 'active'),
('HYD-3344', 'Coach', 50, 'active'),
('QTA-5566', 'Van', 15, 'active'),
('SUK-7788', 'Bus', 40, 'maintenance'),
('PEW-9900', 'Mini Bus', 20, 'active');

INSERT INTO Driver (Name, LicenseNumber, ContactInfo, Status) VALUES
('Ahmed Khan', 'LIC12345678', '+923001234567', 'available'),
('Sara Ali', 'LIC23456789', '+923112345678', 'available'),
('Mohsin Hayat', 'LIC34567890', '+923212345679', 'on leave'),
('Zara Naeem', 'LIC45678901', '+923322345670', 'available'),
('Faisal Qureshi', 'LIC56789012', '+923432345671', 'available'),
('Hina Altaf', 'LIC67890123', '+923542345672', 'on leave'),
('Ali Zafar', 'LIC78901234', '+923652345673', 'available'),
('Sana Javed', 'LIC89012345', '+923762345674', 'available'),
('Waqar Younis', 'LIC90123456', '+923872345675', 'available'),
('Imran Abbas', 'LIC01234567', '+923982345676', 'available');

INSERT INTO Route (StartLocation, EndLocation, Distance, EstimatedTime) VALUES
('Islamabad', 'Lahore', 380, '04:00:00'),
('Karachi', 'Hyderabad', 160, '02:00:00'),
('Lahore', 'Multan', 350, '03:30:00'),
('Peshawar', 'Islamabad', 180, '02:15:00'),
('Quetta', 'Karachi', 690, '08:00:00'),
('Faisalabad', 'Lahore', 140, '01:45:00'),
('Rawalpindi', 'Murree', 64, '01:30:00'),
('Multan', 'Bahawalpur', 100, '01:10:00'),
('Karachi', 'Lahore', 1215, '15:00:00'),
('Sialkot', 'Lahore', 125, '01:40:00');

INSERT INTO Schedule (RouteID, VehicleID, DriverID, DepartureTime, ArrivalTime) VALUES
(1, 1, 1, '2024-03-20 06:00:00', '2024-03-20 10:00:00'),
(2, 2, 2, '2024-03-20 07:00:00', '2024-03-20 09:00:00'),
(3, 3, 3, '2024-03-21 08:00:00', '2024-03-21 11:30:00'),
(4, 4, 4, '2024-03-21 09:00:00', '2024-03-21 11:15:00'),
(5, 5, 5, '2024-03-22 05:00:00', '2024-03-22 13:00:00'),
(6, 6, 6, '2024-03-22 10:00:00', '2024-03-22 11:45:00'),
(7, 7, 7, '2024-03-23 08:00:00', '2024-03-23 09:30:00'),
(8, 8, 8, '2024-03-23 12:00:00', '2024-03-23 13:10:00'),
(9, 9, 9, '2024-03-24 07:00:00', '2024-03-24 22:00:00'),
(10, 10, 10, '2024-03-24 06:00:00', '2024-03-24 07:40:00');

INSERT INTO Passenger (Name, ContactInfo) VALUES
('Ali Raza', '+923331234567'),
('Sana Mir', '+923001234568'),
('Hamza Ali', '+923001234569'),
('Nadia Khan', '+923001234570'),
('Umar Gul', '+923001234571'),
('Ayesha Omar', '+923001234572'),
('Fawad Khan', '+923001234573'),
('Mahira Khan', '+923001234574'),
('Atif Aslam', '+923001234575'),
('Saba Qamar', '+923001234576');

INSERT INTO Booking (ScheduleID, PassengerID, BookingTime, SeatNumber, PaymentStatus) VALUES
(3, 5, '2024-03-20 13:30:00', 4, 'pending'),
(4, 6, '2024-03-21 10:30:00', 8, 'completed'),
(5, 7, '2024-03-22 04:45:00', 10, 'completed'),
(6, 8, '2024-03-22 09:15:00', 15, 'completed'),
(7, 9, '2024-03-23 07:30:00', 20, 'completed'),
(8, 10, '2024-03-23 11:45:00', 24, 'pending'),
(9, 1, '2024-03-24 08:00:00', 28, 'completed'),
(10, 2, '2024-03-24 05:30:00', 32, 'completed');




