using AEPortal.Bussiness.Services;
using AEPortal.Bussiness.UnitOfWorks;
using AEPortal.Common.GenericRepository;
using AEPortal.Data.Entities;
using AEPortal.Data.Entities.Context;
using Microsoft.Extensions.DependencyInjection;

namespace AEPortal.Bussiness.Extentions
{
    public static class RegisterServiceExtension
    {
        public static void DJService(this IServiceCollection service)
        {
            service.AddTransient<IShipService, ShipService>();
        }
        public static void DJRepository(this IServiceCollection service)
        {
            service.AddScoped<IGenericRepository<Ship>, GenericRepository<Ship, Context>>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
