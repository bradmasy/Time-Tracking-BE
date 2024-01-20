using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using dotenv.net;
using Google.Cloud.Firestore;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using app_api;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens; // For TokenValidationParameters and SymmetricSecurityKey
using System.Text; // For Encoding
using app_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotEnv.Load();
var environmentVariables = DotEnv.Read();

// Setup dev database here as well.
string ConnectionSTR =
    environmentVariables.ContainsKey("MYSQL_CONNECTION_STRING") && environmentVariables["MYSQL_CONNECTION_STRING"] != ""
    ? environmentVariables["MYSQL_CONNECTION_STRING"] : Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING");

builder.Services.AddDbContext<app_api.Database.TimeTrackerDatabaseContext>(opt =>
{
    opt.UseMySql(ConnectionSTR, new MySqlServerVersion(new Version(8, 0, 25)));
});

builder.Services.AddCors(opt => opt.AddPolicy("AllowSpecificOrigin", builder =>
{
    builder.WithOrigins("https://time-tracking-af81e.web.app", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "your-issuer", // Replace with your actual issuer
        ValidAudience = "your-audience", // Replace with your actual audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secure-key")), // Replace with your secure key
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddScoped<AuthService>();

var app = builder.Build();




app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();

}
else
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
