using Microsoft.EntityFrameworkCore;
using Socialdashboard;
using Socialdashboard.DbModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SocialDashboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



app.UseCors(policy => policy
    .WithOrigins("http://localhost:4205") // Allow requests from this origin
    .AllowAnyMethod()                      // Allow any HTTP method
    .AllowAnyHeader()                      // Allow any header
);

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


