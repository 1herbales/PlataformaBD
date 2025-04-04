using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Plataforma.Core.Interfaces;
using Plataforma.Infrastructure.Datos;
using Plataforma.Infrastructure.Filtros;
using Plataforma.Infrastructure.Repositorios;
using Plataforma.Core.Servicios;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UniversidadContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("universidad")));

builder.Services.AddTransient<IDocenteServicio, DocenteServicio>();
builder.Services.AddTransient<IDocenteRepositorio, DocenteRepository>();

builder.Services.AddTransient<IDocentePlantumServicio, DocentePlantumServicio>();
builder.Services.AddTransient<IDocentePlantumRepositorio, DocentePlantumRepository>();

builder.Services.AddTransient<IDocenteTitulosRepositorio, DocenteTitulosRepository>();
builder.Services.AddTransient<IDocenteTitulosServicio, DocenteTitulosServicio>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddMvc(options =>
{
    options.Filters.Add(new FiltroValidacion());

});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
