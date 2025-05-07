# Boeken Catalogus - C# .NET Application

This is a simple **book catalog** application built with **C#**, **.NET**, **Entity Framework**, and **ASP.NET**. The application allows users to add, edit, delete, and search books based on title, author, or genre.

## Features

- **Add, Edit, Delete Books**: Users can manage their book collection easily.
- **Search**: Search books by title, author, or genre.
- **REST API**: Exposes endpoints for CRUD operations to interact with the book database.

## Technologies Used

- **C#**: Programming language used for backend logic.
- **ASP.NET**: Framework used to build the web interface and expose REST APIs.
- **Entity Framework**: ORM used for database management, linking C# data models to a database.
- **MySQL Database**: Stores book information, using **Entity Framework** for data manipulation.

## Installation

1. Clone this repository:
    ```bash
    git clone https://github.com/ShaunyPersy/bookTracker.git
    ```

2. Open the solution in **Visual Studio** or your preferred C# IDE.

3. Install required NuGet packages:
    ```bash
    dotnet restore
    ```

4. Set up your **SQL database**:
    - The project uses **Entity Framework** migrations. Run the following command to apply the migrations and set up your database:
      ```bash
      dotnet ef database update
      ```

## Secrets Management

For **grading purposes**, a `secrets.env` file has been included with sensitive information. **This file should not be committed to a public repository** in a production or development environment.

To use the `secrets.env`:
1. Place the `secrets.env` file in the root directory of the project.
2. Ensure that sensitive information like API keys, database connection strings, and authentication credentials are stored securely.
   
### Secure Management in Production:
In a real production instance, **secrets** should be managed in a more secure way. For example:
- Use environment variables or a **secret management tool** (like Azure Key Vault, AWS Secrets Manager, or HashiCorp Vault).
- Avoid hardcoding sensitive information in your codebase or in files tracked by version control.

## Running the Application

To run the application locally, use the following command:

```bash
dotnet run
```

## Demo
https://github.com/user-attachments/assets/1e3a3b61-6d47-4974-8a78-8b65a4b5b321

