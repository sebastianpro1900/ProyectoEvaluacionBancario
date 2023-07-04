using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Mapping;
using SistemaAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SistemaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SistemaConnectionString")));

builder.Services.AddScoped<IPersonaRepository, SQLPersonaRepository>();
builder.Services.AddScoped<IClienteRepository, SQLClienteRepository>();
builder.Services.AddScoped<ICuentaRepository, SQLCuentaRepository>();
builder.Services.AddScoped<IMovimientoRepository, SQLMovimientoRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


var app = builder.Build();

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
