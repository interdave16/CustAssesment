# Customer CRUD Assessment

## Overview
This project is a simple Customer CRUD application built using:

- ASP.NET Core Web API
- Blazor Web App
- Shared Class Library

The application demonstrates a basic full-stack architecture with a clean separation between the API, UI, and shared models.

## Solution Structure

CustAssesment.Api  
REST API providing CRUD endpoints for customers.

CustAssesment  
Blazor UI that consumes the API through a service layer.

Shared  
Shared class library containing reusable models.

## Features

- View customers
- Create new customer
- Edit customer
- Delete customer
- Form validation using EditForm and DataAnnotations

## Architecture

The solution uses a 3-project structure:

CustAssesment.Api → Web API  
CustAssesment → Blazor UI  
Shared → Shared models

Both the API and UI reference the Shared project for model reuse.

## How to Run

1. Open the solution in Visual Studio
2. Set multiple startup projects:
   - CustAssesment.Api
   - CustAssesment
3. Run the solution
4. Navigate to:

/customerCrud

## Notes

Customer data is currently stored in an in-memory list within the API controller.  
This keeps the project simple for demonstration purposes.