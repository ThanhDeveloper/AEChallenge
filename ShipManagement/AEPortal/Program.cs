using AEPortal.Bussiness.Extentions;
using AEPortal.Bussiness.Mapping;
using AEPortal.Bussiness.Middlewares;
using AEPortal.Common.Extentions;
using AEPortal.Data.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var rootApi = "api/";

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) => configuration.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddConfigBase(builder.Configuration, rootApi, typeof(Program).Assembly);

builder.Services.AddDbContext<Context>(ops =>
{
    ops.UseLazyLoadingProxies();
    ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(Context))?.GetName().Name);
    });

});

builder.Services.DJRepository();

builder.Services.DJService();

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomException();

app.UseHttpsRedirection();

app.UseCors("AnyOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
