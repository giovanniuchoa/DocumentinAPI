# DocumentinAPI

DocumentinAPI is a RESTful API developed in .NET 8.0 designed for comprehensive document management and workflow in business environments. The system offers advanced features for organization, version control, approval workflow, and document collaboration, as well as AI functionality and task management.

## Overview

DocumentinAPI allows companies to:

- Manage documents with version control and approval workflow
- Organize documents in hierarchical folder structures
- Control access through user groups
- Add tags for categorization and easy searching
- Comment and collaborate on documents
- Automate analyses using artificial intelligence
- Create and assign document-related tasks
- Access metrics and analyses through dashboards

## Technology Stack

- *Framework*: .NET 8.0
- *Database*: SQL Server
- *ORM*: Entity Framework Core 9.0
- *Authentication*: JWT (JSON Web Tokens)
- *Object Mapping*: Mapster
- *Validation*: FluentValidation
- *API Documentation*: Swagger/OpenAPI
- *Email*: MailKit
- *Cloud Storage*: Supabase
- *AI*: OpenAI integration (GPT and Embeddings)
- *Document Processing*: Aspose.Words

## Architecture

The project follows a clean architecture with clear separation between:

- *Controllers*: API endpoints and HTTP request handling
- *Services*: Business logic implementation
- *Repositories*: Data access and manipulation
- *Domain*: Models, DTOs, and core application logic
- *Authentication*: Authentication and security services

### Key Features

#### Document System
- Creation and management of documents in Markdown format
- Complete version control with change history
- Approval system with multiple states (In Progress, Validated, Returned)
- Support for embeddings using OpenAI for semantic search
- Import of PDF and DOCX documents

#### Access Management
- User hierarchy (Admin, Manager, Employee)
- Granular access control based on groups
- Groups can be associated with specific folders
- Each user can belong to multiple groups

#### Artificial Intelligence
- Automatic generation of summaries in different formats:
  - Structured summary
  - Comparative summary
  - Analytical summary
- Creation of embeddings for semantic search
- Monitoring of AI usage and costs

#### Task System
- Creation and assignment of tasks to users
- Support for priorities and deadlines
- Hierarchical structure (tasks and subtasks)
- Status and progress tracking

#### Notifications
- Email notification system for:
  - New documents awaiting validation
  - Status changes in documents
  - New comments on documents
  - New assigned tasks
  - Password recovery

#### Dashboard and Analytics
- Document metrics (total, active/inactive, approval status)
- Temporal analysis of document creation
- AI usage statistics and token consumption
- Task and productivity metrics
- Document validation analysis by user

## Endpoint Structure

### Authentication
- POST /Auth/Authenticate: Authenticate user and obtain JWT token

### User Management
- GET /User/GetUserById/{userId}: Get user by ID
- GET /User/GetListUser: List all users
- POST /User/AddUser: Create new user
- PUT /User/UpdateUser: Update user
- PUT /User/ToggleStatusUser/{userId}: Enable/disable user
- GET /User/GetListGroupByUser/{userId}: List user's groups
- POST /User/AddUserXGroup: Link user to group
- DELETE /User/DeleteUserXGroup: Unlink user from group
- POST /User/RequestPasswordRecovery: Request password recovery
- POST /User/ValidateTokenPasswordRecovery: Validate recovery token
- PUT /User/UpdatePasswordRecovery: Update password with valid token

### Company Management
- GET /Company/GetCompaniesById/{companyId}: Get company by ID
- GET /Company/GetListCompanies: List all companies
- POST /Company/AddCompany: Create new company
- PUT /Company/UpdateCompany: Update company
- PUT /Company/ToggleStatusCompany/{companyId}: Enable/disable company

### Group Management
- GET /Group/GetGroupById/{groupId}: Get group by ID
- GET /Group/GetListGroup: List all groups
- POST /Group/AddGroup: Create new group
- PUT /Group/UpdateGroup: Update group
- PUT /Group/ToggleStatusGroup/{groupId}: Enable/disable group
- GET /Group/GetListUserByGroup/{groupId}: List users in group
- GET /Group/GetListFolderByGroup/{groupId}: List folders associated with group

### Document Management
- GET /Document/GetDocumentById/{documentId}: Get document by ID
- GET /Document/GetListDocument: List all documents
- POST /Document/AddDocument: Create new document
- PUT /Document/UpdateDocument: Update document
- PUT /Document/ToogleStatusDocument/{documentId}: Enable/disable document
- GET /Document/GetUserDocuments: List current user's documents

### Document Versions
- GET /DocumentVersion/GetDocumentVersionById/{documentVersionId}: Get version by ID
- GET /DocumentVersion/GetListDocumentVersionByDocumentId/{documentId}: List document versions
- POST /DocumentVersion/AddCommentDocumentVersion: Add comment to a version

### Document Validation
- GET /DocumentValidation/GetListDocumentValidationByValidator: List documents pending validation
- GET /DocumentValidation/GetListDocumentValidationToEdit: List documents returned for editing
- PUT /DocumentValidation/UpdateDocumentValidationStatus: Update validation status
- GET /DocumentValidation/GetDocumentValidationById/{documentId}: Get validation status

### Folders
- GET /Folder/GetFolderById/{folderId}: Get folder by ID
- GET /Folder/GetListFolder: List all folders
- POST /Folder/AddFolder: Create new folder
- PUT /Folder/UpdateFolder: Update folder
- PUT /Folder/ToogleStatusFolder/{folderId}: Enable/disable folder
- PUT /Folder/MoveFolder: Move folder to another location
- POST /Folder/AddFolderXGroup: Link folder to group
- DELETE /Folder/DeleteFolderXGroup: Unlink folder from group
- GET /Folder/GetListFolderXGroupByFolder/{folderId}: List groups with access to folder

### Comments
- GET /Comment/GetCommentById/{commentId}: Get comment by ID
- GET /Comment/GetListComment: List all comments
- GET /Comment/GetListCommentByDocumentId/{documentId}: List document comments
- POST /Comment/AddComment: Add comment
- PUT /Comment/UpdateComment: Update comment
- PUT /Comment/ToogleStatusComment/{commentId}: Enable/disable comment

### Tags
- GET /Tag/GetTagById/{tagId}: Get tag by ID
- GET /Tag/GetListTag: List all tags
- POST /Tag/AddTag: Create new tag
- PUT /Tag/UpdateTag: Update tag
- PUT /Tag/ToogleStatusTag/{tagId}: Enable/disable tag
- GET /Tag/GetDocumentXTagByTagId: List documents with specific tag
- GET /Tag/GetDocumentXTagByDocumentId: List tags for a document
- POST /Tag/AddDocumentXTag: Associate tag with document
- DELETE /Tag/DeleteDocumentXTag: Remove tag from document

### Tasks
- GET /Task/GetTaskById/{taskId}: Get task by ID
- GET /Task/GetListTask: List all tasks
- POST /Task/AddTask: Create new task
- PUT /Task/UpdateTask: Update task
- PUT /Task/ToogleStatusTask/{taskId}: Enable/disable task

### Templates
- GET /Template/GetTemplateById/{templateId}: Get template by ID
- GET /Template/GetListTemplate: List all templates
- POST /Template/AddTemplate: Create new template
- PUT /Template/UpdateTemplate: Update template
- PUT /Template/ToggleStatusTemplate/{templateId}: Enable/disable template

### Artificial Intelligence
- POST /AI/GenerateSummary: Generate document summary using AI
- GET /AI/GetOpenAIConfigByCompany: Get company's AI configuration
- POST /AI/AddOpenAIConfig: Add AI configuration
- PUT /AI/UpdateOpenAIConfig: Update AI configuration
- POST /Embedding/GetEmbedding: Generate embedding for content

### Import
- POST /Import/ImportDocument: Import PDF or DOCX document

### Cloud Storage
- POST /Supabase/UploadImage: Upload image to Supabase

### Dashboard
- GET /Dashboard/documents: Get general document metrics
- GET /Dashboard/documentsMonths: Get document metrics by month
- GET /Dashboard/ai: Get AI usage metrics
- GET /Dashboard/aiUsers: Get AI usage metrics by user
- GET /Dashboard/task: Get general task metrics
- GET /Dashboard/taskPriority: Get task metrics by priority
- GET /Dashboard/documentvalidation: Get document validation metrics
- GET /Dashboard/documentvalidationUsers: Get validation metrics by validator

## Configuration

### Prerequisites
- .NET 8.0 SDK
- SQL Server
- Supabase account for image storage
- OpenAI account for AI features
- SMTP for email sending

### Database Configuration
1. Configure the connection string in appsettings.json or use one of the predefined ones:
   csharp
   var connectionString = builder.Configuration.GetConnectionString("Local");
   

2. Apply Entity Framework migrations:
   
   dotnet ef database update
   
## Docker
The project includes a Dockerfile for easy deployment:

docker build -t documentinapi .
docker run -p 8080:8080 documentinapi

