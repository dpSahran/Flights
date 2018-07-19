"# Flights" 

This is a REST API which will check availability of flights based on parameters No of Passengers, /Start Date and End Date.
Data store has been created with in the solution by using EntityFrameworkCore.
The initial database seed has been added to FlightDBInitializer.cs. however below connection string from solution will created
a local sql database.
"connectionString:flightDBConnectionString": "Server=(localdb)\\mssqllocaldb;Database=FlightDB;Trusted_Connection=True;",

-------------------------------------------------------------------------
Operation related to check Availabilities are in controller CheckAvailableFlightController.
URI: /api/availableflight/2?startDate=2018-01-01&endDate=2018-03-01

HTTP Method: GET

JSON Response:

[

        {
 
             "flightNumber": "F100", 
             "departTime": "05:00:00",
             "arriveTime": "07:00:00",
             "departure": "Melbourne",
             "arrival": "Sydney",
             "seatAvailable": 27
        },
  
        {
    
             "flightNumber": "F105",
             "departTime": "08:00:00",
             "arriveTime": "10:00:00",
             "departure": "Melbourne",
             "arrival": "Adelaide",
             "seatAvailable": 50
        }
]
