using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using StudentManagementEF.Data;
using StudentManagementEF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services → Dependency Injection (DI) container
// Used to register services that the app will need

// AddDbContext<AppDbContext>() → Registers AppDbContext
// ASP.NET will automatically create and inject it wherever needed

// Important:
// - One DbContext per request
// - Automatically disposed after use (handles lifecycle properly)

builder.Services.AddDbContext<AppDbContext>(options =>
    // options => configuration block for DbContext

    options.UseMySql(
        // UseMySql → tells EF Core to use MySQL database

        builder.Configuration.GetConnectionString("DefaultConnection"),
        // Reads connection string from appsettings.json
        // Avoids hardcoding database credentials

        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    // Automatically detects MySQL version
    // Ensures compatibility with EF Core
    )
);
//Register AppDbContext and configure it to connect to a MySQL database using the connection
//string from appsettings.json.”
//This code registers DbContext and configures it to connect to MySQL using the connection string.

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
    //var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

   // var student = new Student
    //{
        //Name = "Dharma",
        //Age = 21
    //};

    //context.Students.Add(student);
    //context.SaveChanges();
//} used to manually add into the table
//Understand what’s happening
//🔹 CreateScope()

//👉 Creates a scope to use DbContext (since it’s scoped)

//🔹 GetRequiredService<AppDbContext>()

//👉 Gets DbContext from DI container

//🔹 new Student

//👉 Creating one row (object)

//🔹 context.Students.Add(student)

//👉 Adds it to table (not saved yet)

//🔹 context.SaveChanges()

//👉 Actually inserts into database

//🔥 Important Concept

//👉 Without SaveChanges() → nothing goes to DB
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
