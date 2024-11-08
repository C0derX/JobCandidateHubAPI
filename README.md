# JobCandidateHubApi

This is a simple Candidate API built using .NET 8  with SQLite as the database. The API allows for creating or 
updating candidate information, using their email as a unique identifier.

The application is designed with the goal of being self-deploying, meaning you can simply run the solution in 
Visual Studio or through the .NET CLI to get the application up and running with no additional configuration needed.

Table of Contents
Overview
Features
Technologies Used
Usage
Endpoints
Improvements
Conclusion

Overview
This is a REST API designed to store and manage information about job candidates. It supports operations for creating 
and updating candidate profiles. The profile includes personal details such as name, email, phone number, LinkedIn and 
GitHub profiles, as well as a free-text comment.

The database used is SQLite, and the application is designed so that it can be easily extended to other database systems
in the future.

Features
1.Create a new candidate profile if the candidate does not exist.
2.Update an existing candidate profile if the email already exists in the system.
3.Data is stored in an SQLite database (or can be configured to use other databases).
4.Input validation to ensure required fields are present.
5.Simple, easy-to-use API that can be consumed by other systems or front-end applications.

Technologies Used
1. .NET 6 (or later) for API development
2. SQLite for local data storage (without EF Core migrations)
3. Repository Pattern
4. Moq for mocking dependencies in tests
5. ASP.NET Core for building RESTful API services

Usage
Once the application is running, you can interact with the API through HTTP requests. Below are the details of the
available endpoints.

Endpoints
POST http://localhost:5000/api/candidates
Creates a new candidate profile or updates an existing one.

Request Body
{
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "+1234567890",
  "email": "john.doe@example.com",
  "timeIntervalToCall": "2:00 PM - 4:00 PM",
  "linkedInProfile": "https://www.linkedin.com/in/johndoe",
  "gitHubProfile": "https://github.com/johndoe",
  "comment": "Looking for a full-time position."
}

Response
200 OK: Successfully created or updated the candidate profile.
400 Bad Request: If the request body is invalid (e.g., missing required fields).
404 Not Found: If an issue occurs during processing.

Endpoints
get http://localhost:5000/api/candidates
Gets all the candidates information 

Response
if status is 200 ok

[
    {
        "id": 1,
        "firstName": "John",
        "lastName": "Doe",
        "phoneNumber": "+123456789",
        "email": "johndoe@example.com",
        "timeIntervalToCall": "9AM - 12PM",
        "linkedInProfile": "https://www.linkedin.com/in/johndoe",
        "gitHubProfile": "https://github.com/johndoe",
        "comment": "Looking for a developer role."
    },
    {
        "id": 2,
        "firstName": "Henry",
        "lastName": "Doe",
        "phoneNumber": "+123456789",
        "email": "henrydoe@gmail.com",
        "timeIntervalToCall": "9AM - 12PM",
        "linkedInProfile": "https://www.linkedin.com/in/henrydoe",
        "gitHubProfile": "https://github.com/henrydoe",
        "comment": "Looking for a developer role."
    }
]

Endpoints
get http://localhost:5000/api/candidates/{email}
Gets a single candidates information 

Response
if 200 stauts ok 

{
    "id": 1,
    "firstName": "John",
    "lastName": "Doe",
    "phoneNumber": "+123456789",
    "email": "janedoe@example.com",
    "timeIntervalToCall": "9AM - 12PM",
    "linkedInProfile": "https://www.linkedin.com/in/johndoe",
    "gitHubProfile": "https://github.com/johndoe",
    "comment": "Looking for a developer role."
}


Improvements
1. Implementation of login system and ui
2. Using a better Database with login info for secure storing of data
3. Authentication and Authroization
4. Anyone with api endpoints can access the data so need to implements authorization for data retrival. 

Conclusion
This API provides a simple, self-deploying solution for storing and managing candidate information. 
You can easily extend this project by adding new endpoints or modifying the data storage solution. 
The application is ready for use, and you can interact with it through standard HTTP requests.