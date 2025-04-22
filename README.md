# DocumentinAPI

DocumentinAPI is a .NET 8.0 RESTful API designed for document management and organization within companies. It provides a robust backend for managing documents, users, groups, and companies with authentication and authorization capabilities.

## Overview

DocumentinAPI enables companies to:
- Manage user access and permissions
- Organize documents into folders
- Track document versions
- Tag and categorize documents
- Assign tasks related to documents
- Comment on documents
- Create document templates

## Technology Stack

- **Framework**: .NET 8.0
- **Database**: SQL Server
- **ORM**: Entity Framework Core 9.0
- **Authentication**: JWT (JSON Web Tokens)
- **Mapping**: Mapster
- **API Documentation**: Swagger/OpenAPI

## Project Structure

The project follows a clean architecture pattern with the following components:

### Controllers
- `AuthController`: Handles user authentication
- `CompanyController`: Manages company data
- `GroupController`: Manages user groups
- `UserController`: Manages user accounts
- `BaseController`: Provides common functionality for all controllers

### Services and Repositories
The application uses a service layer that communicates with repositories:
- Services implement business logic
- Repositories handle data access

### Domain Models
Key models include:
- User
- Company
- Group
- Document
- DocumentVersion
- Folder
- Tag
- Comment
- Task
- Template

### Authentication
JWT-based authentication with token services for secure API access.

## Setup Instructions

### Prerequisites
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 or another compatible IDE

### Configuration

1. **Clone the repository**
   ```
   git clone https://github.com/your-username/DocumentinAPI.git
   cd DocumentinAPI
   ```

2. **Configure the database connection**
   
   Edit the connection string in `appsettings.json` or use one of the predefined connections in `Program.cs`:
   ```csharp
   // Uncomment the connection string you want to use
   // var connectionString = builder.Configuration.GetConnectionString("Local_NotebookGio");
   // var connectionString = builder.Configuration.GetConnectionString("Local_NotebookJao");
   var connectionString = builder.Configuration.GetConnectionString("Local_PcEmpresaGio");
   ```

3. **Apply database migrations**
   ```
   dotnet ef database update
   ```

4. **Update JWT Secret** (recommended for production)
   
   Replace the hardcoded JWT secret in `Authentication/Settings.cs` with an environment variable:
   ```csharp
   // Change from
   public static string Secret = "h7K!mN@3tP#xQ$zW%y&L8vR^bJ*2dC(E)5sT-U+fG{a}9pX|6qZ<>kY~wV";
   
   // To
   public static string Secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "your_fallback_secret";
   ```

### Running the API

1. **Build the project**
   ```
   dotnet build
   ```

2. **Run the API**
   ```
   dotnet run
   ```

3. **Access Swagger UI**
   
   Browse to `https://localhost:7xxx/swagger` (port may vary) to view and test the API endpoints.

## API Endpoints

### Authentication
- `POST /Authenticate`: Authenticate a user and receive a JWT token

### Company Management
- `GET /Company/GetCompaniesById/{companyId}`: Get company by ID
- `GET /Company/GetListCompanies`: Get all companies
- `POST /Company/AddCompany`: Create a new company
- `PUT /Company/UpdateCompany`: Update a company
- `PUT /Company/ToggleStatusCompany/{companyId}`: Enable/disable a company

### Group Management
- `GET /Group/GetGroupById/{groupId}`: Get group by ID
- `GET /Group/GetListGroup`: Get all groups
- `POST /Group/AddGroup`: Create a new group
- `PUT /Group/UpdateGroup`: Update a group
- `PUT /Group/ToggleStatusGroup/{groupId}`: Enable/disable a group

### User Management
- `GET /User/GetUserById/{userId}`: Get user by ID
- `GET /User/GetListUser`: Get all users
- `POST /User/AddUser`: Create a new user
- `PUT /User/UpdateUser`: Update a user
- `PUT /User/ToggleStatusUser/{userId}`: Enable/disable a user

## Authentication Flow

1. Client sends credentials to `/Authenticate`
2. Server validates credentials and returns a JWT token
3. Client includes the token in the `Authorization` header for subsequent requests
4. Server validates the token and extracts user information for authorization

## Security Notes

- The JWT token contains claims for user ID, name, profile (role), and company ID
- Tokens expire after 8 hours
- All API endpoints (except authentication) require authorization
- User session data is extracted from JWT claims in the `BaseController`

## Future Improvements

- Implement document and folder endpoints
- Add file upload and storage capabilities
- Implement version control for documents
- Add search functionality
- Implement task management features
- Enhance security with refresh tokens
- Move hardcoded JWT secret to environment variables

## License

N/A
