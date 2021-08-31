using System;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Domain.Services;
using Faust.PetShopApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Faust.PetShopApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IMenu, Menu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var menu = serviceProvider.GetRequiredService<IMenu>();
            
            menu.StartUI();
        }
    }
}