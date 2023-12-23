using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using dotenv.net;
using Google.Cloud.Firestore;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using app_api;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotEnv.Load(); // Loading environment variables from .env file
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
    builder.WithOrigins("https://time-tracking-af81e.web.app").AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
