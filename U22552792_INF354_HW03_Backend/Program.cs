using Microsoft.EntityFrameworkCore;
using U22552792_INF354_HW03_Backend.Data;
using U22552792_INF354_HW03_Backend.Models.IRepositories;
using U22552792_INF354_HW03_Backend.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>(); // Add this line

var app = builder.Build();

// Enable CORS
app.UseStaticFiles();
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200") // Update with your frontend domain
           .AllowAnyHeader()
           .AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add the route for your controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=AddProduct}/{id?}");


app.Run();
