TaskManager

A full-stack task management web application built with ASP.NET Core and Angular.

Tech Stack

Backend (TaskManager.API):
- C# / .NET (ASP.NET Core Web API)
- Clean Multi-Layer Architecture (Domain, DAL, BLL, API)
- Entity Framework Core (Code-First Migrations)
- Database: SQLite (or PostgreSQL)
- Swagger / OpenAPI for API documentation
- Global Exception Handling Middleware & CORS configuration
- Unit Testing: xUnit & Moq

Frontend (TaskManager.Client):
- Angular (Standalone Components) & TypeScript
- Reactive Forms with built-in validation
- RxJS & HttpClient for REST API integration
- HTML5 / CSS3

Features

- CRUD Operations: Create, view, edit, and delete tasks.
- Status Management: Track task progress (To Do, In Progress, Completed).
- Filtering & Search: Filter tasks by status and search by title in real-time.
- Form Validation: Client-side validation for required fields and input length.

Getting Started

Prerequisites
- .NET 8 (or your current .NET SDK version)
- Node.js & npm (for Angular)

Backend Setup
1. Navigate to the API directory:
   ```bash
   cd TaskManager.API
   ```
