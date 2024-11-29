//Dependency Inversion Principle (DIP)
//Depend on abstractions, not on concrete implementations.
//Example: Use dependency injection to decouple classes.

using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddScoped<IUserOperations, UserService>()        // Add User Service
            .AddScoped<IUserValidator, UserValidator>()       // Add User Validator
            .AddScoped<ILogger, ConsoleLogger>()              // Add Logger
            .AddTransient<CSVReport>()                        // Add CSV Report
            .AddTransient<PDFReport>()                        // Add PDF Report
            .AddScoped<Func<string, IReport>>
            (provider => key => // Factory for dynamic selection
            {
                return key switch
                {
                    "1" => provider.GetRequiredService<CSVReport>(),
                    "2" => provider.GetRequiredService<PDFReport>(),
                    _ => throw new InvalidOperationException("Invalid report type")
                };
            })
            .BuildServiceProvider();

        // Resolve services
        var userService = serviceProvider.GetRequiredService<IUserOperations>();
        var validator = serviceProvider.GetRequiredService<IUserValidator>();
        var logger = serviceProvider.GetRequiredService<ILogger>();
        var reportFactory = serviceProvider.GetRequiredService<Func<string, IReport>>();

        // User Input
        var user = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };
        if (!validator.Validate(user, out string validationError))
        {
            logger.Log($"Validation Error: {validationError}");
            return;
        }

        userService.AddUser(user);
        logger.Log("User added successfully.");

        // Select Report Type Dynamically
        Console.WriteLine("Select Report Type: 1-CSV, 2-PDF");
        var choice = Console.ReadLine();

        try
        {
            var reportService = reportFactory(choice);
            reportService.GenerateReport();
        }
        catch (Exception ex)
        {
            logger.Log($"Error: {ex.Message}");
        }
    }
}
