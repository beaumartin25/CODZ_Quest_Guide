using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Enables API endpoint discovery.
builder.Services.AddSwaggerGen(); // Registers Swagger generator.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // If you want to keep this from the template.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IMapRepository, MapRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware.
    app.UseSwaggerUI(); // Enable the Swagger UI at /swagger.
    app.MapOpenApi(); // If you're using this from the template, leave it.
}

app.UseHttpsRedirection();

app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials()
     .SetIsOriginAllowed(origin => true));

app.UseAuthorization(); // Optional if you have no access control logic.

app.MapControllers();

app.Run();
