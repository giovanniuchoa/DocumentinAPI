using DocumentinAPI.Authentication;
using DocumentinAPI.Data;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using DocumentinAPI.Repository;
using DocumentinAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DataBase

var connectionString = builder.Configuration.GetConnectionString("Local_NotebookGio");
//var connectionString = builder.Configuration.GetConnectionString("Local_NotebookJao");
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

/* Service */
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IDocumentVersionService, DocumentVersionService>();

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

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
