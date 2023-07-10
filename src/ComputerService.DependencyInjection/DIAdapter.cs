using ComputerService.BusinessLogic;
using ComputerService.BusinessLogic.Interfaces;
using ComputerService.Services;
using ComputerService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerService.DependencyInjection
{
    public static class DIAdapter
    {
        public static void AddMyServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDeviceBL, DeviceBL>();
        }
    }
}