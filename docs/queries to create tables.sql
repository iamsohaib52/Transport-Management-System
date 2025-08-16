-- Vehicle table
CREATE TABLE Vehicle (
    VehicleID INT PRIMARY KEY IDENTITY(1,1),
    RegistrationNumber VARCHAR(20) NOT NULL,
    VehicleType VARCHAR(50),
    Capacity INT,
    Status VARCHAR(20) NOT NULL,
    CONSTRAINT CHK_Vehicle_Status CHECK (Status IN ('active', 'maintenance'))
);

-- Driver table
CREATE TABLE Driver (
    DriverID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    LicenseNumber VARCHAR(20) NOT NULL,
    ContactInfo VARCHAR(100),
    Status VARCHAR(20) NOT NULL,
    CONSTRAINT CHK_Driver_Status CHECK (Status IN ('available', 'on leave'))
);

-- Route table
CREATE TABLE Route (
    RouteID INT PRIMARY KEY IDENTITY(1,1),
    StartLocation VARCHAR(100) NOT NULL,
    EndLocation VARCHAR(100) NOT NULL,
    Distance FLOAT,
    EstimatedTime TIME
);

-- Schedule table
CREATE TABLE Schedule (
    ScheduleID INT PRIMARY KEY IDENTITY(1,1),
    RouteID INT,
    VehicleID INT,
    DriverID INT,
    DepartureTime DATETIME,
    ArrivalTime DATETIME,
    CONSTRAINT FK_Schedule_RouteID FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    CONSTRAINT FK_Schedule_VehicleID FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID),
    CONSTRAINT FK_Schedule_DriverID FOREIGN KEY (DriverID) REFERENCES Driver(DriverID)
);

-- Passenger table
CREATE TABLE Passenger (
    PassengerID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    ContactInfo VARCHAR(100)
);

-- Booking table
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    ScheduleID INT,
    PassengerID INT,
    BookingTime DATETIME,
    SeatNumber INT,
    PaymentStatus VARCHAR(20) NOT NULL,
    CONSTRAINT CHK_Booking_PaymentStatus CHECK (PaymentStatus IN ('pending', 'completed')),
    CONSTRAINT FK_Booking_ScheduleID FOREIGN KEY (ScheduleID) REFERENCES Schedule(ScheduleID),
    CONSTRAINT FK_Booking_PassengerID FOREIGN KEY (PassengerID) REFERENCES Passenger(PassengerID)
);

ALTER TABLE Vehicle ADD CONSTRAINT UQ_RegistrationNumber UNIQUE (RegistrationNumber);
ALTER TABLE Driver ADD CONSTRAINT UQ_LicenseNumber UNIQUE (LicenseNumber);