using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text;



// Set up Dependency Injection (DI)
var serviceProvider = new ServiceCollection()
    .AddScoped<IPracticalTest, PracticalTestService>() // Register Service
    .BuildServiceProvider();

// Resolve the service
var Service = serviceProvider.GetRequiredService<IPracticalTest>();

// Call the method from the service
Service.ListingNodeExample();



