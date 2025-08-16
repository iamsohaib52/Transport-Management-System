# Transport Management System

A desktop-based application built in **C# (Windows Forms)** with **MS SQL Server** as the backend database.  
Designed to manage and streamline transportation operations including vehicles, routes, schedules, drivers, passengers, and bookings.

## Features
- **User Authentication**: Login system for authorized access.
- **Vehicle Management**: Add, update, and track vehicle status (active, maintenance).
- **Driver Management**: Store driver details and availability.
- **Route Management**: Define routes with distance and estimated time.
- **Schedule Management**: Assign routes, vehicles, and drivers to trips.
- **Passenger & Booking Management**: Handle passenger details, bookings, and payment status.

## Database Schema
Entities:
- **Vehicle**
- **Driver**
- **Route**
- **Schedule**
- **Passenger**
- **Booking**

Relationships:
- One Route → Many Schedules  
- One Vehicle → Many Schedules  
- One Driver → Many Schedules  
- One Schedule → Many Bookings  
- One Passenger → Many Bookings  

## Tech Stack
- **Frontend**: C# Windows Forms (Visual Studio)
- **Backend**: MS SQL Server

## Folder Structure
```
src/   → Application source code
docs/  → Documentation, ERD, SQL scripts, PPT
```

## Setup Instructions
1. Restore the database using the SQL scripts in `docs/`.
2. Open the C# project in Visual Studio from the `src/` folder.
3. Update the database connection string in the config file.
4. Build and run the application.

---

**Author:** Muhammad Sohaib  
**Course:** Database Systems (5th Semester)
```
  