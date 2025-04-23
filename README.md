# ✈️ Airline API – Midterm Project
> A midterm project developed for SE4458, implementing a fully functional RESTful airline ticketing API with JWT auth, paging, and Azure deployment.

This is a RESTful Web API for managing airline ticketing operations such as flight scheduling, ticket purchasing, passenger check-in, and querying passenger lists. Developed as part of SE4458 Software Architecture & Design of Modern Large Scale Systems – Midterm.

## ✅ Features

- Add new flights
- Query available flights (with paging support)
- Buy tickets (decrease capacity)
- Check-in passengers (assign seats)
- List passengers (with paging support)
- JWT-based authentication for protected endpoints
- Swagger UI for testing
- Hosted on Azure Web App

## 🚀 Technologies Used

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core (In-Memory)
- JWT Authentication
- Swagger (Swashbuckle)
- Visual Studio Code
- Azure App Service (for deployment)
- Git + GitHub

## 🔐 Authentication
> All endpoints requiring authentication are protected using JWT. Paging is supported where required.

To use protected endpoints, first call:

```
POST /api/v1/auth/login
```

Request Body:
```json
{
  "username": "admin",
  "password": "1234"
}
```

A valid JWT token will be returned.  
Use this token with the **Authorize** button in Swagger UI:

```
Bearer eyJhbGciOi...
```

Protected endpoints:
- `POST /api/v1/flight/add`
- `POST /api/v1/flight/buy`
- `POST /api/v1/flight/passengerlist`

## 📄 API Endpoints Overview

| Endpoint                             | Method | Auth | Paging | Description                          |
|--------------------------------------|--------|------|--------|--------------------------------------|
| `/api/v1/flight/add`                 | POST   | ✔️   | ❌     | Add a new flight                     |
| `/api/v1/flight/query`               | POST   | ❌   | ✔️     | List available flights               |
| `/api/v1/flight/buy`                 | POST   | ✔️   | ❌     | Buy ticket and reduce seat count     |
| `/api/v1/flight/checkin`             | POST   | ❌   | ❌     | Check-in passenger and assign seat   |
| `/api/v1/flight/passengerlist`       | POST   | ✔️   | ✔️     | List checked-in passengers           |
| `/api/v1/auth/login`                 | POST   | ❌   | ❌     | Get a JWT token                      |

## 🧠 Assumptions & Decisions

-System supports only one-way (tek yönlü) flights.
-Seat numbers are automatically assigned as: P1, P2, P3, ...
-All data is stored in memory (no database used)
-No cancel or update functionality for tickets
-Only a single static user exists (admin / 1234)
-Swagger is the only UI provided for manual testing
-Authentication is done via JWT (manually coded)
-Paging is supported for flight queries and passenger lists
-Versioning is implemented in endpoints (ex: /api/v1/...)

## ✅ Example Test Sequence

1. Login and get token ✅  
2. Add a flight  
3. Query flight  
4. Buy ticket  
5. Check-in  
6. Query passenger list

## 🎥 Demo Video

> [📹 Click to Watch the Demo](https://drive.google.com/your-demo-link)

## 🔗 Project Links

[👉 GitHub Repository](https://github.com/utku1608/AirlineApi-Midterm)

[✅ Live Swagger Demo (Azure)](https://airline-api-utku123.azurewebsites.net/swagger/index.html)


## 👨‍💻 Developed by

Utku Derici  
Group 1 – API Project for Airline Company  
SE4458 - Spring 2025
