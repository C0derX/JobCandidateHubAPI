using CandidateApi.Data;
using CandidateApi.Repositories;
using CandidateApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite connection
builder.Services.AddDbContext<CandidateContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register other services
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<CandidateService>();

// Add controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Create the database if it does not exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CandidateContext>();
    context.Database.EnsureCreated();  // Creates the database if it doesn't exist
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
