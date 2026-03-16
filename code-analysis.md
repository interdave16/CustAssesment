
Blazor forms use:

- `EditForm`
- `DataAnnotationsValidator`
- `ValidationMessage`

This allows validation errors to be shown directly in the UI before sending requests to the API.

---

## Error Handling

Basic error handling is implemented in the service layer when calling API endpoints.

Examples include:

- Checking HTTP response status codes
- Displaying success or failure messages in the UI
- Preventing invalid form submissions through validation

This helps provide feedback to the user when operations fail.

---

## Strengths

- Clean separation of concerns between UI, API, and shared models
- Simple and readable project structure
- Shared model reuse between API and UI
- Use of Blazor `EditForm` with DataAnnotations validation
- RESTful API design for CRUD operations
- Basic error handling implemented in service calls

---

## Limitations

The current implementation is intentionally simple and has several limitations:

- Customer data is stored in memory and is lost when the API restarts
- No database persistence
- No authentication or authorization
- Minimal logging and diagnostics
- No automated unit tests
- Limited UI styling and user experience features

---

## Potential Improvements

If this project were extended further, several improvements could be made.

### Database Integration

Replace the in-memory list with a database using:

- Entity Framework Core
- SQL Server or PostgreSQL

### API Improvements

- Introduce a service/repository layer in the API
- Use DTOs to separate API contracts from domain models
- Add centralized exception handling middleware
- Add structured logging using ILogger

### UI Improvements

- Loading indicators during API requests
- Confirmation dialogs for delete operations
- Improved styling and layout
- Pagination or filtering for large customer lists

### Testing

Add automated tests including:

- Unit tests for services
- API endpoint tests
- UI component tests

---

## Summary

This project demonstrates a functional full-stack .NET architecture using:

- ASP.NET Core Web API
- Blazor
- Shared class libraries

The solution is structured in a way that supports future expansion while remaining simple enough to demonstrate core CRUD functionality and architectural separation.