using DocumentinAPI.Authentication;
using DocumentinAPI.Data;
using DocumentinAPI.Domain.Filters;
using DocumentinAPI.Domain.Validators;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Repository;
using DocumentinAPI.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supabase;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentin - API",
        Version = "v1",
        Description = "API para gerenciamento empresarial de documentos e tarefas.",
        Contact = new OpenApiContact
        {
            Name = "Giovanni Uchoa",
            Email = "noreply.documentin@gmail.com"
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

#endregion

#region DataBase

var connectionString = builder.Configuration.GetConnectionString("Local_NotebookGio");
//var connectionString = builder.Configuration.GetConnectionString("Local_NotebookJao");
//var connectionString = builder.Configuration.GetConnectionString("Local_NotebookMengo");
//var connectionString = builder.Configuration.GetConnectionString("Local_PcEmpresaGio");

builder.Services.AddDbContext<DBContext>(opt => opt.UseSqlServer(connectionString));

#endregion

#region Dependency Injection

/* Repository */
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDocumentRepository, DocumentRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IDocumentVersionRepository, DocumentVersionRepository>();
builder.Services.AddTransient<ISupabaseRepository, SupabaseRepository>();
builder.Services.AddTransient<IFolderRepository, FolderRepository>();
builder.Services.AddTransient<IDocumentValidationRepository, DocumentValidationRepository>();
builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();

/* Service */
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IDocumentVersionService, DocumentVersionService>();
builder.Services.AddTransient<ISupabaseService, SupabaseService>();
builder.Services.AddTransient<IFolderService, FolderService>();
builder.Services.AddTransient<IDocumentValidationService, DocumentValidationService>();
builder.Services.AddTransient<ITemplateService, TemplateService>();
builder.Services.AddTransient<ICommentService, CommentService>();

#endregion

#region Authentication

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion

#region Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

#endregion

#region Supabase

builder.Services.AddScoped<Supabase.Client>(_ =>
new Supabase.Client(
    builder.Configuration["Supabase:Url"],
    builder.Configuration["Supabase:ApiKey"],
    new SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = true,
    }));

#endregion

#region Fluent Validation

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(CompanyRequestDTOValidator).Assembly);

#endregion

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentinAPI v1");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.DefaultModelsExpandDepth(2);

    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();