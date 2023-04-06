# Doctor Who Web APIs

A .NET 7 Web API project that provides endpoints to manage Doctor Who related data, such as doctors, episodes, authors, companions, and enemies.

## Table of Contents

- [Description](#description)
- [Required Knowledge](#Required-Knowledge)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [APIs](#apis)
  - [Doctors](#doctors)
  - [Episodes](#episodes)
  - [Authors](#authors)
  - [Companions](#companions)
  - [Enemies](#enemies)
- [Project Structure](#project-structure)
- [Technologies and Libraries](#technologies-and-libraries)
- [Author](#Author)
- [License](#License)

## Description

This project is a .NET 7 Web API application that serves as a backend for managing Doctor Who related data. It supports CRUD operations for doctors, episodes, and authors, as well as adding companions and enemies to episodes. The application is built using Entity Framework Core for data access, AutoMapper for object mapping, and FluentValidation for input validation.

## Required Knowledge

To work on this project, it is recommended to have familiarity with the following technologies:

- C#
- .NET Core
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- FluentValidation
- Git


## Prerequisites

- .NET 7 SDK
- SQL Server

## Getting Started

1. Clone the repository 
```shell
git clone https://github.com/OthmanMohammad/Doctor-Who-Web-APIs.git
```
2. Navigate to the project directory
```shell
cd DoctorWho
```
3. Restore the required packages
```shell
dotnet restore
```
4. Build the solution
```shell
dotnet build
```
5. Run the `DoctorWho.Web` project
```shell
cd DoctorWho.Web
dotnet run
```


## APIs

### Doctors

- `GET /api/doctors` - Fetches all doctors.
- `POST /api/doctors` - Upserts a doctor and returns the upserted entity.
- `DELETE /api/doctors/{id}` - Deletes a doctor by ID.

### Episodes

- `GET /api/episodes` - Fetches all episodes.
- `POST /api/episodes` - Creates an episode and returns the new entity ID.
- `POST /api/episodes/{id}/enemies` - Adds an enemy to an episode.
- `POST /api/episodes/{id}/companions` - Adds a companion to an episode.

### Authors

- `PUT /api/authors/{id}` - Updates an author by ID.


### Companions

- `GET /api/companions` - Fetches all companions.

### Enemies

- `GET /api/enemies` - Fetches all enemies.

## Project Structure

- `DoctorWho.Web` - Web API project that exposes the endpoints and handles requests.
- `DoctorWho.Db` - Data access layer with Entity Framework Core and repositories.
- `DoctorWho.Domain` - Domain models representing the Doctor Who entities.

## Technologies and Libraries

- .NET 7 Web API
- Entity Framework Core
- AutoMapper
- FluentValidation

## Author

This project was developed by [Mohammad Othman](https://github.com/OthmanMohammad).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.



