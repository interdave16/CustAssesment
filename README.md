# Customer CRUD Assessment

## Overview
This project is a full-stack Customer CRUD application built using:

- ASP.NET Core Web API  
- Blazor Server (Interactive Components)  
- Shared Class Library  

The application demonstrates a clean separation of concerns between the API, UI, and shared models, following a simple layered architecture.

---

## Solution Structure

CustAssesment.Api   → REST API (CRUD endpoints)  
CustAssesment       → Blazor UI (client application)  
Shared              → Shared models (DTOs)  

- CustAssesment.Api handles all data operations  
- CustAssesment provides the user interface and consumes the API  
- Shared contains models reused across both projects  

---

## Features

- View all customers  
- Add new customers (modal form)  
- Edit existing customers (modal form)  
- Delete customers with confirmation modal  
- Form validation using EditForm and DataAnnotations  
- Responsive UI built with Bootstrap  

---

## Architecture & Design Decisions

### Service Layer
The UI communicates with the API through an ICustomerService:
- Encapsulates HTTP calls  
- Keeps UI logic clean  
- Improves maintainability and testability  

### Shared Models
The Shared project contains the Customer model used by both API and UI:
- Eliminates duplication  
- Ensures consistency across layers  

### Code-Behind Pattern
Blazor components use .razor.cs code-behind files:
- Separates UI markup from logic  
- Improves readability and organization  

### Modal-Based UX
Customer create and edit operations are handled using Bootstrap modals:
- Keeps users in context  
- Reduces page navigation  
- Provides a smoother user experience  

---

## How to Run

1. Open the solution in Visual Studio  
2. Set Multiple Startup Projects:
   - CustAssesment.Api  
   - CustAssesment  
3. Run the solution  
4. Navigate to:

`/customerCrud`

---

## API Details

Base URL (default):  
`http://localhost:5062/api/customers`

### Endpoints

- GET `/api/customers` → Retrieve all customers  
- POST `/api/customers` → Create a new customer  
- PUT `/api/customers/{id}` → Update an existing customer  
- DELETE `/api/customers/{id}` → Delete a customer  

---

## Notes

- Customer data is stored in an in-memory collection for simplicity  
- This can be easily extended to use a database (e.g., EF Core with SQL Server)  
- The project structure is designed for scalability and maintainability  

---

## Future Improvements

- Add search and filtering  
- Implement pagination  
- Replace in-memory data with persistent storage  
- Add logging and centralized error handling  
- Introduce unit and integration tests  

---

## Summary

This project demonstrates:

- A clean multi-project architecture  
- Proper separation of concerns  
- Reusable shared models  
- A service-based communication pattern  
- A responsive and user-friendly UI  