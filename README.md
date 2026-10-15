# Student Enrollment System

A modern, full-stack student enrollment application built with a high-performance **.NET 6 API** back-end and a responsive **Vue 3** front-end. The system utilizes the **CQRS (Command Query Responsibility Segregation)** pattern via MediatR, paired with **Dapper** and **Entity Framework Core** for optimized data access.

## 🚀 Features

- **Comprehensive Workflows**: Full CRUD capabilities for managing student profiles and subject enrollments.
- **Advanced Architecture**: Backend decoupled using the **CQRS pattern** for clean separation of commands and queries.
- **Hybrid Data Access**: Combines **EF Core** for robust write operations and object-relational mapping with **Dapper** for ultra-fast, high-performance read queries.
- **Modern Frontend**: Single Page Application (SPA) built with **Vue 3 and Vite**, featuring dynamic routing, global state management, and fully responsive forms.
- **Developer-Friendly Tooling**: Seamless local development configuration utilizing **SPA proxying** and interactive **Swagger API documentation**.

## 🛠️ Tech Stack

### Back-End
- **Framework**: .NET 6 Web API
- **Design Pattern**: CQRS with MediatR
- **Data Access**: Entity Framework Core & Dapper
- **Database**: SQL Server
- **Validation**: FluentValidation / Built-in Model Validation

### Front-End
- **Framework**: Vue 3 (Composition API)
- **Build Tool**: Vite
- **State Management & Routing**: Vue Router & Pinia / Vuex

---

## 🏁 Getting Started

Follow these steps to get a local copy of the project up and running.

### Prerequisites
- [.NET 6 SDK](https://microsoft.com)
- [Node.js](https://nodejs.org) (v16+ recommended)
- [SQL Server](https://microsoft.com) (LocalDB or Express)

### Database Setup
1. Update the connection string in the backend project's `appsettings.json` to point to your local SQL Server instance.
2. Run Entity Framework migrations to seed the database schema:
   ```bash
   dotnet ef database update
   ```

### Installation & Running Locally

The project is configured with **SPA proxying**, allowing the .NET backend to host and proxy requests to the Vite development server smoothly.

1. **Clone the repository:**
   ```bash
   git clone https://github.com
   cd your-repo-name
   ```

2. **Restore and run the Backend API:**
   ```bash
   cd BackendProjectName
   dotnet restore
   dotnet run
   ```
   *The API will start, and you can access the **Swagger UI** at `https://localhost:xxxx/swagger` to explore endpoints.*

3. **Install and run the Frontend:**
   ```bash
   cd FrontendProjectName
   npm install
   npm run dev
   ```

---

## 🔍 API Documentation

Once the backend application is running, full interactive API documentation is available via **Swagger**. This allows you to test the student and subject enrollment, update, delete, and query endpoints directly from your browser.

---

## ⚠️ Pre-Commit Checklist

Before committing or pushing code to this repository, please ensure you complete the following tasks:
- [ ] **Security Review**: Ensure no generated certificates, private keys, or sensitive credentials are plain-text in the codebase.
- [ ] **Git Hygiene**: Check your `.gitignore` file and remove any duplicated ignore-file content or redundant rules.
