using DoctorWho.Web.Validators;
using DoctorWho.Web.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DoctorWho.Db.Repositories;
using DoctorWho.Db;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEpisodesRepository, EpisodesRepository>();

// Register the DbContext and the repository with the dependency injection container
builder.Services.AddDbContext<DoctorWhoCoreDbContext>();
builder.Services.AddScoped<DoctorsRepository>();
builder.Services.AddScoped<CompanionsRepository>();
builder.Services.AddScoped<EnemiesRepository>();


// Add controllers and FluentValidation
builder.Services.AddControllers()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EpisodeDtoValidator>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
